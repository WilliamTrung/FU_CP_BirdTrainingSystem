using AppRepository.UnitOfWork;
using AutoMapper;
using Models.ConfigModels;
using Models.Entities;
using Models.Enum.Workshop.Class;
using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.Feedback;
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
                                                                           && c.Status == (int)Models.Enum.Workshop.Class.Status.OpenRegistration
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
                entity.Status = (int)Models.Enum.Workshop.Class.Status.ClosedRegistration;
                await _unitOfWork.WorkshopClassRepository.Update(entity);
                return true;
            }
            return false;
        }

        public async Task SetWorkshopClassOngoing()
        {
            var entities = await _unitOfWork.WorkshopClassRepository.Get(c => DateTime.Now > c.RegisterEndDate
                                                                            && (c.Status == (int)Models.Enum.Workshop.Class.Status.ClosedRegistration
                                                                                || c.Status == (int)Models.Enum.Workshop.Class.Status.OpenRegistration)
                                                                            , nameof(WorkshopClass.WorkshopClassDetails)
                                                                            , $"{nameof(WorkshopClass.WorkshopClassDetails)}.{nameof(WorkshopClassDetail.DaySlot)}");                                                                           
             foreach (var entity in entities)
            {
                var firstSlot = entity.WorkshopClassDetails.First().DaySlot;
                if(firstSlot == null)
                {
                    //do nothing
                } else if(DateTime.Now > firstSlot.Date)
                {
                    entity.Status = (int)Models.Enum.Workshop.Class.Status.OnGoing;
                    await _unitOfWork.WorkshopClassRepository.Update(entity);
                }
            }            
        }

        public async Task SetWorkshopClassComplete()
        {
            var entities = await _unitOfWork.WorkshopClassRepository.Get(c => c.Status == (int)Models.Enum.Workshop.Class.Status.OnGoing
                                                                            ,nameof(WorkshopClass.WorkshopClassDetails)
                                                                            , $"{nameof(WorkshopClass.WorkshopClassDetails)}.{nameof(WorkshopClassDetail.DaySlot)}"
                                                                            , $"{nameof(WorkshopClass.WorkshopClassDetails)}.{nameof(WorkshopClassDetail.DaySlot)}.{nameof(TrainerSlot.Slot)}");
            foreach (var entity in entities)
            {
                var lastSlot = entity.WorkshopClassDetails.Last();
                var endHour = lastSlot.DaySlot.Slot.EndTime;
                var endTime = lastSlot.DaySlot.Date.Add((TimeSpan)endHour).AddHours(24);
                if(DateTime.Now > endTime)
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
            var entities = await _unitOfWork.WorkshopClassRepository.Get(c => c.Status == (int)Models.Enum.Workshop.Class.Status.Pending 
                                                                            && c.StartTime < DateTime.Now);
            foreach (var entity in entities)
            {
                entity.Status = (int)Models.Enum.Workshop.Class.Status.OpenRegistration;
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

        public async Task<WorkshopClassViewModel> GetWorkshopClass(int workshopClassId)
        {
            var entity = await _unitOfWork.WorkshopClassRepository.GetFirst(c => c.Id == workshopClassId
                                                                          && c.Workshop.Status != (int)Models.Enum.Workshop.Status.Inactive
                                                                          , nameof(WorkshopClass.WorkshopClassDetails)
                                                                          , nameof(WorkshopClass.Workshop)
                                                                          , $"{nameof(WorkshopClass.WorkshopClassDetails)}.{nameof(WorkshopClassDetail.DaySlot)}"
                                                                          , $"{nameof(WorkshopClass.WorkshopClassDetails)}.{nameof(WorkshopClassDetail.DaySlot)}.{nameof(TrainerSlot.Trainer)}");
            var model = _mapper.Map<WorkshopClassViewModel>(entity);
            return model;
        }

        public async Task<List<FeedbackWorkshopCustomerViewModel>> GetFeedbacks(int workshopId)
        {
            var entities = await _unitOfWork.FeedbackRepository.Get(c =>  c.EntityTypeId == (int)Models.Enum.EntityType.WorkshopClass
                                                                          && c.EntityId == workshopId
                                                                          , nameof(Feedback.Customer)
                                                                          , $"{nameof(Feedback.Customer)}.{nameof(Customer.MembershipRank)}"
                                                                          , $"{nameof(Feedback.Customer)}.{nameof(Customer.User)}");
            var result = _mapper.Map<List<FeedbackWorkshopCustomerViewModel>>(entities);
            return result;  
        }

        public async Task<float> GetRating(int workshopId)
        {
            var entities = await _unitOfWork.FeedbackRepository.Get(c => c.EntityTypeId == (int)Models.Enum.EntityType.WorkshopClass
                                                                          && c.EntityId == workshopId
                                                                          && c.Rating != null);
            float rating = 0;
            int count = 0;
            entities.ToList().ForEach(e =>
            {
                if (e.Rating.HasValue)
                {
                    rating += e.Rating.Value;
                    count++;
                }                
            });
            return rating/=count;
            
        }

        public async Task SetClassCloseRegistrationOnFull(int workshopClassId)
        {
            var entities = await _unitOfWork.WorkshopClassRepository.Get(c => c.Id == workshopClassId 
                                                                            && c.Status == (int)Models.Enum.Workshop.Class.Status.OpenRegistration);

        }

        public async Task<Status> GetClassStatus(int workshopClassDetailId)
        {
            var classSlot = await _unitOfWork.WorkshopClassDetailRepository.GetFirst(c => c.Id == workshopClassDetailId, nameof(WorkshopClassDetail.WorkshopClass));
            if(classSlot == null)
            {
                throw new KeyNotFoundException();
            }
            return (Status)classSlot.WorkshopClass.Status;
        }
    }
}
