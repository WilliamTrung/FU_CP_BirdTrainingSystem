using AppService;
using AppService.TimetableService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Timetable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Timetable
{
    [ApiController]
    public class TimetableStaffController : TimetableBaseController, ITimetableStaff
    {
        public TimetableStaffController(ITimetableService timetableService, IAuthService authService) : base(timetableService, authService)
        {
        }
        [HttpGet]
        [Route("trainer")]
        public async Task<IActionResult> GetOccupiedSlots([FromQuery] int trainerId, [FromQuery] DateOnly from, [FromQuery] DateOnly to)
        {
            try
            {
                var result = await _timetableService.Staff.GetTrainerSlotTimetableByTrainer(trainerId, from.ToDateTime(new TimeOnly()), to.ToDateTime(new TimeOnly()));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
