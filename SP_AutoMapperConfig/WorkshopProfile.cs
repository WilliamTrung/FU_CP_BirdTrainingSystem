using AutoMapper;
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
            SetWorkshopMapping();
            SetClassMapping();
        }
        private void SetClassMapping()
        {            
            CreateMap<Models.Entities.WorkshopClass, Models.ServiceModels.WorkshopModels.WorkshopClass.ClassViewModel>()
                .ForMember(model => model.Status, option => option.MapFrom(entity => entity.Status.HasValue ? entity.Status : 0))
                .ForMember(model => model.Title, option => option.MapFrom(entity => entity.Workshop.Title))
                .ForMember(model => model.Description, option => option.MapFrom(entity => entity.Workshop.Description))
                .ForMember(model => model.Picture, option => option.MapFrom(entity => entity.Workshop.Picture))
                .ForMember(model => model.ClassSlots, opt => {
                    opt.PreCondition(e => e.WorkshopClassDetails != null);
                    opt.MapFrom(entity => entity.WorkshopClassDetails);
                });
            CreateMap<Models.ServiceModels.WorkshopModels.WorkshopClass.ClassAddModel, Models.Entities.WorkshopClass>();                
        }
        private void SetWorkshopMapping()
        {
            CreateMap<Models.Entities.WorkshopPricePolicy, Models.ServiceModels.WorkshopModels.WorkshopPricePolicy>();
            CreateMap<Models.ServiceModels.WorkshopModels.WorkshopPricePolicy, Models.Entities.WorkshopPricePolicy>()
                .ForMember(entity => entity.Id, option => option.Ignore());
            CreateMap<Models.Entities.WorkshopRefundPolicy, Models.ServiceModels.WorkshopModels.WorkshopRefundPolicy>();
            CreateMap<Models.ServiceModels.WorkshopModels.WorkshopRefundPolicy, Models.Entities.WorkshopRefundPolicy>()
                .ForMember(entity => entity.Id, option => option.Ignore());

            CreateMap<Models.Entities.Workshop, Models.ServiceModels.WorkshopModels.Workshop>()
                .ForMember(model => model.Status, modelStatus => modelStatus.MapFrom(entityModel => entityModel.Status.HasValue ? entityModel.Status.Value : 0))
                .ForMember(model => model.Description, modelDescription => modelDescription.MapFrom(entityModel => entityModel.Description == null ? string.Empty : entityModel.Description))
                .ForMember(model => model.Price, modelPrice => modelPrice.MapFrom(entityModel => entityModel.Price == null ? 0 : entityModel.Price));
            CreateMap<Models.ServiceModels.WorkshopModels.Workshop, Models.Entities.Workshop>()
                .ForMember(entity => entity.WorkshopClasses, option => option.Ignore())
                .ForMember(entity => entity.WorkshopRefundPolicyId, option => option.Ignore())
                .ForMember(entity => entity.WorkshopPricePolicyId, option => option.Ignore())
                .ForMember(entity => entity.WorkshopRefundPolicy, option => option.Ignore())
                .ForMember(entity => entity.WorkshopPricePolicy, option => option.Ignore());
            CreateMap<Models.ServiceModels.WorkshopModels.WorkshopAddModel, Models.Entities.Workshop>()
                .ForMember(entity => entity.Picture, modelPicture => modelPicture.MapFrom(serviceModel => serviceModel.Picture))
                .ForMember(entity => entity.Id, option => option.Ignore())
                .ForMember(entity => entity.WorkshopPricePolicyId, option => option.Ignore())
                .ForMember(entity => entity.WorkshopRefundPolicyId, option => option.Ignore())
                .ForMember(entity => entity.WorkshopClasses, option => option.Ignore())
                .ForMember(entity => entity.WorkshopPricePolicy, option => option.Ignore())
                .ForMember(entity => entity.WorkshopRefundPolicy, option => option.Ignore());
            CreateMap<Models.ServiceModels.WorkshopModels.ServiceWorkshopAddModel, Models.ServiceModels.WorkshopModels.WorkshopAddModel>()
                .ForMember(entity => entity.Picture, option => option.Ignore());
        }
    }
}
