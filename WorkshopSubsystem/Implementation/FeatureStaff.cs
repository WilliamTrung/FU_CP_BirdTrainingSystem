using AppRepository.UnitOfWork;
using AutoMapper;
using Microsoft.Extensions.Options;
using Models.ConfigModels;
using Models.Entities;
using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem.Implementation
{
    public class FeatureStaff : FeatureUser, IFeatureStaff
    {
        private readonly BR_WorkshopConstant _br;
        public FeatureStaff(IUnitOfWork unitOfWork, IMapper mapper, IOptions<BR_WorkshopConstant> br) : base(unitOfWork, mapper)
        {
            _br = br.Value;
        }
        public async Task CreateWorkshopClass(ClassAddModel classAddModel)
        {
            //classAddModel with given WorkshopId and StartTime
            try
            {
                var starttime = classAddModel.StartTime;         
                var workshop = await _unitOfWork.WorkshopRepository.GetFirst(c => c.Id == classAddModel.WorkshopId);
                if (workshop == null)
                {
                    throw new TaskCanceledException("Workshop is not found for ID: " + classAddModel.WorkshopId);
                }

                var entity = _mapper.Map<Models.Entities.WorkshopClass>(classAddModel);
                int daySumToRegistrationEnd = workshop.RegisterEnd == null ? _br.StartDateDeadlineAfterRegistrationEnd : workshop.RegisterEnd.Value;

                entity.Status = (int)Models.Enum.Workshop.Class.Status.Registration;
                entity.RegisterEndDate = starttime.AddDays(daySumToRegistrationEnd);
                
                await _unitOfWork.WorkshopClassRepository.Add(entity);
                //add class slots into new class
                for (int i = 0; i < workshop.TotalSlot; i++)
                {
                    await _unitOfWork.WorkshopClassDetailRepository.Add(new WorkshopClassDetail()
                    {
                        WorkshopClassId = entity.Id
                    });
                }
            }
            catch (Exception ex)
            {
                throw new TaskCanceledException($"{ex.Message} at {ex.StackTrace}");
            }
        }

        public async Task<IEnumerable<ClassViewModel>> GetClassByWorkshopId(int workshopId)
        {
            var entities = await _unitOfWork.WorkshopClassRepository.Get(c => c.WorkshopId == workshopId, "Workshop");
            entities = entities.OrderBy(c => c.Status).ToList();
            var models = _mapper.Map<IEnumerable<ClassViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<WorkshopModel>> GetWorkshops()
        {
            var entities = await _unitOfWork.WorkshopRepository.Get(expression: null, "WorkshopPricePolicy", "WorkshopRefundPolucy");
            var models = _mapper.Map<IEnumerable<WorkshopModel>>(entities);
            return models;
        }

        public async Task ModifyWorkshopClass(ClassModifiedModel @class)
        {
            try
            {
                var starttime = @class.StartTime;
                var workshopClass = await _unitOfWork.WorkshopClassRepository.GetFirst(c => c.Id == @class.Id, "WorkshopClassDetails");
                if (workshopClass == null)
                {
                    throw new TaskCanceledException("Workshop Class is not found for ID: " + @class.Id);
                }
                var workshop = await _unitOfWork.WorkshopRepository.GetFirst(c => c.Id == workshopClass.WorkshopId);
                if(workshop == null)
                {
                    throw new TaskCanceledException("Workshop is not found for ID: " + workshopClass.WorkshopId);
                }
                int daySumToRegistrationEnd = workshop.RegisterEnd == null ? _br.StartDateDeadlineAfterRegistrationEnd : workshop.RegisterEnd.Value;

                //reset status and register end date
                workshopClass.Status = (int)Models.Enum.Workshop.Class.Status.Registration;
                workshopClass.RegisterEndDate = starttime.AddDays(daySumToRegistrationEnd);
                //reset generated workshop class slots
                foreach (var detail in workshopClass.WorkshopClassDetails)
                {
                    detail.TrainerId = null;
                    detail.DaySlotId = null;
                    detail.DaySlot.Status = (int)Models.Enum.TrainerSlotStatus.Disabled;                    
                }
                await _unitOfWork.WorkshopClassRepository.Update(workshopClass);
            }
            catch (Exception ex)
            {
                throw new TaskCanceledException($"{ex.Message} at {ex.StackTrace}");
            }
        }

        public async Task ModifyWorkshopClassSlot_ChangeTrainer(int workshopClassId, WorkshopTrainerSlotAddModel workshopTrainerSlotAddModel)
        {
            //set TrainerSlot status of current slot to disabled
            var e_current_workshopClassSlot = await _unitOfWork.WorkshopClassDetailRepository.GetFirst(c => c.Id == workshopClassId, "DaySlot");
            if(e_current_workshopClassSlot == null)
            {
                throw new Exception("WorkshopClassDetail not found for ID: "+ workshopClassId);
            }
            if(e_current_workshopClassSlot.DaySlotId != null)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                e_current_workshopClassSlot.DaySlotId = null;
                await _unitOfWork.TrainerSlotRepository.Delete(e_current_workshopClassSlot.DaySlot);
#pragma warning restore CS8604 // Possible null reference argument.
            }

            //assign new TrainerSlot
            var e_trainerSlot = _mapper.Map<TrainerSlot>(workshopTrainerSlotAddModel);
            await _unitOfWork.TrainerSlotRepository.Add(e_trainerSlot);
            e_current_workshopClassSlot.DaySlotId = e_trainerSlot.Id;
            await _unitOfWork.WorkshopClassDetailRepository.Update(e_current_workshopClassSlot);            
        }
        public Task ModifyWorkshopClassSlot_ChangeSlot(int workshopClassId)
        {
            //change slot id and datetime of DaySlot 
            throw new NotImplementedException();
        }
    }
}
