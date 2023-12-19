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
        private readonly ILogAbsentFeature _logAbsent;
        public TimetableManagerController(ITimetableService timetableService, IAuthService authService, ILogAbsentFeature logAbsent) : base(timetableService, authService)
        {
            _logAbsent = logAbsent;
        }
        [HttpPost]
        [Route("log-in-day")]
        public async Task<IActionResult> LogAbsentInDay([FromBody] AbsentInDayParamModel param)
        {
            var model = param.ToAbsentInDayModel();
            await _logAbsent.LogAbsentInDay(model);
            return Ok();
        }
        [HttpPost]
        [Route("log-range")]
        public async Task<IActionResult> LogAbsentDateRange([FromBody] AbsentDateRangeParamModel param)
        {
            var model = param.ToAbsentDateRangeModel();
            await _logAbsent.LogAbsentDateRange(model);
            return Ok();
        }
    }
}
