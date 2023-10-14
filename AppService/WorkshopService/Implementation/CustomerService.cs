using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.WorkshopService.Implementation
{
    internal class CustomerService : AllService, IServiceCustomer
    {
        public Task<IEnumerable<WorkshopClassViewModel>> GetRegisteredClasses(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task Regsiter(int customerId, int workshopClassId)
        {
            throw new NotImplementedException();
        }
    }
}
