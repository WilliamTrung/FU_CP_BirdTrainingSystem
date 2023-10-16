using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.WorkshopService.Implementation
{
    public class ServiceAll : IServiceAll
    {
        public Task<IEnumerable<WorkshopClassViewModel>> GetWorkshopClassesByWorkshopId(int workshopId)
        {
            throw new NotImplementedException();
        }

        public Task<WorkshopClassDetailViewModel> GetWorkshopClassSlotById(int workshopClassDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkshopClassDetailViewModel>> GetWorkshopClassSlotsByWorkshopClassId(int workshopClassId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkshopModel>> GetWorkshops()
        {
            throw new NotImplementedException();
        }
    }
}
