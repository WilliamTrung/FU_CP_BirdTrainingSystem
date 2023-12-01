using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem
{
    public interface IFeatureManager : IFeatureStaff
    {
        //create workshop
        Task<int> CreateWorkshop(WorkshopAddModel workshop);
        Task<IEnumerable<WorkshopAdminModel>> GetWorkshops();

        //Task ModifyWorkshop(WorkshopModifyModel workshop);
        Task<IEnumerable<WorkshopDetailTemplateViewModel>> GetDetailTemplatesByWorkshopId(int workshopId);
        Task ModifyWorkshopDetailTemplate(WorkshopDetailTemplateModiyModel workshopDetail);
        Task ModifyWorkshopStatus(WorkshopStatusModifyModel workshop);
        Task<IEnumerable<WorkshopStatusModel>> GetWorkshopStatuses() => Task.FromResult(WorkshopStatusModel.All());
        Task ModifyWorkshop(WorkshopModifyModel workshop);
    }
}
