using AppRepository.UnitOfWork;
using AutoMapper;
using Models.AuthModels;
using Models.Entities;
using Models.Enum;
using Models.ServiceModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativeSubsystem.Implementation
{
    public class FeatureUserManagement : IFeatureUserManagement
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public FeatureUserManagement(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserAdminViewModel>> GetUsersInformation()
        {
            var entities = await _uow.UserRepository.Get(null, nameof(User.Customers), nameof(User.Trainers), $"{nameof(User.Customers)}.{nameof(Customer.MembershipRank)}");
            var models = _mapper.Map<List<UserAdminViewModel>>(entities);
            return models;
        }

        public Task UpdateRecord(UserAdminUpdateModel user)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRole(UserRoleUpdateModel model)
        {
            var entity = await _uow.UserRepository.GetFirst(c => c.Id == model.Id);
            if(entity.RoleId == (int)model.Role)
            {
                throw new InvalidOperationException("Role is unchanged!");
            }
            entity.RoleId = (int)model.Role;
            await _uow.UserRepository.Update(entity);
        }
        public IEnumerable<Role> GetRoles()
        {
            var roles = Enum.GetValues(typeof(Role)).Cast<Role>();
            return roles;
        }

        public async Task GenerateRoleModel(int userId)
        {
            var user = await _uow.UserRepository.GetFirst(c => c.Id == userId);
            if(user == null)
            {
                throw new KeyNotFoundException($"User not found at id: {userId}");
            }
            if (user.RoleId == (int)Models.Enum.Role.Customer)
            {
                var customer = await _uow.CustomerRepository.GetFirst(c => c.UserId == userId);
                if (customer == null)
                {
                    //create new customer by userId
                    var customerAdd = new CustomerAddModel
                    {
                        UserId = user.Id,
                    };
                    customer = _mapper.Map<Customer>(customerAdd);
                    await _uow.CustomerRepository.Add(customer);
                    customer.User = user;
                }
            }
            else if (user.RoleId == (int)Models.Enum.Role.Trainer)
            {
                var trainer = await _uow.TrainerRepository.GetFirst(c => c.UserId == userId);
                if (trainer == null)
                {
                    //create new trainer by userId
                    var trainerAdd = new TrainerAddModel
                    {
                        UserId = user.Id,
                    };
                    trainer = _mapper.Map<Trainer>(trainerAdd);
                    await _uow.TrainerRepository.Add(trainer);
                    trainer.User = user;
                }
            }
        }

        public IEnumerable<Models.Enum.Customer.Status> GetCustomerStatuses()
        {
            var statuses = Enum.GetValues(typeof(Models.Enum.Customer.Status)).Cast<Models.Enum.Customer.Status>();
            return statuses;
        }

        public IEnumerable<Models.Enum.Trainer.Status> GetTrainerStatuses()
        {
            var statuses = Enum.GetValues(typeof(Models.Enum.Trainer.Status)).Cast<Models.Enum.Trainer.Status>();
            return statuses;
        }

        public async Task UpdateStatus(UserStatusUpdateModel model)
        {
            var user = await _uow.UserRepository.GetFirst(c => c.Id == model.Id, nameof(User.Customers), nameof(User.Trainers));
            await GenerateRoleModel(model.Id);
            if(user.RoleId == (int)Role.Customer)
            {
                Models.Enum.Customer.Status enumValue;
                if (Enum.TryParse(model.Status, out enumValue))
                {
                    // Conversion successful
                    var customer = user.Customers.First();
                    if (customer.Status != (int)enumValue)
                        customer.Status = (int)enumValue;
                    else
                        throw new InvalidDataException("Status is already set!");
                    await _uow.UserRepository.Update(user);
                }
                else
                {
                    // Handle the case where the string doesn't match any enum value
                    throw new InvalidDataException("Invalid status for customer!");
                }
            } else if(user.RoleId == (int)Role.Trainer)
            {
                Models.Enum.Trainer.Status enumValue;
                if (Enum.TryParse(model.Status, out enumValue))
                {
                    // Conversion successful
                    var trainer = user.Trainers.First();
                    if (trainer.Status != (int)enumValue)
                        trainer.Status = (int)enumValue;
                    else
                        throw new InvalidDataException("Status is already set!");
                    trainer.Status = (int)enumValue;
                    await _uow.UserRepository.Update(user);
                }
                else
                {
                    // Handle the case where the string doesn't match any enum value
                    throw new InvalidDataException("Invalid status for trainer!");
                }
            } else
            {
                throw new InvalidOperationException("Cannot change status for this role!");
            }
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _uow.UserRepository.GetFirst(c => c.Id == userId, nameof(User.Customers)
                                                                             , nameof(User.Trainers));
            if(user == null)
            {
                throw new KeyNotFoundException("User not found!");
            }
            if(user.Trainers.First() != null)
                await _uow.TrainerRepository.Delete(user.Trainers.First());
            if(user.Customers.First() != null)
                await _uow.CustomerRepository.Delete(user.Customers.First());
            await _uow.UserRepository.Delete(user);
        }
    }
}
