using AppService;
using AppService.WorkshopService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Workshop;
using BirdTrainingCenterAPI.Helper;
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

        [HttpGet]
        [Route("customer-registered")]
        public async Task<IActionResult> GetRegisteredClasses()
        {
            //var accessToken = DeserializeToken();
            //if(accessToken == null)
            //{
            //    return Unauthorized();
            //}
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == ClaimTypes.NameIdentifier);

            var result = await _workshopService.Customer.GetRegisteredClasses(Int32.Parse(customerId.Value));
            return Ok(result);

        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromQuery] int workshopClassId)
        {
            //var accessToken = DeserializeToken();
            //if (accessToken == null)
            //{
            //    return Unauthorized();
            //}
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == ClaimTypes.NameIdentifier);
            try
            {
                await _workshopService.Customer.Regsiter(Int32.Parse(customerId.Value), workshopClassId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok();
        }
    }
}
