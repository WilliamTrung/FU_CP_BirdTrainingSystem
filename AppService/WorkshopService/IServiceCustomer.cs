using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.WorkshopService
{
    public interface IServiceCustomer : IServiceAll
    {
        Task Regsiter(int customerId, int workshopClassId);
        Task<IEnumerable<WorkshopClassViewModel>> GetRegisteredClasses(int customerId);

    }
}
