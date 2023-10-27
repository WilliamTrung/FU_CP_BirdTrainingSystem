using AppService;
using AppService.TimetableService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Timetable;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.Timetable;
using Models.AuthModels;
using System.Security.Claims;

namespace BirdTrainingCenterAPI.Controllers.Timetable
{
    [ApiController]
    public class TimetableTrainerController : TimetableBaseController, ITimetableTrainer
    {
        public TimetableTrainerController(ITimetableService timetableService, IAuthService authService) : base(timetableService, authService)
        {
        }
        [HttpPost]
        [Route("self")]
        public async Task<IActionResult> GetOccupiedSlots([FromBody] GetOccupiedSlotsTrainerOnly param)
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
            var trainerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            try
            {
                var result = await _timetableService.Trainer.GetTrainerTimetable(Int32.Parse(trainerId.Value), param.From.ToDateTime(new TimeOnly()), param.To.ToDateTime(new TimeOnly()));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
