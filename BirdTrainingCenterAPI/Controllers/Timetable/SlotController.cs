using AppService.TimetableService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Timetable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Timetable
{
    [Route("api/slot")]
    [ApiController]
    public class SlotController : ControllerBase, ISlotGeneral, ISlotStaff
    {
        private readonly ITimetableService _timetableService;
        public SlotController(ITimetableService timetableService)
        {
            _timetableService = timetableService;
        }
        //staff
        [HttpPost]
        public async Task<IActionResult> GetFreeSlotOfTrainerByDate([FromQuery] int trainerId, [FromBody] DateOnly date)
        {
            try
            {
                var result = await _timetableService.Staff.GetFreeSlotOnSelectedDateOfTrainer(trainerId, date.ToDateTime(new TimeOnly()));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("trainer")]
        public async Task<IActionResult> GetFreeTrainersOnDate([FromBody] DateOnly date)
        {
            try
            {
                var result = await _timetableService.Staff.GetFreeTrainerOnSelectedDate(date.ToDateTime(new TimeOnly()));
                return Ok(result);
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        //general
        [HttpGet]
        [Route("time")]
        public async Task<IActionResult> GetSlots()
        {
            try
            {
                var result = await _timetableService.All.GetSlots();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
