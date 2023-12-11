using Models.ServiceModels.WorkshopModels.CustomerRegister;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.WorkshopService
{
    public interface IServiceStaff : IServiceAll
    {
        Task CreateWorkshopClass(WorkshopClassAddModel workshopClass);
        Task<IEnumerable<WorkshopClassAdminViewModel>> GetWorkshopClassAdminViewModels(int workshopId);
        Task<IEnumerable<WorkshopClassDetailViewModel>> GetWorkshopClassDetailViewModels(int workshopClassId);

        Task ModifyWorkshopClassDetailTrainerSlot(WorkshopClassDetailTrainerSlotModifyModel workshopClassDetail);
        Task ModifyWorkshopClassDetailSlotOnly(WorkshopClassDetailTrainerSlotOnlyModifyModel workshopClassDetail);
        Task CancelWorkshopClass(int workshopClassId);
        Task CompleteWorkshopClass(int workshopClassId);
        Task CloseRegistrationWorkshopClass(int workshopClassId);
        Task SetWorkshopClassOngoing(int workshopClassId);
        Task<IEnumerable<RegisteredCustomerModel>> GetAttendeesInSlot(int classSlotId);
        Task SubmitAttendance(int classSlotId, List<CheckAttendanceCredentials> customerCredentials);
        Task<WorkshopClassAdminViewModel> GetClassAdminViewById(int classId);
        Task ModifyWorkshopClass(WorkshopClassModifyModel modified);
    }
}
