using AdministrativeSubsystem;
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
        public async Task<IEnumerable<UserAdminViewModel>> GetUsersInformation()
        {
            var result = await _admin.User.GetUsersInformation();
            return result;
        }

        public Task UpdateRecord(UserAdminUpdateModel record)
        {
            throw new NotImplementedException();
        }
    }
}
