using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.WorkshopService
{
    public interface IServiceAll
    {
        Task<IEnumerable<WorkshopModel>> GetWorkshops();
        Task<IEnumerable<WorkshopClassViewModel>> GetWorkshopClassesByWorkshopId(int workshopId);
        Task<IEnumerable<WorkshopClassDetailViewModel>> GetWorkshopClassSlotsByWorkshopClassId(int workshopClassId);
        Task<WorkshopClassDetailViewModel> GetWorkshopClassSlotById(int workshopClassDetailId);

    }
}