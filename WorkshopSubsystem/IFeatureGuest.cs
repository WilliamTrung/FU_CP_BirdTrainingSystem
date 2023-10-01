using Models.ServiceModels.WorkshopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem
{
    public interface IFeatureGuest
    {
        //[Customer] explore[Workshop] on center website - specified price must be detailed for each[Workshop]
        Task<IEnumerable<Workshop>> GetWorkshopGeneralInformation();
    }
}
