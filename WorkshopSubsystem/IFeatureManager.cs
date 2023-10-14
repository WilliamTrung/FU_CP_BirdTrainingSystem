using Models.ServiceModels.WorkshopModels;
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
        Task CreateWorkshop(WorkshopAddModel workshop);
        
        //Task ModifyWorkshop(WorkshopModifyModel workshop);
        Task ModifyWorkshopStatus(WorkshopStatusModifyModel workshop);
        IEnumerable<WorkshopStatusModel> GetWorkshopStatuses() => WorkshopStatusModel.All();
    }
}
