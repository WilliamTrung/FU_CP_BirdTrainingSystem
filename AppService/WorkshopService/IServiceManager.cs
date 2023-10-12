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
        Task<IEnumerable<WorkshopRefundPolicyModel>> GetWorkshopRefundPolicy();
        Task ModifyWorkshop(WorkshopModifyModel workshop);
        Task ModifyWorkshopStatus(WorkshopStatusModifyModel workshop);
        Task<IEnumerable<WorkshopStatusModel>> GetWorkshopStatuses();

    }
}
