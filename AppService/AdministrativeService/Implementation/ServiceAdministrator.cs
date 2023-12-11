using AdministrativeSubsystem;
using Models.ApiParamModels.OnlineCourse;
using Models.Enum;
using Models.ServiceModels;
using Models.ServiceModels.UserModels;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionSubsystem;

namespace AppService.AdministrativeService.Implementation
{

    public class ServiceAdministrator : IServiceAdministrator
    {
        private readonly IAdminFeature _admin;
        private readonly IFeatureTransaction _transaction;
        public ServiceAdministrator(IAdminFeature admin, IFeatureTransaction transaction)
        {
            _admin = admin;
            _transaction = transaction;
        }

        public async Task<int> CreateUser(UserAdminAddModel model)
        {
            return await _admin.User.CreateAdministrativeAccount(model);
        }

        public async Task DeleteUser(int userId)
        {
            await _admin.User.DeleteUser(userId);
        }

        public IEnumerable<Models.Enum.Customer.Status> GetCustomerStatuses()
        {
            var result = _admin.User.GetCustomerStatuses();
            return result;
        }

        public IEnumerable<AdministrativeRole> GetRoles()
        {
            var result = _admin.User.GetRoles();
            return result;
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainersInformation()
        {
            return await _admin.User.GetTrainersInformation();
        }

        public IEnumerable<Models.Enum.Trainer.Status> GetTrainerStatuses()
        {
            var result = _admin.User.GetTrainerStatuses();
            return result;
        }

        public async Task<IEnumerable<UserAdminViewModel>> GetUsersInformation()
        {
            var result = await _admin.User.GetUsersInformation();
            return result;
        }

        public async Task TopupCustomer(int customerId, decimal amount)
        {
            string paymentCode = "admin_topup";
            var models = await GetUsersInformation();
            var customer = models.FirstOrDefault(c => c.Id == customerId && c.Role == Role.Customer);
            if(customer == null)
            {
                throw new KeyNotFoundException("Customer not found!");
            }
            string formattedDateTime = DateTime.UtcNow.AddHours(7).ToString("ddMMMyyyyhhmm");
            var transaction = new TransactionAddModel()
            {
                CustomerId = customerId,
                EntityId = null,
                EntityTypeId = (int)Models.Enum.EntityType.Topup,
                PaymentCode = paymentCode,
                Detail = $"{paymentCode}:{customerId}:{customer.Email}-" +
                    $"admin topup account-at:{formattedDateTime}",
                Status = (int)Models.Enum.Transaction.Status.Paid,
                Title = "Admin topup",
                TotalPayment = amount,
            };
            await _transaction.AddTransaction(transaction);
        }

        public async Task UpdateRecord(UserAdminUpdateModel record)
        {
            await _admin.User.UpdateRecord(record);
        }

        public async Task UpdateRole(UserRoleUpdateModel model)
        {
            await _admin.User.UpdateRole(model);
            if(model.UserId != null)
            {
                await _admin.User.GenerateRoleModel(model.UserId.Value);
            }            
        }

        public async Task UpdateStatus(UserStatusUpdateModel model)
        {
            await _admin.User.UpdateStatus(model);
        }
    }
}
