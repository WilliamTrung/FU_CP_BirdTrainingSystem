using AppService.WorkshopService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Workshop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Workshop
{
    public class WorkshopCustomerController : WorkshopBaseController, IWorkshopCustomer
    {
        public WorkshopCustomerController(IWorkshopService workshopService) : base(workshopService)
        {
        }

        public async Task<IActionResult> GetRegisteredClasses()
        {            
            var result = await _workshopService.Customer.GetRegisteredClasses(1);
            return Ok(result);

        }

        public Task<IActionResult> Register([FromQuery] int workshopClassId)
        {
            throw new NotImplementedException();
        }
    }
}
