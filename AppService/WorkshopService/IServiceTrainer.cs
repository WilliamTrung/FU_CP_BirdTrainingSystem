using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.CustomerRegister;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.WorkshopService
{
    public interface IServiceTrainer : IServiceAll
    {
        //Task ModifyWorkshopClassSlotDetail(int trainerId, WorkshopClassDetailModifyModel workshopClassDetail);
        Task<IEnumerable<WorkshopModel>> GetAssignedWorkshops(int trainerId);
        Task<IEnumerable<WorkshopClassAdminViewModel>> GetAssignedWorkshopClasses(int trainerId, int workshopId);
        Task<IEnumerable<WorkshopClassDetailViewModel>> GetAssignedWorkshopClassDetails(int trainerId, int workshopClassId);
        Task<IEnumerable<RegisteredCustomerModel>> GetAttendeesInSlot(int trainerId, int classSlotId);
        Task<WorkshopClassDetailTrainerViewModel> GetTrainerSlotByEntityId(int trainerId, int classSlotId);
        Task SubmitAttendance(int trainerId, int classSlotId, List<CheckAttendanceCredentials> customerCredentials);
    }
}
