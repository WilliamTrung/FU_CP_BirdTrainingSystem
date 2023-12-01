using AppRepository.UnitOfWork;
using AutoMapper;
using Models.ApiParamModels.Workshop;
using Models.Entities;
using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.CustomerRegister;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class WorkshopProfile : Profile
    {        
        public WorkshopProfile() {
            Map_WorkshopAddModel_Workshop();
            Map_WorkshopClassDetail_WorkshopDetailViewModel();
            Map_WorkshopDetailTemplateAddModel_WorkshopDetailTemplate();
            Map_WorkshopRefundPolicy_WorkshopRefundPolicyModel();
            Map_WorkshopClass_WorkshopClassAdminViewModel();
            Map_WorkshopClassDetailTemplate_WorkshopClassDetailTemplateViewModel();
            Map_WorkshopClassAddModel_WorkshopClass();
            Map_Workshop_WorkshopModel();
            Map_Workshop_WorkshopAdminModel();
            Map_WorkshopClassDetailTrainerSlotModifyModel_TrainerSlot();
            Map_WorkshopClass_WorkshopClassViewModel();
            Map_WorkshopAttendance_RegisteredCustomerModel();
            Map_WorkshopClassDetail_WorkshopClassDetailTrainerViewModel();
        }
        private void Map_WorkshopAttendance_RegisteredCustomerModel()
        {
            CreateMap<WorkshopAttendance, RegisteredCustomerModel>()
                .AfterMap<MappingAction_WorkshopAttendance_RegisterCustomerModel>();
        }
        private void Map_WorkshopClassDetailTrainerSlotModifyModel_TrainerSlot()
        {
            CreateMap<WorkshopClassDetailTrainerSlotModifyModel, TrainerSlot>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.SlotId, opt => opt.MapFrom(m => m.SlotId))
                .ForMember(e => e.Date, opt => opt.MapFrom(m => m.Date.ToDateTime(new TimeOnly(0,0,0))))
                .ForMember(e => e.TrainerId, opt => opt.MapFrom(m => m.TrainerId))
                .ForMember(e => e.Status, opt => opt.MapFrom(m => (int)Models.Enum.TrainerSlotStatus.Enabled))
                .ForMember(e => e.EntityId, opt => opt.MapFrom(m => m.ClassId))
                .ForMember(e => e.EntityTypeId, opt => opt.MapFrom(m => (int)Models.Enum.EntityType.WorkshopClass))
                .ForMember(e => e.Reason, opt => opt.MapFrom(m => "Host workshop class slot"));
        }
        private void Map_WorkshopClassDetail_WorkshopClassDetailTrainerViewModel()
        {
            CreateMap<WorkshopClassDetail, WorkshopClassDetailTrainerViewModel>()
              //.ForMember(m => m, opt =>
              //{
              //    opt.PreCondition(e => e.DaySlot != null && e.WorkshopDetailTemplate != null);
              //    opt.MapFrom<Map_WorkshopClassDetail_WorkshopClassDetailViewModel_Resolver>();
              //})
              .AfterMap<MappingAction_WorkshopClassDetail_WorkshopClassDetailTrainerViewModel>();
        }
        private void Map_Workshop_WorkshopAdminModel()
        {
            CreateMap<Workshop, WorkshopAdminModel>()
                .ForMember(c => c.Status, opt => opt.MapFrom(e => e.Status));
        }
        private void Map_WorkshopRefundPolicy_WorkshopRefundPolicyModel()
        {
            CreateMap<WorkshopRefundPolicy, WorkshopRefundPolicyModel>();
        }
        private void Map_Workshop_WorkshopModel()
        {
            CreateMap<Workshop, WorkshopModel>();
        }
        private void Map_WorkshopClass_WorkshopClassViewModel()
        {
            CreateMap<WorkshopClass, WorkshopClassViewModel>()
                .AfterMap<MappingAction_WorkshopClass_WorkshopClassViewmModel>();
        }        
        private void Map_WorkshopClassDetailTemplate_WorkshopClassDetailTemplateViewModel()
        {
            CreateMap<WorkshopDetailTemplate, WorkshopDetailTemplateViewModel>();
        }
        private void Map_WorkshopClass_WorkshopClassAdminViewModel()
        {
            CreateMap<WorkshopClass, WorkshopClassAdminViewModel>()
                .ForMember(m => m.MinimumRegistration, opt =>
                {
                    opt.PreCondition(e => e.Workshop != null);
                    opt.MapFrom(e => e.Workshop.MinimumRegistration);
                });                
        }
        private void Map_WorkshopClassAddModel_WorkshopClass()
        {
            CreateMap<WorkshopClassAddModel, WorkshopClass>()
                .ForMember(e => e.StartTime, opt => opt.MapFrom(c => c.StartTime.ToDateTime(new TimeOnly(0, 0, 0))))
                .ForMember(e => e.WorkshopId, opt => opt.MapFrom(c => c.WorkshopId))
                .ForMember(e => e.Status, opt => opt.MapFrom(c => (int)Models.Enum.Workshop.Class.Status.Pending));
        }
        private void Map_WorkshopDetailTemplateAddModel_WorkshopDetailTemplate()
        {
            CreateMap<WorkshopDetailTemplateAddModel, WorkshopDetailTemplate>();
        }
        private void Map_WorkshopClassDetail_WorkshopDetailViewModel()
        {
            CreateMap<Trainer, TrainerWorkshopModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(m => m.Name, opt => {
                    opt.PreCondition(e => e.User != null);                              
                    opt.MapFrom(e => e.User.Name);
                })
                .ForMember(m => m.Email, opt => {
                    opt.PreCondition(e => e.User != null);
                    opt.MapFrom(e => e.User.Email);
                })
                .ForMember(m => m.Avatar, opt => {
                    opt.PreCondition(e => e.User != null);
                    opt.MapFrom(e => e.User.Avatar);
                });
            CreateMap<WorkshopClassDetail, WorkshopClassDetailViewModel>()
                //.ForMember(m => m, opt =>
                //{
                //    opt.PreCondition(e => e.DaySlot != null && e.WorkshopDetailTemplate != null);
                //    opt.MapFrom<Map_WorkshopClassDetail_WorkshopClassDetailViewModel_Resolver>();
                //})
                .AfterMap<MappingAction_WorkshopClassDetail_WorkshopClassDetailViewModel>();
        }
        private void Map_WorkshopAddModel_Workshop()
        {
            CreateMap<WorkshopAddModel, Workshop>()
                //.ForMember(e => e, opt => opt.MapFrom<Map_WorkshopAddModel_Workshop_Resolver>());                
                .AfterMap<MappingAction_WorkshopAddModel_Workshop>();
        }
    }
    //public class Map_WorkshopAddModel_Workshop_Resolver : IValueResolver<WorkshopAddModel, Workshop, Workshop>
    //{
    //    public Workshop Resolve(WorkshopAddModel source, Workshop destination, Workshop destMember, ResolutionContext context)
    //    {
    //        destination.Picture = source.Picture;
    //        destination.Status = (int)Models.Enum.Workshop.Status.Active;
    //        destination.WorkshopRefundPolicyId = 1;
    //        destination.Description = source.Description;
    //        destination.Price = source.Price;
    //        destination.Title = source.Title;
    //        destination.TotalSlot = source.TotalSlot;
    //        destination.RegisterEnd = source.RegisterEnd;
    //        return destination;
    //    }
    //}
    public class MappingAction_WorkshopAddModel_Workshop : IMappingAction<WorkshopAddModel, Workshop>
    {
        private readonly IMapper _mapper;
        public MappingAction_WorkshopAddModel_Workshop(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void Process(WorkshopAddModel source, Workshop destination, ResolutionContext context)
        {
            destination.Picture = source.Picture;
            destination.Status = (int)Models.Enum.Workshop.Status.Inactive;
            destination.Location = source.Location;
            destination.MinimumRegistration = source.MinimumRegistration;
            destination.MaximumRegistration = source.MaximumRegistration;
            //destination.WorkshopRefundPolicyId = 1;
            destination.Description = source.Description;
            destination.Price = source.Price;
            destination.Title = source.Title;
            destination.TotalSlot = source.TotalSlot;
            destination.RegisterEnd = source.RegisterEnd;
        }
    }

    //    public class Map_WorkshopClassDetail_WorkshopClassDetailViewModel_Resolver : IValueResolver<WorkshopClassDetail, WorkshopClassDetailViewModel, WorkshopClassDetailViewModel>
    //    {
    //        private readonly IMapper _mapper;
    //        public Map_WorkshopClassDetail_WorkshopClassDetailViewModel_Resolver(IMapper mapper)
    //        {
    //            _mapper = mapper;
    //        }
    //        public WorkshopClassDetailViewModel Resolve(WorkshopClassDetail source, WorkshopClassDetailViewModel destination, WorkshopClassDetailViewModel destMember, ResolutionContext context)
    //        {

    //            destination.Detail = source.WorkshopDetailTemplate.Detail;
    //            destination.Id = source.Id;
    //#pragma warning disable CS8629 // Nullable value type may be null.
    //            destination.Trainer = _mapper.Map<TrainerWorkshopModel>(source.DaySlot.Trainer);
    //            destination.Date = (DateTime)source.DaySlot.Date;
    //            destination.StartTime = (TimeSpan)source.DaySlot.Slot.StartTime;
    //            destination.EndTime = (TimeSpan)source.DaySlot.Slot.EndTime;
    //#pragma warning restore CS8629 // Nullable value type may be null.
    //            return destination;
    //        }
    //    }
    public class MappingAction_WorkshopClassDetail_WorkshopClassDetailViewModel : IMappingAction<WorkshopClassDetail, WorkshopClassDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public MappingAction_WorkshopClassDetail_WorkshopClassDetailViewModel(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }
        public void Process(WorkshopClassDetail source, WorkshopClassDetailViewModel destination, ResolutionContext context)
        {
            destination.Detail = source.WorkshopDetailTemplate.Detail;
            destination.Id = source.Id;
#pragma warning disable CS8629 // Nullable value type may be null.
            if(source.DaySlotId == null)
            {
                //not yet assign trainer
                destination.Trainer = null;
                destination.Date = null;
                
            } else
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                source.DaySlot = _uow.TrainerSlotRepository.GetFirst(c => c.Id == source.DaySlotId
                                                                        , nameof(TrainerSlot.Trainer)
                                                                        , nameof(TrainerSlot.Slot)
                                                                        , $"{nameof(TrainerSlot.Trainer)}.{nameof(Trainer.User)}").Result;
#pragma warning restore CS8601 // Possible null reference assignment.
                destination.Trainer = _mapper.Map<TrainerWorkshopModel>(source.DaySlot.Trainer);
                destination.Date = (DateTime)source.DaySlot.Date;
                destination.StartTime = (TimeSpan)source.DaySlot.Slot.StartTime;
                destination.EndTime = (TimeSpan)source.DaySlot.Slot.EndTime;
            }
#pragma warning restore CS8629 // Nullable value type may be null.
        }
    }
    public class MappingAction_WorkshopClassDetail_WorkshopClassDetailTrainerViewModel : IMappingAction<WorkshopClassDetail, WorkshopClassDetailTrainerViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public MappingAction_WorkshopClassDetail_WorkshopClassDetailTrainerViewModel(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }
        public void Process(WorkshopClassDetail source, WorkshopClassDetailTrainerViewModel destination, ResolutionContext context)
        {
            destination.Detail = source.WorkshopDetailTemplate.Detail;
            destination.Id = source.Id;
#pragma warning disable CS8629 // Nullable value type may be null.
            destination.Title = source.WorkshopClass.Workshop.Title;
            if (source.DaySlotId == null)
            {
                //not yet assign trainer
                destination.Trainer = null;
                destination.Date = null;

            }
            else
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                source.DaySlot = _uow.TrainerSlotRepository.GetFirst(c => c.Id == source.DaySlotId
                                                                        , nameof(TrainerSlot.Trainer)
                                                                        , nameof(TrainerSlot.Slot)
                                                                        , $"{nameof(TrainerSlot.Trainer)}.{nameof(Trainer.User)}").Result;
#pragma warning restore CS8601 // Possible null reference assignment.
                destination.Trainer = _mapper.Map<TrainerWorkshopModel>(source.DaySlot.Trainer);
                destination.Date = (DateTime)source.DaySlot.Date;
                destination.StartTime = (TimeSpan)source.DaySlot.Slot.StartTime;
                destination.EndTime = (TimeSpan)source.DaySlot.Slot.EndTime;
            }
#pragma warning restore CS8629 // Nullable value type may be null.
        }
    }
    public class MappingAction_WorkshopClass_WorkshopClassViewmModel: IMappingAction<WorkshopClass, WorkshopClassViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public MappingAction_WorkshopClass_WorkshopClassViewmModel(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }
        public void Process(WorkshopClass source, WorkshopClassViewModel destination, ResolutionContext context)
        {
            destination.StartTime = source.StartTime.Value;
            destination.RegisterEndDate = source.RegisterEndDate.Value;
            destination.WorkshopId = source.WorkshopId;
            destination.Status = null;
            destination.ClassStatus = (Models.Enum.Workshop.Class.Status)source.Status;
            destination.Location = source.Workshop.Location;
            destination.MinimumRegistration = source.Workshop.MinimumRegistration;            
            destination.Id = source.Id;
            foreach (var detail in source.WorkshopClassDetails)
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                detail.WorkshopDetailTemplate = _uow.WorkshopDetailTemplateRepository.GetFirst(c => c.Id == detail.DetailId).Result;
#pragma warning restore CS8601 // Possible null reference assignment.
            }
            destination.ClassSlots = _mapper.Map<List<WorkshopClassDetailViewModel>>(source.WorkshopClassDetails);

        }
    }
    public class MappingAction_WorkshopAttendance_RegisterCustomerModel : IMappingAction<WorkshopAttendance, RegisteredCustomerModel>
    {
        public void Process(WorkshopAttendance source, RegisteredCustomerModel destination, ResolutionContext context)
        {
            destination.Avatar = source.Customer.User.Avatar;
            destination.CustomerId = source.CustomerId;
            destination.PhoneNumber = source.Customer.User.PhoneNumber.ToString();
            destination.CustomerName = source.Customer.User.Name;
            destination.Email = source.Customer.User.Email;
            destination.Status = (Models.Enum.Workshop.Class.Customer.Status)source.Status;
            destination.WorkshopClassDetailId = source.WorkshopClassDetailId;
        }
    }
}
