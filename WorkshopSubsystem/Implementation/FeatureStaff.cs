using AppRepository.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.ConfigModels;
using Models.Entities;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using SP_Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem.Implementation
{
    public class FeatureStaff : FeatureAll, IFeatureStaff
    {
        public FeatureStaff(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task CreateWorkshopClass(WorkshopClassAddModel workshopClass)
        {
            var workshop = await _unitOfWork.WorkshopRepository.GetFirst(c => c.Id == workshopClass.WorkshopId);
            if(workshop == null)
            {
                throw new KeyNotFoundException($"{nameof(workshop)} not found at id: {workshopClass.WorkshopId}");
            }
            if(workshop.Status != (int)Models.Enum.Workshop.Status.Active)
            {
                throw new InvalidOperationException($"{typeof(Workshop)} is inactive");
            }
            var entity = _mapper.Map<WorkshopClass>(workshopClass);
            if(entity.StartTime < DateTime.Now.AddDays(BR_WorkshopConstant.StartDateCreated)) {
                throw new InvalidOperationException("Open registration day must be 5 days after from today!");
            }
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8629 // Nullable value type may be null.
            entity.RegisterEndDate = entity.StartTime.Value.AddDays(double.Parse(workshop.RegisterEnd.ToString()));
#pragma warning restore CS8629 // Nullable value type may be null.
#pragma warning restore CS8604 // Possible null reference argument.
            await _unitOfWork.WorkshopClassRepository.Add(entity);
            //add workshop class details to class
            var workshopDetails = await _unitOfWork.WorkshopDetailTemplateRepository.Get(c => c.WorkshopId == workshop.Id);
            workshopDetails = workshopDetails.OrderBy(c => c.Id);
            var classDetails = new List<WorkshopClassDetail>();
            for (int i = 0; i < workshop.TotalSlot; i++)
            {
                classDetails.Add(new WorkshopClassDetail
                {                    
                    DaySlotId = null,
                    DetailId = workshopDetails.ElementAt(i).Id,
                    WorkshopClassId = entity.Id,
                });
            }
            entity.WorkshopClassDetails = classDetails;
            await _unitOfWork.WorkshopClassRepository.Update(entity);
        }

        public async Task<WorkshopClassDetailViewModel?> GetPreviousWorkshopClassDetail(int workshopClassDetailId)
        {
            var current = await _unitOfWork.WorkshopClassDetailRepository.GetFirst(c => c.Id==workshopClassDetailId, nameof(WorkshopClassDetail.DaySlot));
            //25-10-2023 - TrungNT - Delete Start
            //var entities = await _unitOfWork.WorkshopClassDetailRepository.Get(c => c.Id == workshopClassDetailId
            //                                                                    && CustomDateFunctions.CompareDate(c.DaySlot.Date, current.DaySlot.Date) <= 0                                                                                
            //                                                                    , nameof(WorkshopClassDetail.DaySlot));
            //var minDate = entities.Min(c => c.DaySlot.Date);
            //var minRecords = entities.Where(c => c.DaySlot.Date == minDate);
            //minRecords = minRecords.Where(c => c.DaySlot.SlotId > current.DaySlot.SlotId);
            //var result = minRecords.OrderBy(c => c.DaySlot.SlotId).First();
            //return _mapper.Map<WorkshopClassDetailViewModel>(result);
            //25-10-2023 - TrungNT - Delete End
            //25-10-2023 - TrungNT - Add Start
            var entity = await _unitOfWork.WorkshopClassDetailRepository.GetFirst(c => c.Id == (workshopClassDetailId - 1)
                                                                                    && c.WorkshopClassId == current.WorkshopClassId
                                                                                    , nameof(WorkshopClassDetail.WorkshopDetailTemplate));
            if (entity == null)
            {
                return null;
            }
            //25-10-2023 - TrungNT - Add End
            return _mapper.Map<WorkshopClassDetailViewModel>(entity);
        }
        public async Task<WorkshopClassDetailViewModel?> GetFollowingWorkshopClassDetail(int workshopClassDetailId)
        {
            var current = await _unitOfWork.WorkshopClassDetailRepository.GetFirst(c => c.Id == workshopClassDetailId);
            //25-10-2023 - TrungNT - Delete Start         
            //var entities = await _unitOfWork.WorkshopClassDetailRepository.Get(c => c.WorkshopClassId == current.WorkshopClassId
            //                                                                    //&& CustomDateFunctions.CompareDate(c.DaySlot.Date, current.DaySlot.Date) >= 0
            //                                                                    && c.DaySlot.Date.Day >= current.DaySlot.Date.Day
            //                                                                    && c.DaySlot.Date.Month >= current.DaySlot.Date.Month
            //                                                                    && c.DaySlot.Date.Year >= current.DaySlot.Date.Year
            //                                                                    , nameof(WorkshopClassDetail.DaySlot));
            //var maxDate = entities.Max(c => c.DaySlot.Date);
            //var minRecords = entities.Where(c => c.DaySlot.Date == maxDate);
            //minRecords = minRecords.Where(c => c.DaySlot.SlotId < current.DaySlot.SlotId);
            //var result = minRecords.OrderByDescending(c => c.DaySlot.SlotId).First();
            //return _mapper.Map<WorkshopClassDetailViewModel>(result);
            //25-10-2023 - TrungNT - Delete End
            //25-10-2023 - TrungNT - Add Start
            var entity = await _unitOfWork.WorkshopClassDetailRepository.GetFirst(c => c.Id == (workshopClassDetailId + 1) 
                                                                                    && c.WorkshopClassId == current.WorkshopClassId
                                                                                    , nameof(WorkshopClassDetail.WorkshopDetailTemplate));
            if(entity == null)
            {
                return null;
            }
            //25-10-2023 - TrungNT - Add End
            return _mapper.Map<WorkshopClassDetailViewModel>(entity);
        }

        public async Task<IEnumerable<WorkshopClassAdminViewModel>> GetWorkshopClassAdminViewModels(int workshopId)
        {
            var entities = await _unitOfWork.WorkshopClassRepository.Get(c => c.WorkshopId == workshopId 
                                                                           && c.Status != (int)Models.Enum.Workshop.Class.Status.Cancelled);
            var models = _mapper.Map<List<WorkshopClassAdminViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<WorkshopClassDetailViewModel>> GetWorkshopClassDetailViewModels(int workshopClassId)
        {
            var entities = await _unitOfWork.WorkshopClassDetailRepository.Get(c => c.WorkshopClassId == workshopClassId 
                                                                                 && c.WorkshopClass.Status != (int)Models.Enum.Workshop.Class.Status.Cancelled
                                                                                 , nameof(WorkshopClassDetail.DaySlot), nameof(WorkshopClassDetail.WorkshopClass));
            var models = _mapper.Map<List<WorkshopClassDetailViewModel>>(entities);
            return models;
        }

        public async Task ModifyWorkshopClassDetailSlotOnly(WorkshopClassDetailTrainerSlotOnlyModifyModel workshopClass)
        {
            var entity = await _unitOfWork.WorkshopClassDetailRepository.GetFirst(c => c.Id == workshopClass.Id
                                                                                    && c.WorkshopClass.Status != (int)Models.Enum.Workshop.Class.Status.Cancelled
                                                                                    , nameof(WorkshopClassDetail.DaySlot)
                                                                                    , nameof(WorkshopClassDetail.WorkshopClass));
            if(entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {workshopClass.Id}");
            }
            if(entity.DaySlot == null)
            {
                var entity_dayslot = await _unitOfWork.TrainerSlotRepository.GetFirst(c => c.Id == entity.DaySlotId);
                if(entity_dayslot == null)
                {
                    throw new KeyNotFoundException($"{nameof(entity_dayslot)} not found for id: {entity.DaySlotId}");
                }                
                entity_dayslot.SlotId = workshopClass.SlotId;
                entity_dayslot.Date = workshopClass.Date.ToDateTime(new TimeOnly(0, 0, 0));
                await _unitOfWork.TrainerSlotRepository.Update(entity_dayslot);
            } else
            {
                entity.DaySlot.SlotId = workshopClass.SlotId;
                entity.DaySlot.Date = workshopClass.Date.ToDateTime(new TimeOnly(0, 0, 0));
                await _unitOfWork.WorkshopClassDetailRepository.Update(entity);
            }
            
        }

        public async Task ModifyWorkshopClassDetailTrainerSlot(WorkshopClassDetailTrainerSlotModifyModel workshopClass)
        {
            var entity = await _unitOfWork.WorkshopClassDetailRepository.GetFirst(c => c.Id == workshopClass.Id
                                                                                    && c.WorkshopClass.Status != (int)Models.Enum.Workshop.Class.Status.Cancelled
                                                                                    , nameof(WorkshopClassDetail.DaySlot)
                                                                                    , nameof(WorkshopClassDetail.WorkshopClass));
            if(entity == null)
            {
                throw new KeyNotFoundException($"{typeof(WorkshopClassDetail)} not found at id: {workshopClass.Id}");
            }
            if(entity.DaySlot == null)
            {
                var temp = workshopClass.Date.ToDateTime(new TimeOnly(0, 0, 0));
                entity.DaySlot = _mapper.Map<TrainerSlot>(workshopClass);
                await _unitOfWork.TrainerSlotRepository.Add(entity.DaySlot);
            } else
            {
                entity.DaySlot.TrainerId = workshopClass.TrainerId;
                entity.DaySlot.SlotId = workshopClass.SlotId;
                entity.DaySlot.Date = workshopClass.Date.ToDateTime(new TimeOnly(0, 0, 0));                
            }
            await _unitOfWork.WorkshopClassDetailRepository.Update(entity);
        }

        public async Task CancelWorkshopClass(int workshopClassId)
        {
            var entity = await _unitOfWork.WorkshopClassRepository.GetFirst(c => c.Id == workshopClassId);
            //26-10-2023 - TrungNT - Delete Start
            //var registered = await _unitOfWork.CustomerWorkshopClassRepository.Get(c => c.WorkshopClassId == workshopClassId 
            //                                                                        && c.Status == (int)Models.Enum.Workshop.Transaction.Status.Paid);
            //if (registered.Count() >= BR_WorkshopConstant.MinimumRegisteredCustomer)
            //{
            //    throw new InvalidOperationException("This workshop class has reached the minimum amount of registration!");   
            //} else
            //{
            //    entity.Status = (int)Models.Enum.Workshop.Class.Status.Cancelled;
            //    await _unitOfWork.WorkshopClassRepository.Update(entity);
            //}
            //26-10-2023 - TrungNT - Delete End
            //26-10-2023 - TrungNT - Add Start
            if(entity.Status == (int)Models.Enum.Workshop.Class.Status.OnGoing)
            {
                throw new InvalidOperationException("This workshop class is on-going!");
            } else if(entity.Status == (int)Models.Enum.Workshop.Class.Status.Completed)
            {
                throw new InvalidOperationException("This workshop class has been completed!");
            }
            //26-10-2023 - TrungNT - Add End
            entity.Status = (int)Models.Enum.Workshop.Class.Status.Cancelled;
            await _unitOfWork.WorkshopClassRepository.Update(entity);
        }

        public async Task<bool> CheckPassEndRegistrationDay(int workshopClassDetailId, DateOnly compareDate)
        {
            var workshop = await _unitOfWork.WorkshopClassRepository.GetFirst(c => c.WorkshopClassDetails.Any(e => e.Id == workshopClassDetailId)
                                                                                , nameof(WorkshopClass.WorkshopClassDetails));
            if(compareDate.ToDateTime(new TimeOnly()) <= workshop.RegisterEndDate)
            {
                return false;
            }
            return true;
        }
        public async Task CompleteWorkshopClass(int workshopClassId)
        {
            //26-10-2023 - TrungNT - Add Start
            var entity = await _unitOfWork.WorkshopClassRepository.GetFirst(c => c.Id == workshopClassId);
            if (entity.Status != (int)Models.Enum.Workshop.Class.Status.OnGoing)
            {
                throw new InvalidOperationException("This workshop class has not started!");
            }                        
            entity.Status = (int)Models.Enum.Workshop.Class.Status.Completed;
            await _unitOfWork.WorkshopClassRepository.Update(entity);
            //26-10-2023 - TrungNT - Add End
        }
    }
}
