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
        //[Manager] manage [Workshop] - explore, create, edit, archive [Workshop]
        Task AddWorkshop(Workshop workshop);
        Task EditWorkshop(Workshop workshop);
        Task ChangeWorkshopStatus(int workshopId);       

    }
}
