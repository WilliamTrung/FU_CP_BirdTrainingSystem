using AppRepository.UnitOfWork;
using AutoMapper;
using Models.AuthModels;
using Models.Entities;
using Models.Enum;
using Models.ServiceModels;
using Models.ServiceModels.UserModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            var entities = await _uow.UserRepository.Get(null
                                                        , nameof(User.Customers)
                                                        , nameof(User.Trainers)
                                                        , $"{nameof(User.Customers)}.{nameof(Customer.MembershipRank)}");
            var models = _mapper.Map<List<UserAdminViewModel>>(entities);
            return models;
        }

        public async Task UpdateRecord(UserAdminUpdateModel user)
        {
            if(user.Role == Role.Customer)
            {
                throw new InvalidOperationException("Cannot change customer information");
            }
            if(user.Role == Role.Trainer)
            {
                var trainer = await _uow.TrainerRepository.GetFirst(c => c.Id == user.Id, nameof(Trainer.User));
                if (trainer == null)
                {
                    throw new KeyNotFoundException("Trainer not found!");
                }
                if (user.BirthDay != null)
                {
                    trainer.BirthDay = user.BirthDay;
                }
                if (user.Gender != null)
                {
                    trainer.Gender = user.Gender;
                }
                if(user.IsFullTime != null)
                {
                    trainer.IsFullTime = (bool)user.IsFullTime;
                }
                if(user.Consultantable != null)
                {
                    trainer.ConsultantAble = (bool)user.Consultantable;
                }
                if(user.GgMeetLink != null)
                {
                    trainer.GgMeetLink = user.GgMeetLink;
                }

                if(user.PhoneNumber != null)
                {
                    var phone = decimal.Parse(user.PhoneNumber);
                    var find = await _uow.TrainerRepository.Get(c => c.User.PhoneNumber == phone && c.Id != user.Id, nameof(Trainer.User));
                    if (find.Any())
                    {
                        throw new InvalidOperationException("This phone number has existed!");
                    }
                    trainer.User.PhoneNumber = phone;
                }
                if(user.Name != null)
                {
                    trainer.User.Name = user.Name;
                }
                if(user.Password != null)
                {
                    trainer.User.Password = user.Password;
                }
                await _uow.TrainerRepository.Update(trainer);
            } else
            {
                var staff = await _uow.UserRepository.GetFirst(c => c.Id == user.Id);
                if(staff == null)
                {
                    throw new KeyNotFoundException("User not found!");
                }
                if (user.PhoneNumber != null)
                {
                    var phone = decimal.Parse(user.PhoneNumber);
                    var find = await _uow.UserRepository.Get(c => c.PhoneNumber == phone && c.Id != user.Id);
                    if (find.Any())
                    {
                        throw new InvalidOperationException("This phone number has existed!");
                    }
                    staff.PhoneNumber = phone;
                }
                if (user.Name != null)
                {
                    staff.Name = user.Name;
                }
                if (user.Password != null)
                {
                    
                    staff.Password = user.Password;
                }
                await _uow.UserRepository.Update(staff);
            }
        }

        public async Task UpdateRole(UserRoleUpdateModel model)
        {
            if(model.UserId == null && model.TrainerId == null)
            {
                throw new InvalidDataException("No id passed!");
            } else if (model.UserId != null && model.TrainerId != null) {
                throw new InvalidDataException("Ambiguous id!");
            }
            if(model.UserId != null)
            {
                var entity = await _uow.UserRepository.GetFirst(c => c.Id == model.UserId);
                if (entity.RoleId == (int)model.Role)
                {
                    throw new InvalidOperationException("Role is unchanged!");
                }
                if (typeof(AdministrativeRole).IsEnumDefined(entity.RoleId) && typeof(AdministrativeRole).IsEnumDefined((int)model.Role))
                {
                    entity.RoleId = (int)model.Role;
                    await _uow.UserRepository.Update(entity);
                }
                else
                {
                    throw new InvalidOperationException("Current role cannot be changed!");
                }

            } else
            {
                var entity = await _uow.TrainerRepository.GetFirst(c => c.Id == model.TrainerId, nameof(Trainer.User));
                if (entity.User.RoleId == (int)model.Role)
                {
                    throw new InvalidOperationException("Role is unchanged!");
                }
                if (!typeof(AdministrativeRole).IsEnumDefined(entity.User.RoleId))
                {
                    throw new InvalidOperationException("Current role cannot be changed!");
                } else if (!typeof(AdministrativeRole).IsEnumDefined((int)model.Role))
                {
                    throw new InvalidOperationException("Cannot change to this role!");
                }
                else
                {
                    entity.User.RoleId = (int)model.Role;
                    await _uow.TrainerRepository.Update(entity);                    
                }
            }
            
            
        }
        public IEnumerable<AdministrativeRole> GetRoles()
        {
            var roles = Enum.GetValues(typeof(AdministrativeRole)).Cast<AdministrativeRole>();
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

        public async Task<IEnumerable<TrainerModel>> GetTrainersInformation()
        {
            var trainers = await _uow.TrainerRepository.Get(expression: c => c.User.RoleId == (int)Models.Enum.Role.Trainer
                                                                   , nameof(Trainer.TrainerSkills)
                                                                   , nameof(Trainer.User));
            var trainerModels = _mapper.Map<List<TrainerModel>>(trainers);
            return trainerModels;
        }

        public async Task<int> CreateAdministrativeAccount(UserAdminAddModel model)
        {
            //check duplicate email
            var check = await _uow.UserRepository.GetFirst(c => c.Email == model.Email || c.PhoneNumber == Decimal.Parse(model.PhoneNumber));
            if (check != null)
            {
                throw new InvalidOperationException("Existing email or phone number!");
            }
            //add user and customer record
            var user = _mapper.Map<User>(model);
            await _uow.UserRepository.Add(user);
            if(model.Role == AdministrativeRole.Trainer)
            {
                var trainer = _mapper.Map<Trainer>(model);
                trainer.UserId = user.Id;
                await _uow.TrainerRepository.Add(trainer);
                return trainer.Id;
            }
            return user.Id;

        }
    }
}
