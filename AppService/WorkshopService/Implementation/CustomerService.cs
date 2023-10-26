using Models.ServiceModels.WorkshopModels;
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
    public class CustomerService : AllService, IServiceCustomer
    {
        public CustomerService(IWorkshopFeature workshop, ITimetableFeature timetable) : base(workshop, timetable)
        {
        }

        public async Task<IEnumerable<WorkshopClassViewModel>> GetRegisteredClass(int customerId, int workshopId)
        {
            return await _workshop.Customer.GetRegisteredWorkshopClass(customerId, workshopId);
        }

        public async Task Register(int customerId, int workshopClassId)
        {
            if(await _workshop.All.SetWorkshopClassFull(workshopClassId))
            {
                throw new InvalidOperationException("This workshop class is full!");
            } else
            {
                await _workshop.Customer.Register(customerId, workshopClassId);
            }            
        }
        public async Task<IEnumerable<WorkshopModel>> GetRegisteredWorkshopss(int customerId)
        {
            return await _workshop.Customer.GetRegisteredWorkshops(customerId);
        }
    }
}
