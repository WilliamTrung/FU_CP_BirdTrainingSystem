using AppService;
using AppService.WorkshopService;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.AuthModels;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using SP_Middleware;

namespace BirdTrainingCenterAPI.Controllers.Workshop
{
    [Route("api/workshop/attendance")]
    [CustomAuthorize(roles: "Staff,Manager,Trainer")]
    [ApiController]
    public class WorkshopAttendanceController : WorkshopBaseController
    {
        public WorkshopAttendanceController(IWorkshopService workshopService, IAuthService authService) : base(workshopService, authService)
        {
        }
        [HttpGet]
        [Route("list-attendees")]
        public async Task<IActionResult> GetListAttendees([FromQuery]int classSlotId)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var role = accessToken.Find(c => c.Type == CustomClaimTypes.Role);
            if(role != null)
            {
                if(role.Value == Enum.GetName(typeof(Models.Enum.Role), Models.Enum.Role.Trainer))
                {
                    var trainerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
                    var result_trainer = await _workshopService.Trainer.GetAttendeesInSlot(Int32.Parse(trainerId.Value), classSlotId);
                    return Ok(result_trainer);
                }
            }
            var result = await _workshopService.Staff.GetAttendeesInSlot(classSlotId);
            return Ok(result);
        }
        [HttpPut]
        [Route("submit")]
        public async Task<IActionResult> SubmitCheckAttendanceForm([FromBody]List<CheckAttendanceCredentials> attendees, [FromQuery]int classSlotId)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var role = accessToken.Find(c => c.Type == CustomClaimTypes.Role);
            if (role != null)
            {
                if (role.Value == Enum.GetName(typeof(Models.Enum.Role), Models.Enum.Role.Trainer))
                {
                    var trainerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
                    await _workshopService.Trainer.SubmitAttendance(Int32.Parse(trainerId.Value), classSlotId, attendees);
                    return Ok();
                }
            }
            await _workshopService.Staff.SubmitAttendance(classSlotId, attendees);
            return Ok();
        }
    }
}
