using AppService;
using AppService.WorkshopService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Workshop;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Models.AuthModels;

namespace BirdTrainingCenterAPI.Controllers.Workshop
{
    [Route("api/workshop")]
    [ApiController]
    public class WorkshopAllRolesController : WorkshopBaseController, IWorkshopAllRoles
    {
        public WorkshopAllRolesController(IWorkshopService workshopService, IAuthService authService) : base(workshopService, authService)
        {
        }
        [HttpGet]
        [EnableQuery]
        [Route("class")]
        public async Task<IActionResult> GetClassesOnSelectedWorkshopAsync([FromQuery] int workshopId)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                var result_guest = await _workshopService.All.GetWorkshopClassesByWorkshopId(workshopId);
                foreach (var res in result_guest)
                {
                    res.Registered = await _workshopService.All.GetRegistrationAmount(res.Id);
                }
                return Ok(result_guest);
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            var result_customer = await _workshopService.Customer.GetWorkshopClassesByWorkshopId(Int32.Parse(customerId.Value), workshopId);
            foreach (var res in result_customer)
            {
                res.Registered = await _workshopService.All.GetRegistrationAmount(res.Id);
            }
            return Ok(result_customer);
        }
        [HttpGet]
        [EnableQuery]
        [Route("class-by-id")]
        public async Task<IActionResult> GetClassById([FromQuery] int workshopClassId)
        {
            var result = await _workshopService.All.GetWorkshopClass(workshopClassId);
            result.Registered = await _workshopService.All.GetRegistrationAmount(workshopClassId);
            return Ok(result);
        }
        [HttpGet]
        [EnableQuery]
        [Route("slot-detail")]

        public async Task<IActionResult> GetClassSlotDetailsAsync([FromQuery] int workshopClassDetailId)
        {
            var result = await _workshopService.All.GetWorkshopClassDetailById(workshopClassDetailId);
            return Ok(result);
        }
        [HttpGet]
        [EnableQuery]
        [Route("class-slots")]

        public async Task<IActionResult> GetWorkshopClassDetailsAsync([FromQuery] int workshopClassId)
        {
            var result = await _workshopService.All.GetWorkshopClassDetailByWorkshopClassId(workshopClassId);
            return Ok(result);
        }
        [HttpGet]
        [EnableQuery]
        [Route("refund-policies")]

        public async Task<IActionResult> GetWorkshopRefuncPolicies()
        {
            var result = await _workshopService.All.GetRefundPolicies();
            return Ok(result);
        }
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetWorkshopsAsync()
        {
            var result = await _workshopService.All.GetWorkshopsGeneralInformation();
            return Ok(result);
        }
        [HttpGet]
        [Route("registration-info")]
        public async Task<IActionResult> GetRegistrationAmount([FromQuery] int workshopClassId)
        {
            var result = await _workshopService.All.GetRegistrationAmount(workshopClassId);
            result.ClassId = workshopClassId;
            return Ok(result);
        }
        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetWorkshopById([FromQuery] int workshopId)
        {
            var result = await _workshopService.All.GetWorkshopsGeneralInformation();            
            return Ok(result.First(e => e.Id == workshopId));
        }
        [HttpGet]
        [Route("feedbacks")]
        public async Task<IActionResult> GetFeedbacks([FromQuery] int workshopId)
        {
            var result = await _workshopService.All.GetFeedbacks(workshopId);
            return Ok(result);
        }
    }
}
