using AutoMapper;
using Models.Entities;
using Models.ServiceModels.WorkshopModels.WorkshopRefundPolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class WorkshopRefundPolicyProfile : Profile
    {
        public WorkshopRefundPolicyProfile()
        {
            Map_WorkshopRefundPolicyAddModel_WorkshopRefundPolicy();
            Map_WorkshopRefundPolicy_WorkshopRefundPolicyViewModModel();
        }

        private void Map_WorkshopRefundPolicyAddModel_WorkshopRefundPolicy()
        {
            CreateMap<WorkshopRefundPolicyAddModel, WorkshopRefundPolicy>()
                .ForMember(m => m.TotalDayBeforeStart, opt => opt.MapFrom(e => e.TotalDayBeforeStart))
                .ForMember(m => m.RefundRate, opt => opt.MapFrom(e => e.RefundRate));
        }

        private void Map_WorkshopRefundPolicy_WorkshopRefundPolicyViewModModel()
        {
            CreateMap<WorkshopRefundPolicy, WorkshopRefundPolicyViewModModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(m => m.TotalDayBeforeStart, opt => opt.MapFrom(e => e.TotalDayBeforeStart))
                .ForMember(m => m.RefundRate, opt => opt.MapFrom(e => e.RefundRate));
        }
    }
}
