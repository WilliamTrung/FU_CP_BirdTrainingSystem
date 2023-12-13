using AutoMapper;
using Models.Entities;
using Models.ServiceModels.MembershipModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class MembershipProfile : Profile
    {
        public MembershipProfile() 
        {
            Map_MembershipRank_MembershipServiceModel();
            Map_MembershipUpdateServiceModel_MembershipRank();
            Map_MembershipCreateNewServiceModel_MembershipRank();
        }

        private void Map_MembershipRank_MembershipServiceModel()
        {
            CreateMap<MembershipRank, MembershipServiceModel>();
        }

        private void Map_MembershipUpdateServiceModel_MembershipRank()
        {
            CreateMap<MembershipUpdateServiceModel, MembershipRank>()
                .ForMember(e => e.Name, opt => opt.MapFrom(c => c.Name))
                .ForMember(e => e.Discount, opt => opt.MapFrom(c => c.Discount))
                .ForMember(e => e.Requirement, opt => opt.MapFrom(c => c.Requirement));
        }

        private void Map_MembershipCreateNewServiceModel_MembershipRank()
        {
            CreateMap<MembershipCreateNewServiceModel, MembershipRank>()
                .ForMember(e => e.Name, opt => opt.MapFrom(c => c.Name))
                .ForMember(e => e.Discount, opt => opt.MapFrom(c => c.Discount))
                .ForMember(e => e.Requirement, opt => opt.MapFrom(c => c.Requirement));
        }
    }
}
