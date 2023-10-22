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
        Task CreateWorkshop(WorkshopAddModel workshop);
        //Task ModifyWorkshop(WorkshopModifyModel workshop);
        Task ModifyWorkshopDetailTemplate(WorkshopDetailTemplateModiyModel workshopDetail);
        Task ModifyWorkshopStatus(WorkshopStatusModifyModel workshop);
        Task<IEnumerable<WorkshopStatusModel>> GetWorkshopStatuses();

    }
}
