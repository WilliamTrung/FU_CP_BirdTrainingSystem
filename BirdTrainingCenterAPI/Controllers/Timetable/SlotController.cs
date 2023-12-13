using AppService;
using AppService.TimetableService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Timetable;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BirdTrainingCenterAPI.Controllers.Timetable
{
    [Route("api/slot")]
    [ApiController]
    public class SlotController : ODataController, ISlotGeneral, ISlotStaff, ISlotAdministrator
    {
        private readonly ITimetableService _timetableService;
        private readonly IAuthService _authService;
        public SlotController(ITimetableService timetableService, IAuthService authService)
        {
            _timetableService = timetableService;
            _authService = authService;
        }
        //staff - customer
        [HttpPost]
        public async Task<IActionResult> GetFreeSlotOfTrainerByDate([FromQuery] int trainerId, [FromBody] DateOnly date)
        {
            try
            {
                var result = await _timetableService.Staff.GetFreeSlotOnSelectedDateOfTrainer(date.ToDateTime(new TimeOnly()), trainerId);
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
        [EnableQuery]
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

        [HttpPut]
        [Route("updateSlot")]
        public async Task<IActionResult> UpdateSlot(int minute)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            if (minute > 60 || minute < 30)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Duration each slot must be long 30 ~ 60 minute");
            }
            await _timetableService.Admin.UpdateSlot(minute);
            return Ok();
        }
    }
}
