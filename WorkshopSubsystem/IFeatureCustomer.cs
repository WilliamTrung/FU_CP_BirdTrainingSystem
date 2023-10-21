using Microsoft.Win32;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem
{
    public interface IFeatureCustomer : IFeatureAll
    {

        //Register workshop class
        //param: 
        //"customerId : int
        //WorkshopClassId : int
        Task Register(int customerId, int workshopClassId);
        Task<IEnumerable<WorkshopClassViewModel>> GetRegisteredWorkshopClasses(int customerId);


    }
}
