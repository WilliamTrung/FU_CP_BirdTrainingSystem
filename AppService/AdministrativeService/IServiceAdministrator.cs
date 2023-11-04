﻿using Models.ServiceModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.AdministrativeService
{
    public interface IServiceAdministrator
    {
        Task<IEnumerable<UserAdminViewModel>> GetUsersInformation();
        Task UpdateRecord(UserAdminUpdateModel record);
        Task UpdateRole(UserRoleUpdateModel model);
        IEnumerable<Models.Enum.Role> GetRoles();
        IEnumerable<Models.Enum.Customer.Status> GetCustomerStatuses();
        IEnumerable<Models.Enum.Trainer.Status> GetTrainerStatuses();
        Task UpdateStatus(UserStatusUpdateModel model);
        Task DeleteUser(int userId);
    }
}