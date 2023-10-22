using AppService;
using AppService.WorkshopService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Workshop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BirdTrainingCenterAPI.Controllers.Workshop
{
    public class WorkshopCustomerController : WorkshopBaseController, IWorkshopCustomer
    {
        public WorkshopCustomerController(IWorkshopService workshopService, IAuthService authService) : base(workshopService, authService)
        {
        }

        public async Task<IActionResult> GetRegisteredClasses()
        {
            var accessToken = DeserializeToken();
            if(accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == ClaimTypes.NameIdentifier);

            var result = await _workshopService.Customer.GetRegisteredClasses(Int32.Parse(customerId.Value));
            return Ok(result);

        }

        public async Task<IActionResult> Register([FromQuery] int workshopClassId)
        {
            var accessToken = DeserializeToken();
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == ClaimTypes.NameIdentifier);
            await _workshopService.Customer.Regsiter(Int32.Parse(customerId.Value), workshopClassId);
            return Ok();
        }
    }
}
