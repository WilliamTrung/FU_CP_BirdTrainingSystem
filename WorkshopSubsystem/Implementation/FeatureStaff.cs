using AppRepository.UnitOfWork;
using AutoMapper;
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
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var entities = await _unitOfWork.WorkshopClassDetailRepository.Get(c => c.Id == workshopClassDetailId
                                                                                && CustomDateFunctions.CompareDate(c.DaySlot.Date, current.DaySlot.Date) <= 0                                                                                
                                                                                , nameof(WorkshopClassDetail.DaySlot));
            var minDate = entities.Min(c => c.DaySlot.Date);
            var minRecords = entities.Where(c => c.DaySlot.Date == minDate);
            minRecords = minRecords.Where(c => c.DaySlot.SlotId > current.DaySlot.SlotId);
            var result = minRecords.OrderBy(c => c.DaySlot.SlotId).First();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return _mapper.Map<WorkshopClassDetailViewModel>(result);
        }
        public async Task<WorkshopClassDetailViewModel?> GetFollowingWorkshopClassDetail(int workshopClassDetailId)
        {
            var current = await _unitOfWork.WorkshopClassDetailRepository.GetFirst(c => c.Id == workshopClassDetailId, nameof(WorkshopClassDetail.DaySlot));
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var entities = await _unitOfWork.WorkshopClassDetailRepository.Get(c => c.Id == workshopClassDetailId
                                                                                && CustomDateFunctions.CompareDate(c.DaySlot.Date, current.DaySlot.Date) >= 0
                                                                                , nameof(WorkshopClassDetail.DaySlot));
            var maxDate = entities.Max(c => c.DaySlot.Date);
            var minRecords = entities.Where(c => c.DaySlot.Date == maxDate);
            minRecords = minRecords.Where(c => c.DaySlot.SlotId < current.DaySlot.SlotId);
            var result = minRecords.OrderByDescending(c => c.DaySlot.SlotId).First();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return _mapper.Map<WorkshopClassDetailViewModel>(result);
        }

        public async Task<IEnumerable<WorkshopClassAdminViewModel>> GetWorkshopClassAdminViewModels(int workshopId)
        {
            var entities = await _unitOfWork.WorkshopClassRepository.Get(c => c.WorkshopId == workshopId 
                                                                           && c.Status != (int)Models.Enum.Workshop.Class.Status.Cancel);
            var models = _mapper.Map<List<WorkshopClassAdminViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<WorkshopClassDetailViewModel>> GetWorkshopClassDetailViewModels(int workshopClassId)
        {
            var entities = await _unitOfWork.WorkshopClassDetailRepository.Get(c => c.WorkshopClassId == workshopClassId 
                                                                                 && c.WorkshopClass.Status != (int)Models.Enum.Workshop.Class.Status.Cancel
                                                                                 , nameof(WorkshopClassDetail.DaySlot), nameof(WorkshopClassDetail.WorkshopClass));
            var models = _mapper.Map<List<WorkshopClassDetailViewModel>>(entities);
            return models;
        }

        public async Task ModifyWorkshopClassDetailSlotOnly(WorkshopClassDetailTrainerSlotOnlyModifyModel workshopClass)
        {
            var entity = await _unitOfWork.WorkshopClassDetailRepository.GetFirst(c => c.Id == workshopClass.Id
                                                                                    && c.WorkshopClass.Status != (int)Models.Enum.Workshop.Class.Status.Cancel
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
                                                                                    && c.WorkshopClass.Status != (int)Models.Enum.Workshop.Class.Status.Cancel
                                                                                    , nameof(WorkshopClassDetail.DaySlot)
                                                                                    , nameof(WorkshopClassDetail.WorkshopClass));
            if(entity == null)
            {
                throw new KeyNotFoundException($"{typeof(WorkshopClassDetail)} not found at id: {workshopClass.Id}");
            }
            if(entity.DaySlot == null)
            {
                throw new ArgumentNullException(nameof(entity.DaySlot));    
            }
            entity.DaySlot.TrainerId = workshopClass.TrainerId;
            entity.DaySlot.SlotId = workshopClass.SlotId;
            entity.DaySlot.Date = workshopClass.Date.ToDateTime(new TimeOnly(0,0,0));
            await _unitOfWork.WorkshopClassDetailRepository.Update(entity);
        }

        
    }
}
