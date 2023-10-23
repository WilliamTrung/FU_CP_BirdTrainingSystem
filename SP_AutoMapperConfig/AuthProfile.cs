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

            Map_RegisterModel_User();
            Map_CustomerAddModel_Customer();
            Map_TrainerAddModel_Trainer();
            Map_Customer_TokenModel();
            Map_Trainer_TokenModel();
            Map_User_TokenModel();
        }
        private void Map_RegisterModel_User()
        {
            CreateMap<RegisterRequestModel, User>().ForMember(entity => entity.PhoneNumber, phonenumber => phonenumber.MapFrom(registerModel => decimal.Parse(registerModel.PhoneNumber)))
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForMember(src => src.RoleId, opt => opt.MapFrom(e => (int)Models.Enum.Role.Customer))
                .ForMember(src => src.Trainers, opt => opt.Ignore())
                .ForMember(src => src.Customers, opt => opt.Ignore())
                .ForMember(src => src.BirdTrainingCourses, opt => opt.Ignore())
                ;
        }
        private void Map_CustomerAddModel_Customer()
        {
            CreateMap<CustomerAddModel, Customer>()
                .ForMember(e => e.Id, opt => opt.Ignore());
        }
        private void Map_TrainerAddModel_Trainer()
        {
            CreateMap<TrainerAddModel, Trainer>()
                .ForMember(e => e.Id, opt => opt.Ignore());
        }
        private void Map_Customer_TokenModel()
        {
            CreateMap<Customer, TokenModel>()
                //.ConstructUsing(src => new TokenModel())
                //.ForMember(m => m, opt =>
                //{
                //    opt.PreCondition(e => e.User != null);
                //    opt.MapFrom<Map_Customer_TokenModel_Resolver>();
                //});                
                .AfterMap<MappingAction_Customer_TokenModel>();
        }
        private void Map_Trainer_TokenModel()
        {
            CreateMap<Trainer, TokenModel>()
                //.ForMember(m => m, opt =>
                //{
                //    opt.PreCondition(e => e.User != null);
                //    opt.MapFrom<Map_Trainer_TokenModel_Resolver>();
                //});                
                .AfterMap<MappingAction_Trainer_TokenModel>();
        }
        private void Map_User_TokenModel()
        {
            CreateMap<User, TokenModel>()
                //.ForMember(m => m, opt =>
                //{
                //    opt.MapFrom<Map_User_TokenModel_Resolver>();
                //});
                .AfterMap<MappingAction_User_TokenModel>();
        }
    }
    //public class Map_Customer_TokenModel_Resolver : IValueResolver<Customer, TokenModel, TokenModel>
    //{
    //    public TokenModel Resolve(Customer source, TokenModel destination, TokenModel destMember, ResolutionContext context)
    //    {
    //        destMember.Role = (Models.Enum.Role)source.User.RoleId;
    //        destMember.Email = source.User.Email;
    //        destMember.Avatar = source.User.Avatar;
    //        destMember.Name = source.User.Name;
    //        destMember.Id = source.Id;
    //        return destMember;
    //    }
    //}
    public class MappingAction_Customer_TokenModel : IMappingAction<Customer, TokenModel>
    {
        public void Process(Customer source, TokenModel destination, ResolutionContext context)
        {
            destination.Role = (Models.Enum.Role)source.User.RoleId;
            destination.Email = source.User.Email;
            destination.Avatar = source.User.Avatar;
            destination.Name = source.User.Name;
            destination.Id = source.Id;
        }
    }
    //public class Map_Trainer_TokenModel_Resolver : IValueResolver<Trainer, TokenModel, TokenModel>
    //{
    //    public TokenModel Resolve(Trainer source, TokenModel destination, TokenModel destMember, ResolutionContext context)
    //    {
    //        destMember.Role = (Models.Enum.Role)source.User.RoleId;
    //        destMember.Email = source.User.Email;
    //        destMember.Avatar = source.User.Avatar;
    //        destMember.Name = source.User.Name;
    //        destMember.Id = source.Id;
    //        return destMember;
    //    }
    //}
    public class MappingAction_Trainer_TokenModel : IMappingAction<Trainer, TokenModel>
    {
        public void Process(Trainer source, TokenModel destination, ResolutionContext context)
        {
            destination.Role = (Models.Enum.Role)source.User.RoleId;
            destination.Email = source.User.Email;
            destination.Avatar = source.User.Avatar;
            destination.Name = source.User.Name;
            destination.Id = source.Id;
        }
    }
    //public class Map_User_TokenModel_Resolver : IValueResolver<User, TokenModel, TokenModel>
    //{
    //    public TokenModel Resolve(User source, TokenModel destination, TokenModel destMember, ResolutionContext context)
    //    {
    //        destMember.Role = (Models.Enum.Role)source.RoleId;
    //        destMember.Email = source.Email;
    //        destMember.Avatar = source.Avatar;
    //        destMember.Name = source.Name;
    //        destMember.Id = source.Id;
    //        return destMember;
    //    }
    //}
    public class MappingAction_User_TokenModel : IMappingAction<User, TokenModel>
    {
        public void Process(User source, TokenModel destination, ResolutionContext context)
        {
            destination.Role = (Models.Enum.Role)source.RoleId;
            destination.Email = source.Email;
            destination.Avatar = source.Avatar;
            destination.Name = source.Name;
            destination.Id = source.Id;
        }
    }
}
