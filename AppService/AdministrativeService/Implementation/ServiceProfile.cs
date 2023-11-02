using AdministrativeSubsystem;
using Models.Enum;
using Models.ServiceModels.UserModels;
using Models.ServiceModels.UserModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.AdministrativeService.Implementation
{
    public class ServiceProfile : IServiceProfile
    {
        private IFeatureProfileManagement _profile;
        public ServiceProfile(IFeatureProfileManagement profile)
        {
            _profile = profile;
        }
        public async Task<ProfileViewModel> GetProfile(int id, Role role)
        {
            var usedId = await _profile.GetUserId(id, role);
            var result = await _profile.GetUserProfile(usedId);
            return result;
        }

        public async Task<string> UpdateAvatar(int id, Role role, string avatar)
        {
            var usedId = await _profile.GetUserId(id, role);
            return await _profile.UpdateAvatar(usedId, avatar);
        }

        public async Task UpdateInformation(int id, Role role, AdditionalUpdateModel model)
        {
            if(role == Role.Customer)
            {
                await _profile.UpdateCustomerAdditionalInformation(id, model);
            } else if (role == Role.Trainer)
            {
                await _profile.UpdateTrainerAdditionalInformation(id, model);
            } else
            {
                await _profile.UpdateUserInformation(id, model);
            }
        }
    }
}
