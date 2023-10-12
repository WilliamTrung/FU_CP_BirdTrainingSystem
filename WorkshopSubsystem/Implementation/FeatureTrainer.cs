using AppRepository.UnitOfWork;
using AutoMapper;
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
    public class FeatureTrainer : FeatureAll, IFeatureTrainer
    {
        public FeatureTrainer(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<WorkshopClassDetailViewModel>> GetAssignedWorkshopClassDetails(int trainerId, int workshopClassId)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var entities = await _unitOfWork.WorkshopClassDetailRepository.Get(c => c.WorkshopClassId == workshopClassId 
                                                                                 && c.DaySlot.TrainerId == trainerId 
                                                                                 && c.DaySlot.Status == (int)Models.Enum.TrainerSlotStatus.Enabled
                                                                                 && c.WorkshopClass.Status != (int)Models.Enum.Workshop.Class.Status.Cancel
                                                                                 , nameof(WorkshopClassDetail.DaySlot)
                                                                                 , nameof(WorkshopClassDetail.WorkshopClass));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            var models = _mapper.Map<List<WorkshopClassDetailViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<WorkshopClassAdminViewModel>> GetAssignedWorkshopClasses(int trainerId, int workshopId)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var details = await _unitOfWork.WorkshopClassDetailRepository.Get(c => c.DaySlot.TrainerId == trainerId 
                                                                                && c.WorkshopClass.Status != (int)Models.Enum.Workshop.Class.Status.Cancel
                                                                                , nameof(WorkshopClassDetail.DaySlot)
                                                                                , nameof(WorkshopClassDetail.WorkshopClass));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            details = details.DistinctBy(c => c.WorkshopClassId);
            var workshopClasses = await _unitOfWork.WorkshopClassRepository.Get(c => details.Any(detail => detail.WorkshopClassId == c.Id)
                                                                                  && c.Id == workshopId);
            var models = _mapper.Map<List<WorkshopClassAdminViewModel>>(workshopClasses);
            return models;
        }

        public async Task<IEnumerable<WorkshopModel>> GetAssignedWorkshops(int trainerId)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var details = await _unitOfWork.WorkshopClassDetailRepository.Get(c => c.DaySlot.TrainerId == trainerId
                                                                                && c.WorkshopClass.Status != (int)Models.Enum.Workshop.Class.Status.Cancel
                                                                                , nameof(WorkshopClassDetail.DaySlot)
                                                                                , nameof(WorkshopClassDetail.WorkshopClass));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            details = details.DistinctBy(c => c.WorkshopClassId);
            var workshopClasses = await _unitOfWork.WorkshopClassRepository.Get(c => details.Any(detail => detail.WorkshopClassId == c.Id), nameof(WorkshopClass.Workshop));
            workshopClasses = workshopClasses.DistinctBy(c => c.WorkshopId);
            var models = _mapper.Map<List<WorkshopModel>>(workshopClasses.Select(c => c.Workshop));
            return models;
        }

        public async Task ModifyWorkshopClassSlotDetail(WorkshopClassDetailModifyModel workshopClass)
        {
            var entity = await _unitOfWork.WorkshopClassDetailRepository.GetFirst(c => c.Id == workshopClass.Id
                                                                                    && c.WorkshopClass.Status != (int)Models.Enum.Workshop.Class.Status.Cancel
                                                                                    , nameof(WorkshopClassDetail.WorkshopClass));
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(workshopClass)} is not found at id: {workshopClass.Id}");
            }
            entity.Detail = workshopClass.Detail;
            await _unitOfWork.WorkshopClassDetailRepository.Update(entity);
        }

    }
}
