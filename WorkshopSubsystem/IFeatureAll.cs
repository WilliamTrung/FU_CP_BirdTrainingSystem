using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem
{
    public interface IFeatureAll
    {        
        Task<IEnumerable<WorkshopModel>> GetWorkshopGeneralInformation();
        Task<IEnumerable<WorkshopClassViewModel>> GetClassesByWorkshopId(int workshopId);
        Task<WorkshopClassDetailViewModel> GetWorkshopClassDetail(int workshopClassDetailId);
        Task<IEnumerable<WorkshopClassDetailViewModel>> GetWorkshopClassDetailOnWorkshopClass(int workshopClassId);
    }
}
