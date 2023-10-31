using Models.ServiceModels.WorkshopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.WorkshopService
{
    public interface IServiceManager : IServiceStaff
    {
        Task<int> CreateWorkshop(WorkshopAddModel workshop);
        //Task ModifyWorkshop(WorkshopModifyModel workshop);
        Task<IEnumerable<WorkshopDetailTemplateViewModel>> GetDetailTemplatesByWorkshopId(int workshopId);
        Task ModifyWorkshopDetailTemplate(WorkshopDetailTemplateModiyModel workshopDetail);
        Task ModifyWorkshopStatus(WorkshopStatusModifyModel workshop);
        Task<IEnumerable<WorkshopStatusModel>> GetWorkshopStatuses();
        Task<IEnumerable<WorkshopAdminModel>> GetAllWorkshops();

    }
}
