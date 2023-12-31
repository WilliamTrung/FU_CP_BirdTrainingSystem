﻿using AdministrativeSubsystem;
using AppRepository.UnitOfWork;
using AutoMapper;
using Models.AuthModels;
using Models.Entities;
using Models.Enum;
using Models.ServiceModels.UserModels;
using Models.ServiceModels.UserModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class AdminitrationProfile : Profile
    {

        public AdminitrationProfile() {
            Map_User_UserAdminViewModel();
            Map_User_ProfileViewModel();
            Map_UserAdminAddModel_Trainer();
            Map_UserAdminAddModel_User();
        }
        private void Map_UserAdminAddModel_User()
        {
            CreateMap<UserAdminAddModel, User>()
                .AfterMap<MappingAction_UserAdminAddModel_User>();
        }
        private void Map_UserAdminAddModel_Trainer()
        {
            CreateMap<UserAdminAddModel, Trainer>()
                .AfterMap<MappingAction_UserAdminAddModel_Trainer>();
        }
        private void Map_User_UserAdminViewModel()
        {
            CreateMap<User, UserAdminViewModel>()
                .AfterMap<MappingAction_User_UserAdminViewModel>();
        }
        private void Map_User_ProfileViewModel()
        {
            CreateMap<User, ProfileViewModel>()
                .AfterMap<MappingAction_User_ProfileViewModel>();
        }
    }
    public class MappingAction_User_UserAdminViewModel : IMappingAction<User, UserAdminViewModel>
    {
        private readonly IAdminFeature _adminFeature;
        private readonly IUnitOfWork _uow;
        public MappingAction_User_UserAdminViewModel(IAdminFeature adminFeature, IUnitOfWork uow)
        {
                _adminFeature = adminFeature;
            _uow = uow;
        }
        public void Process(User source, UserAdminViewModel destination, ResolutionContext context)
        {
            destination.Id = source.Id;
            destination.Role = (Role)Enum.ToObject(typeof(Role), source.RoleId);
            destination.Email = source.Email;
            destination.PhoneNumber = source.PhoneNumber.ToString();
            destination.Avatar = source.Avatar == null ? "" : source.Avatar;                        
            if (destination.Role == Role.Customer)
            {
                _adminFeature.User.GenerateRoleModel(destination.Id).Wait();
                
                Customer customer = _uow.CustomerRepository.GetFirst(c => c.UserId == destination.Id).Result;
                destination.BirthDay = customer.BirthDay;
                destination.Membership = customer.MembershipRank.Name;
                destination.Gender = customer.Gender;
                destination.Id = customer.Id;
                destination.TotalPayment = customer.TotalPayment;
                destination.Status = ((Models.Enum.Customer.Status)Enum.ToObject(typeof(Models.Enum.Customer.Status), customer.Status)).ToString();
            } else if(destination.Role == Role.Trainer)
            {
                _adminFeature.User.GenerateRoleModel(destination.Id).Wait();
                Trainer customer = _uow.TrainerRepository.GetFirst(c => c.UserId == destination.Id).Result;
                var trainer = source.Trainers.First();  
                destination.Id = trainer.Id;
                destination.BirthDay = trainer.BirthDay;
                destination.Gender = trainer.Gender;
                destination.IsFulltime = trainer.IsFullTime;
                destination.Consultantable = trainer.ConsultantAble;
                destination.Status = ((Models.Enum.Trainer.Status)Enum.ToObject(typeof(Models.Enum.Trainer.Status), trainer.Status)).ToString();
            }
            
        }
    }
    public class MappingAction_User_ProfileViewModel : IMappingAction<User, ProfileViewModel>
    {
        public void Process(User source, ProfileViewModel destination, ResolutionContext context)
        {
            destination.Role = (Role)Enum.ToObject(typeof(Role), source.RoleId);
            destination.Email = source.Email;
            destination.PhoneNumber = source.PhoneNumber.ToString();
            destination.Avatar = source.Avatar == null ? "" : source.Avatar;
            if (destination.Role == Role.Customer)
            {
                var customer = source.Customers.First();
                destination.BirthDay = customer.BirthDay;
                destination.Membership = customer.MembershipRank.Name;
                destination.Gender = customer.Gender;
                destination.TotalPayment = customer.TotalPayment;
                destination.Status = ((Models.Enum.Customer.Status)Enum.ToObject(typeof(Models.Enum.Customer.Status), customer.Status)).ToString();
            }
            else if (destination.Role == Role.Trainer)
            {
                var trainer = source.Trainers.First();
                destination.BirthDay = trainer.BirthDay;
                destination.Gender = trainer.Gender;
                destination.IsFulltime = trainer.IsFullTime;
                destination.Status = ((Models.Enum.Trainer.Status)Enum.ToObject(typeof(Models.Enum.Trainer.Status), trainer.Status)).ToString();
                destination.GgMeetLink = trainer.GgMeetLink;
            }

        }
    }
    public class MappingAction_UserAdminAddModel_User : IMappingAction<UserAdminAddModel, User>
    {
        public void Process(UserAdminAddModel source, User destination, ResolutionContext context)
        {
            destination.PhoneNumber = decimal.Parse(source.PhoneNumber);
            destination.Avatar = source.Avatar == null?string.Empty:source.Avatar;
            destination.Email = source.Email;
            destination.Name = source.Name;
            destination.Password = source.Password;
            destination.RoleId = (int)source.Role;          
        }
    }
    public class MappingAction_UserAdminAddModel_Trainer : IMappingAction<UserAdminAddModel, Trainer>
    {
        public void Process(UserAdminAddModel source, Trainer destination, ResolutionContext context)
        {
            destination.BirthDay = source.BirthDay;
            destination.ConsultantAble = source.Consultantable.HasValue ? source.Consultantable.Value : false;
            destination.Gender = source.Gender;
            destination.GgMeetLink = source.GgMeetLink;
            destination.IsFullTime = source.IsFulltime.HasValue ? source.IsFulltime.Value : true;
                destination.Status = (int)Models.Enum.Trainer.Status.Working;
        }
    }
}
