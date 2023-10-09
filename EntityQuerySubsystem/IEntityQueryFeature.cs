using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityQuerySubsystem
{
    public interface IEntityQueryFeature
    {
        public Task<WorkshopClassDetailViewModel> GetWorkshopClassSlotDetail(int entityId);
    }
}
