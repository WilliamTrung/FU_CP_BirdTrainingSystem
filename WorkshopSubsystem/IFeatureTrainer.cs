using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem
{
    public interface IFeatureTrainer
    {
        //Task ModifyWorkshopClassSlotDetail(WorkshopClassDetailModifyModel workshopClass);
        Task<IEnumerable<WorkshopModel>> GetAssignedWorkshops(int trainerId);
        Task<IEnumerable<WorkshopClassAdminViewModel>> GetAssignedWorkshopClasses(int trainerId, int workshopId);
        Task<IEnumerable<WorkshopClassDetailViewModel>> GetAssignedWorkshopClassDetails(int trainerId, int workshopClassId);
        Task<WorkshopClassDetailViewModel> GetTrainerSlotByEntityId(int trainerId, int workshopClassDetailId);
        Task<bool> CheckHostingClassSlot(int trainerId, int classSlotId);
    }
}
