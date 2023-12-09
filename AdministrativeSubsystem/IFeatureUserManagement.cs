using Models.ServiceModels;
using Models.ServiceModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativeSubsystem
{
    public interface IFeatureUserManagement
    {
        Task<IEnumerable<UserAdminViewModel>> GetUsersInformation();
        Task<IEnumerable<TrainerModel>> GetTrainersInformation();
        Task UpdateRecord(UserAdminUpdateModel user);
        Task UpdateRole(UserRoleUpdateModel model);
        IEnumerable<Models.Enum.AdministrativeRole> GetRoles();
        IEnumerable<Models.Enum.Customer.Status> GetCustomerStatuses();
        IEnumerable<Models.Enum.Trainer.Status> GetTrainerStatuses();
        Task GenerateRoleModel(int userId);
        Task UpdateStatus(UserStatusUpdateModel model);
        Task DeleteUser(int userId);
        Task CreateAdministrativeAccount();
    }
}
