﻿using Models.AuthModels;
using Models.Enum;
using Models.ServiceModels.UserModels;
using Models.ServiceModels.UserModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativeSubsystem
{
    public interface IFeatureProfileManagement
    {
        Task<string> UpdateAvatar(int userId, string avatar);
        Task<LoginRequestModel?> UpdateUserInformation(int id, UserUpdateModel model);
        Task<LoginRequestModel?> UpdateCustomerAdditionalInformation(int customerId, AdditionalUpdateModel model);
        Task<LoginRequestModel?> UpdateTrainerAdditionalInformation(int trainerId, AdditionalUpdateModel model);
        Task<ProfileViewModel> GetUserProfile(int id);     
        Task<int> GetUserId(int id, Role role);
    }
}
