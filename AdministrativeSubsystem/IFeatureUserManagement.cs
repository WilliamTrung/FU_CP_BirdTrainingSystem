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
        Task UpdateRecord(UserAdminUpdateModel user);
        Task UpdateRole(UserRoleUpdateModel model);
        IEnumerable<Models.Enum.Role> GetRoles();
    }
}
