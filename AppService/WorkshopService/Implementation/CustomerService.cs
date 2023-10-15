using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;
using WorkshopSubsystem;

namespace AppService.WorkshopService.Implementation
{
    internal class CustomerService : AllService, IServiceCustomer
    {
        public CustomerService(IWorkshopFeature workshop, ITimetableFeature timetable) : base(workshop, timetable)
        {
        }

        public async Task<IEnumerable<WorkshopClassViewModel>> GetRegisteredClasses(int customerId)
        {
            return await _workshop.Customer.GetRegisteredWorkshopClasses(customerId);
        }

        public Task Regsiter(int customerId, int workshopClassId)
        {
            throw new NotImplementedException();
        }
    }
}
