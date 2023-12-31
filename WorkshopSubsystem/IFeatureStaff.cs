﻿using Models.Entities;
using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.CustomerRegister;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem
{
    public interface IFeatureStaff : IFeatureAll
    {
        Task CreateWorkshopClass(WorkshopClassAddModel workshopClass);
        Task<IEnumerable<WorkshopClassAdminViewModel>> GetWorkshopClassAdminViewModels(int workshopId);
        Task<IEnumerable<WorkshopClassDetailViewModel>> GetWorkshopClassDetailViewModels(int workshopClassId);

        Task ModifyWorkshopClass(WorkshopClassModifyModel modified);
        Task ModifyWorkshopClassDetailTrainerSlot(WorkshopClassDetailTrainerSlotModifyModel workshopClass);
        Task ModifyWorkshopClassDetailSlotOnly(WorkshopClassDetailTrainerSlotOnlyModifyModel workshopClass);
        Task<bool> CheckPassEndRegistrationDay(int workshopClassDetailId, DateOnly compareDate);
        Task<WorkshopClassDetailViewModel?> GetPreviousWorkshopClassDetail(int workshopClassDetailId);
        Task<WorkshopClassDetailViewModel?> GetFollowingWorkshopClassDetail(int workshopClassDetailId);
        Task CancelWorkshopClass(int workshopClassId);
        
        Task<IEnumerable<RegisteredCustomerModel>> GetListRegistered(int classSlotId);
        Task CheckAttendance(int classSlotId, List<CheckAttendanceCredentials> customerCredentials);
        Task GenerateWorkshopAttendance(int customerId, int workshopClassId);
        Task LateCheckAttendance();
        Task SetClassOngoing(int classId);
        Task SetOpenRegistrationForClass(int classId);
        Task SetClosedRegistrationForClass(int classId);
        Task CompleteWorkshopClass(int workshopClassId);
        Task<bool> CheckSlotFulfill(int workshopClassId);
        Task<WorkshopClassAdminViewModel> GetClassAdminViewById(int classId);
    }
}
