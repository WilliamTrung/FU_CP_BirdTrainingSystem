using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.Timetable;
using Models.ServiceModels.TimetableModels;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Timetable
{
    public interface ITimetableManager
    {
        [HttpPost]
        [Route("log-in-day")]
        Task<IActionResult> LogAbsentInDay([FromBody] AbsentInDayParamModel param);
        [HttpPost]
        [Route("log-range")]
        Task<IActionResult> LogAbsentDateRange([FromBody] AbsentDateRangeParamModel param);
    }
}
