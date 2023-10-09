using Models.ServiceModels.WorkshopModels;
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
        Task ModifyWorkshopClassSlotDetail(WorkshopClassDetailModifyModel workshopClass);
        Task ModifyWorkshopClassDetailTrainerSlot(WorkshopClassDetailTrainerSlotModifyModel workshopClass);
        Task ModifyWorkshopClassDetailSlotOnly(WorkshopClassDetailTrainerSlotOnlyModifyModel workshopClass);
        
    }
}
