using Models.Enum;
using Models.ServiceModels.UserModels;
using Models.ServiceModels.UserModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.AdministrativeService
{
    public interface IServiceProfile
    {
        Task UpdateAvatar(int id, Role role, string avatar);
        Task UpdateInformation(int id, Role role, AdditionalUpdateModel model);
        Task<ProfileViewModel> GetProfile(int id, Role role);
    }
}
