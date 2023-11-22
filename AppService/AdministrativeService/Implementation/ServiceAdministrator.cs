using AdministrativeSubsystem;
using Models.Enum;
using Models.ServiceModels;
using Models.ServiceModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.AdministrativeService.Implementation
{

    public class ServiceAdministrator : IServiceAdministrator
    {
        private readonly IAdminFeature _admin;
        public ServiceAdministrator(IAdminFeature admin)
        {
            _admin = admin;
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

        public IEnumerable<Role> GetRoles()
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

        public Task UpdateRecord(UserAdminUpdateModel record)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRole(UserRoleUpdateModel model)
        {
            await _admin.User.UpdateRole(model);
            await _admin.User.GenerateRoleModel(model.Id);
        }

        public async Task UpdateStatus(UserStatusUpdateModel model)
        {
            await _admin.User.UpdateStatus(model);
        }
    }
}
