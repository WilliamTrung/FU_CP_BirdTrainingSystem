using AppService;
using AppService.WorkshopService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Workshop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [Route("class")]
        public async Task<IActionResult> GetClassesOnSelectedWorkshopAsync([FromQuery] int workshopId)
        {
            var result = await _workshopService.All.GetWorkshopClassesByWorkshopId(workshopId);
            return Ok(result);
        }
        [HttpGet]
        [Route("slot-detail")]

        public async Task<IActionResult> GetClassSlotDetailsAsync([FromQuery] int workshopClassDetailId)
        {
            var result = await _workshopService.All.GetWorkshopClassDetailById(workshopClassDetailId);
            return Ok(result);
        }
        [HttpGet]
        [Route("class-slots")]

        public async Task<IActionResult> GetWorkshopClassDetailsAsync([FromQuery] int workshopClassId)
        {
            var result = await _workshopService.All.GetWorkshopClassDetailByWorkshopClassId(workshopClassId);
            return Ok(result);
        }
        [HttpGet]
        [Route("refund-policies")]

        public async Task<IActionResult> GetWorkshopRefuncPolicies()
        {
            var result = await _workshopService.All.GetRefundPolicies();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetWorkshopsAsync()
        {
            var result = await _workshopService.All.GetWorkshopsGeneralInformation();
            return Ok(result);
        }
    }
}
