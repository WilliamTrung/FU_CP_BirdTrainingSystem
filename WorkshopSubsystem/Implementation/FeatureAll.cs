using AppRepository.UnitOfWork;
using AutoMapper;
using Models.ConfigModels;
using Models.Entities;
using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using SP_Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem.Implementation
{
    public class FeatureAll : IFeatureAll
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        public FeatureAll(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<WorkshopClassViewModel>> GetClassesByWorkshopId(int workshopId)
        {
            var entities = await _unitOfWork.WorkshopClassRepository.Get(c => c.WorkshopId == workshopId
                                                                           && c.Workshop.Status != (int)Models.Enum.Workshop.Status.Inactive
                                                                           , nameof(WorkshopClass.WorkshopClassDetails)
                                                                           , nameof(WorkshopClass.Workshop)
                                                                           , $"{nameof(WorkshopClass.WorkshopClassDetails)}.{nameof(WorkshopClassDetail.DaySlot)}"
                                                                           , $"{nameof(WorkshopClass.WorkshopClassDetails)}.{nameof(WorkshopClassDetail.DaySlot)}.{nameof(TrainerSlot.Trainer)}");
            var models = _mapper.Map<List<WorkshopClassViewModel>>(entities);
            return models;
        }

        public async Task<WorkshopClassDetailViewModel> GetWorkshopClassDetail(int workshopClassDetailId)
        {
            var entity = await _unitOfWork.WorkshopClassDetailRepository.GetFirst(c => c.Id == workshopClassDetailId
                                                                                    && c.WorkshopClass.Workshop.Status != (int)Models.Enum.Workshop.Status.Inactive
                                                                                    , nameof(WorkshopClassDetail.DaySlot)
                                                                                    , nameof(WorkshopClassDetail.WorkshopDetailTemplate));
            var model = _mapper.Map<WorkshopClassDetailViewModel>(entity);
            return model;
        }

        public async Task<IEnumerable<WorkshopClassDetailViewModel>> GetWorkshopClassDetailOnWorkshopClass(int workshopClassId)
        {
            var entities = await _unitOfWork.WorkshopClassDetailRepository.Get(c => c.WorkshopClassId == workshopClassId 
                                                                                 && c.WorkshopClass.Workshop.Status != (int)Models.Enum.Workshop.Status.Inactive
                                                                                 , nameof(WorkshopClassDetail.DaySlot)
                                                                                 , nameof(WorkshopClassDetail.WorkshopDetailTemplate));
            entities = entities.OrderBy(c => c.Id);
            var models = _mapper.Map<List<WorkshopClassDetailViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<WorkshopModel>> GetWorkshopGeneralInformation()
        {            
            var entities = await _unitOfWork.WorkshopRepository.Get(c => c.Status != (int)Models.Enum.Workshop.Status.Inactive);
            var models = _mapper.Map<IEnumerable<WorkshopModel>>(entities);
            return models;
        }
        public async Task<IEnumerable<WorkshopRefundPolicyModel>> GetRefundPolicies()
        {
            var entities = await _unitOfWork.WorkshopRefundPolicyRepository.Get();
            var models = _mapper.Map<List<WorkshopRefundPolicyModel>>(entities);
            return models;
        }

        public async Task<bool> SetWorkshopClassFull(int workshopClassId)
        {
            var entity = await _unitOfWork.WorkshopClassRepository.GetFirst(c => c.Id == workshopClassId);
            var registered = await _unitOfWork.CustomerWorkshopClassRepository.Get(c => c.WorkshopClassId == workshopClassId && c.Status == (int)Models.Enum.Workshop.Transaction.Status.Paid);
            if(registered.Count() == BR_WorkshopConstant.MaximumRegisteredCustomer)
            {
                entity.Status = (int)Models.Enum.Workshop.Class.Status.OpenRegistration;
                await _unitOfWork.WorkshopClassRepository.Update(entity);
                return true;
            }
            return false;
        }

        public async Task SetWorkshopClassOngoing()
        {
            var entities = await _unitOfWork.WorkshopClassRepository.Get(c => c.RegisterEndDate >= DateTime.Now && (c.Status == (int)Models.Enum.Workshop.Class.Status.OpenRegistration || c.Status == (int)Models.Enum.Workshop.Class.Status.ClosedRegistration));
            foreach (var entity in entities)
            {
                entity.Status = (int)Models.Enum.Workshop.Class.Status.OnGoing;
                await _unitOfWork.WorkshopClassRepository.Update(entity);
            }            
        }

        public async Task SetWorkshopClassComplete()
        {
            var entities = await _unitOfWork.WorkshopClassRepository.Get(c => c.Status == (int)Models.Enum.Workshop.Class.Status.OnGoing);
            foreach (var entity in entities)
            {
                var lastSlot = await GetLastSlotOfWorkshopClass(entity.Id);
                if(lastSlot.Date.ToDateOnly() == DateTime.Now.ToDateOnly() && lastSlot.Slot.EndTime > DateTime.Now.TimeOfDay)
                {
                    entity.Status = (int)Models.Enum.Workshop.Class.Status.Completed;
                    await _unitOfWork.WorkshopClassRepository.Update(entity);
                }
            }
        }
        private async Task<TrainerSlot> GetLastSlotOfWorkshopClass(int workshopClassId)
        {
            var slots = await _unitOfWork.TrainerSlotRepository.Get(c => c.EntityId == workshopClassId && c.EntityTypeId == (int)Models.Enum.EntityType.WorkshopClass, nameof(TrainerSlot.Slot));
            var lastSlot = slots.Last();
            return lastSlot;
        }

        public async Task SetWorkshopClassExceedRegistration()
        {
            var entities = await _unitOfWork.WorkshopClassRepository.Get(c => c.Status == (int)Models.Enum.Workshop.Class.Status.Pending 
                                                                        && c.RegisterEndDate < DateTime.Now.Date);
            foreach (var entity in entities)
            {
                entity.Status = (int)Models.Enum.Workshop.Class.Status.Cancelled;
                await _unitOfWork.WorkshopClassRepository.Update(entity);
            }
        }

        public async Task SetWorkshopClassOpenRegistration()
        {
            var entities = await _unitOfWork.WorkshopClassRepository.Get(c => c.Status == (int)Models.Enum.Workshop.Class.Status.Pending);
            foreach (var entity in entities)
            {
                entity.Status = (int)Models.Enum.Workshop.Class.Status.Cancelled;
                await _unitOfWork.WorkshopClassRepository.Update(entity);
            }
        }

        public async Task<RegistrationAmountModel> GetRegistrationAmount(int workshopClassId)
        {
            var entity = await _unitOfWork.WorkshopClassRepository.GetFirst(c => c.Id == workshopClassId);
            var registered = await _unitOfWork.CustomerWorkshopClassRepository.Get(c => c.WorkshopClassId == workshopClassId && c.Status == (int)Models.Enum.Workshop.Transaction.Status.Paid);
            var result = new RegistrationAmountModel()
            {
                Registered = registered.Count()
            };
            return result;
        }
    }
}
