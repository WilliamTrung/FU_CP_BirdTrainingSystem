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
        Task<IEnumerable<WorkshopModel>> GetWorkshopsGeneralInformation();
        Task<IEnumerable<WorkshopClassViewModel>> GetWorkshopClassesByWorkshopId(int workshopId);
        Task<IEnumerable<WorkshopClassDetailViewModel>> GetWorkshopClassDetailByWorkshopClassId(int workshopClassId);
        Task<WorkshopClassDetailViewModel> GetWorkshopClassDetailById(int workshopClassDetailId);
        Task<WorkshopRefundPolicyModel> GetRefundPolicy();
    }
}