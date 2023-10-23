using AppService;
using AppService.TimetableService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Timetable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.Timetable;

namespace BirdTrainingCenterAPI.Controllers.Timetable
{
    [ApiController]
    public class TimetableStaffController : TimetableBaseController, ITimetableStaff
    {
        public TimetableStaffController(ITimetableService timetableService, IAuthService authService) : base(timetableService, authService)
        {
        }
        [HttpPost]
        [Route("trainer")]
        public async Task<IActionResult> GetOccupiedSlots([FromBody] GetOccupiedSlotsParam param)
        {
            try
            {
                var result = await _timetableService.Staff.GetTrainerSlotTimetableByTrainer(param.TrainerId, param.From.ToDateTime(new TimeOnly()), param.To.ToDateTime(new TimeOnly()));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
