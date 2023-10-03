using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem
{
    public interface IFeatureStaff
    {
        //[Staff] explore [Workshop]
        //[Staff] create [Class] for selected [Workshop]
        //[Staff] assign[Trainer] to[Slot] in [Class] - [Trainer] will be the guide of the[Workshop] for [Customer]       
        //[Staff] check attendance of[Customer] for the[Workshop] - [Customer] can only be checked if [Customer] has already been charged for joining[Workshop]
        Task<IEnumerable<Workshop>> GetWorkshops();
        Task<IEnumerable<ClassViewModel>> GetClassByWorkshopId(int workshopId);
        Task CreateWorkshopClass(ClassAddModel classAddModel);
        Task ModifyWorkshopClassSlot();
        Task ModifyWorkshopClass(ClassModifiedModel @class);
    }
}
