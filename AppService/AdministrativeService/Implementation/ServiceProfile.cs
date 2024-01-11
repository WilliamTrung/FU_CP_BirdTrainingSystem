using AdministrativeSubsystem;
using Models.AuthModels;
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
        private IAuthService _authService;
        public ServiceProfile(IFeatureProfileManagement profile, IAuthService authService)
        {
            _profile = profile;
            _authService = authService;
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

        public async Task<string?> UpdateInformation(int id, Role role, AdditionalUpdateModel model)
        {
            string? newToken = null;
            LoginRequestModel? newLogin = null;
            if(role == Role.Customer)
            {
                newLogin = await _profile.UpdateCustomerAdditionalInformation(id, model);
            } else if (role == Role.Trainer)
            {
                newLogin = await _profile.UpdateTrainerAdditionalInformation(id, model);
            } else
            {
                newLogin = await _profile.UpdateUserInformation(id, model);
            }
            if(newLogin != null)
            {
                newToken = await _authService.Login(newLogin);
            }
            return newToken;
        }
    }
}
