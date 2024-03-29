﻿using AppRepository.UnitOfWork;
using AutoMapper;
using Models.AuthModels;
using Models.Entities;
using Models.Enum;
using Models.ServiceModels.UserModels;
using Models.ServiceModels.UserModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativeSubsystem.Implementation
{
    public class FeatureProfileManagement : IFeatureProfileManagement
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IFeatureUserManagement _userManagement;        
        public FeatureProfileManagement(IUnitOfWork uow, IMapper mapper, IFeatureUserManagement userManagement)
        {
            _uow = uow;
            _mapper = mapper;
            _userManagement = userManagement;
        }

        public async Task<int> GetUserId(int id, Role role)
        {
            if(role == Role.Customer)
            {
                var customer = await _uow.CustomerRepository.GetFirst(c => c.Id == id);
                if (customer == null)
                {
                    throw new KeyNotFoundException("User not found!");
                }
                return customer.UserId;
            } else if(role == Role.Trainer)
            {
                var trainer = await _uow.TrainerRepository.GetFirst(c => c.Id == id);
                if (trainer == null)
                {
                    throw new KeyNotFoundException("User not found!");
                }
                return trainer.UserId;
            } else
            {
                return id;
            }
        }

        public async Task<ProfileViewModel> GetUserProfile(int id)
        {
            var user = await _uow.UserRepository.GetFirst(c => c.Id == id
                                                                , nameof(User.Customers)
                                                                , nameof(User.Trainers)
                                                                , $"{nameof(User.Customers)}.{nameof(Customer.MembershipRank)}");
            await _userManagement.GenerateRoleModel(user.Id);
            var profile = _mapper.Map<ProfileViewModel>(user);
            return profile;
        }

        public async Task<string> UpdateAvatar(int userId, string avatar)
        {
            var user = await _uow.UserRepository.GetFirst(c => c.Id == userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found!");
            }
            var temp = user.Avatar;
            user.Avatar = avatar;
            await _uow.UserRepository.Update(user);
            return temp==null?string.Empty:temp;
        }

        public async Task<LoginRequestModel?> UpdateCustomerAdditionalInformation(int customerId, AdditionalUpdateModel model)
        {            
            var customer = await _uow.CustomerRepository.GetFirst(c => c.Id == customerId);
            if(customer == null)
            {
                throw new KeyNotFoundException("Customer not found!");
            }
            if(model.BirthDay != null)
            {
                customer.BirthDay = model.BirthDay;
            }
            if(model.Gender != null)
            {
                customer.Gender = model.Gender;
            }
            await _uow.CustomerRepository.Update(customer);
            return await UpdateUserInformation(customer.UserId, model);            
        }

        public async Task<LoginRequestModel?> UpdateTrainerAdditionalInformation(int trainerId, AdditionalUpdateModel model)
        {
            var trainer= await _uow.TrainerRepository.GetFirst(c => c.Id == trainerId, nameof(Trainer.ConsultingTickets));            
            if (trainer == null)
            {
                throw new KeyNotFoundException("Customer not found!");
            }
            if (model.BirthDay != null)
            {
                trainer.BirthDay = model.BirthDay;
            }
            if (model.Gender != null)
            {
                trainer.Gender = model.Gender;
            }
            if (model.GgMeetLink != null)
            {
                trainer.GgMeetLink = model.GgMeetLink;

                //var listTickets = await _uow.ConsultingTicketRepository.Get(x => x.TrainerId == trainerId && x.Status != (int)Models.Enum.ConsultingTicket.Status.);
                var listTickets = trainer.ConsultingTickets.Where(x => x.TrainerId == trainerId && 
                (x.Status == (int)Models.Enum.ConsultingTicket.Status.Approved || x.Status == (int)Models.Enum.ConsultingTicket.Status.WaitingForApprove));
                if (listTickets.Count() > 0)
                {
                    throw new Exception("Cannot update Google Meet Link because another ticket is on progress!");
                }
            }
            await _uow.TrainerRepository.Update(trainer);
            return await UpdateUserInformation(trainer.UserId, model);
        }


        public async Task<LoginRequestModel?> UpdateUserInformation(int id, UserUpdateModel model)
        {
            var user = await _uow.UserRepository.GetFirst(c => c.Id == id);
            LoginRequestModel? newLogin = null;
            if (user == null)
            {
                throw new KeyNotFoundException("User not found!");
            }
            if(model.Name != null)
            {
                user.Name = model.Name;
            }
            if(model.Email != null)
            {
                user.Email = model.Email;
                newLogin = new LoginRequestModel();
                newLogin.Email = model.Email;
            }
            if(model.PhoneNumber != null)
            {
                user.PhoneNumber = Decimal.Parse(model.PhoneNumber);
            }
            if (model.Password != null)
            {
                user.Password = model.Password;
            }
            await _uow.UserRepository.Update(user);
            if(newLogin != null) {
                newLogin.Password = user.Password;
            }            
            return newLogin;
        }
    }
}
