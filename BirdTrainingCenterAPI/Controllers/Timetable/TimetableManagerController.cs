using AppService;
using AppService.TimetableService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Timetable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.Timetable;
using Models.ServiceModels.TimetableModels;
using TimetableSubsystem;

namespace BirdTrainingCenterAPI.Controllers.Timetable
{
    [ApiController]
    public class TimetableManagerController : TimetableBaseController, ITimetableManager
    {
        public TimetableManagerController(ITimetableService timetableService, IAuthService authService, ILogAbsentFeature logAbsent) : base(timetableService, authService)
        {
        }
        [HttpPost]
        [Route("log-in-day")]
        public async Task<IActionResult> LogAbsentInDay([FromBody] AbsentInDayParamModel param)
        {
            var model = param.ToAbsentInDayModel();
            await _timetableService.Manager.LogAbsentInDay(model);
            return Ok();
        }
        [HttpPost]
        [Route("log-range")]
        public async Task<IActionResult> LogAbsentDateRange([FromBody] AbsentDateRangeParamModel param)
        {
            var model = param.ToAbsentDateRangeModel();
            await _timetableService.Manager.LogAbsentDateRange(model);
            return Ok();
        }
    }
}
