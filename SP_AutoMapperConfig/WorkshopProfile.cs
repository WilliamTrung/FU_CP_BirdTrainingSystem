using AutoMapper;
using Models.Entities;
using Models.ServiceModels.WorkshopModels;
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
        }
        private void Map_WorkshopRefundPolicy_WorkshopRefundPolicyModel()
        {
            CreateMap<WorkshopRefundPolicy, WorkshopRefundPolicyModel>();
        }
        private void Map_WorkshopClass_WorkshopClassViewModel()
        {

        }        
        private void Map_WorkshopClassDetailTemplate_WorkshopClassDetailTemplateViewModel()
        {
            CreateMap<WorkshopDetailTemplate, WorkshopDetailTemplateViewModel>();
        }
        private void Map_WorkshopClass_WorkshopClassAdminViewModel()
        {
            CreateMap<WorkshopClass, WorkshopClassAdminViewModel>();                
        }
        private void Map_WorkshopClassAddModel_WorkshopClass()
        {
            CreateMap<WorkshopClassAddModel, WorkshopClass>()
                .ForMember(e => e.StartTime, opt => opt.MapFrom(c => c.StartTime))
                .ForMember(e => e.WorkshopId, opt => opt.MapFrom(c => c.WorkshopId));
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
                .ForMember(m => m, opt =>
                {
                    opt.PreCondition(e => e.DaySlot != null && e.WorkshopDetailTemplate != null);
                    opt.MapFrom<Map_WorkshopClassDetail_WorkshopClassDetailViewModel_Resolver>();
                });
        }
        private void Map_WorkshopAddModel_Workshop()
        {
            CreateMap<WorkshopAddModel, Workshop>()
                .ForMember(e => e, opt => opt.MapFrom<Map_WorkshopAddModel_Workshop_Resolver>());                
        }
    }
    public class Map_WorkshopAddModel_Workshop_Resolver : IValueResolver<WorkshopAddModel, Workshop, Workshop>
    {
        public Workshop Resolve(WorkshopAddModel source, Workshop destination, Workshop destMember, ResolutionContext context)
        {
            destination.Picture = source.Picture;
            destination.Status = (int)Models.Enum.Workshop.Status.Active;
            destination.WorkshopRefundPolicyId = 1;
            destination.Description = source.Description;
            destination.Price = source.Price;
            destination.Title = source.Title;
            destination.TotalSlot = source.TotalSlot;
            destination.RegisterEnd = source.RegisterEnd;
            return destination;
        }
    }

    public class Map_WorkshopClassDetail_WorkshopClassDetailViewModel_Resolver : IValueResolver<WorkshopClassDetail, WorkshopClassDetailViewModel, WorkshopClassDetailViewModel>
    {
        private readonly IMapper _mapper;
        public Map_WorkshopClassDetail_WorkshopClassDetailViewModel_Resolver(IMapper mapper)
        {
            _mapper = mapper;
        }
        public WorkshopClassDetailViewModel Resolve(WorkshopClassDetail source, WorkshopClassDetailViewModel destination, WorkshopClassDetailViewModel destMember, ResolutionContext context)
        {
            
            destination.Detail = source.WorkshopDetailTemplate.Detail;
            destination.Id = source.Id;
#pragma warning disable CS8629 // Nullable value type may be null.
            destination.Trainer = _mapper.Map<TrainerWorkshopModel>(source.DaySlot.Trainer);
            destination.Date = (DateTime)source.DaySlot.Date;
            destination.StartTime = (TimeSpan)source.DaySlot.Slot.StartTime;
            destination.EndTime = (TimeSpan)source.DaySlot.Slot.EndTime;
#pragma warning restore CS8629 // Nullable value type may be null.
            return destination;
        }
    }
}
