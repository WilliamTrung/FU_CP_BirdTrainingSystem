using AppService;
using AppService.TimetableService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Timetable;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BirdTrainingCenterAPI.Controllers.Timetable
{
    [ApiController]
    public class TimetableTrainerController : TimetableBaseController, ITimetableTrainer
    {
        public TimetableTrainerController(ITimetableService timetableService, IAuthService authService) : base(timetableService, authService)
        {
        }
        [HttpGet]
        [Route("self")]
        public async Task<IActionResult> GetOccupiedSlots([FromQuery] DateOnly from, [FromQuery] DateOnly to)
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
            var trainerId = accessToken.First(c => c.Type == ClaimTypes.NameIdentifier);
            try
            {
                var result = await _timetableService.Trainer.GetTrainerTimetable(Int32.Parse(trainerId.Value), from.ToDateTime(new TimeOnly()), to.ToDateTime(new TimeOnly()));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
