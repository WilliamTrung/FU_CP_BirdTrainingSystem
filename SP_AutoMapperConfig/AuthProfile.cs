using AutoMapper;
using Models.AuthModels;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class AuthProfile : Profile
    {

        public AuthProfile() { 
            CreateMap<User, LoginModel>();
            CreateMap<RegisterModel, User>().ForMember(entity => entity.PhoneNumber, phonenumber => phonenumber.MapFrom(registerModel => decimal.Parse(registerModel.PhoneNumber)))
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForMember(src => src.RoleId, opt => opt.Ignore())                
                .ForMember(src => src.Customers, opt => opt.Ignore())
                //.ForMember(src => src.StaffBirdReceiveds, opt => opt.Ignore())
                .ForMember(src => src.Trainers, opt => opt.Ignore())
                ;
        }
        //public static MapperConfiguration AuthProfile()
        //{
        //    return new MapperConfiguration(config => {
        //        config.CreateMap<User, LoginModel>();
        //        config.CreateMap<RegisterModel, User>()
        //            .ForMember(entity => entity.PhoneNumber, phonenumber => phonenumber.MapFrom(registerModel => decimal.Parse(registerModel.PhoneNumber)))
        //            .ForMember(src => src.Id, opt => opt.Ignore())
        //            .ForMember(src => src.RoleId, opt => opt.Ignore())
        //            .ForMember(src => src.Role, opt => opt.Ignore())
        //            .ForMember(src => src.Customers, opt => opt.Ignore())
        //            .ForMember(src => src.StaffBirdReceiveds, opt => opt.Ignore())
        //            .ForMember(src => src.Trainers, opt => opt.Ignore());
        //    }
        //    );
        //}
    }
}
