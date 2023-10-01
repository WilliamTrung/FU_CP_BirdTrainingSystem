using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class WorkshopProfile : Profile
    {
        public WorkshopProfile() {
            CreateMap<Models.Entities.WorkshopPricePolicy, Models.ServiceModels.WorkshopModels.WorshopPricePolicy>();
            //CreateMap<Models.ServiceModels.WorkshopModels.WorshopPricePolicy, Models.Entities.WorkshopPricePolicy>()
            //    .ForMember(entity => entity.Id, option => option.Ignore());
            CreateMap<Models.Entities.WorkshopRefundPolicy, Models.ServiceModels.WorkshopModels.WorkshopRefundPolicy>();
            //CreateMap<Models.ServiceModels.WorkshopModels.WorkshopRefundPolicy, Models.Entities.WorkshopRefundPolicy>()
            //    .ForMember(entity => entity.Id, option => option.Ignore());

            CreateMap<Models.Entities.Workshop, Models.ServiceModels.WorkshopModels.Workshop>()
                .ForMember(model => model.Status, modelStatus => modelStatus.MapFrom(entityModel => entityModel.Status.HasValue ? entityModel.Status.Value : 0))
                .ForMember(model => model.Description, modelDescription => modelDescription.MapFrom(entityModel => entityModel.Description == null ? string.Empty : entityModel.Description))
                .ForMember(model => model.Price, modelPrice => modelPrice.MapFrom(entityModel => entityModel.Price == null ? 0 : entityModel.Price));                
            
        }
    }
}
