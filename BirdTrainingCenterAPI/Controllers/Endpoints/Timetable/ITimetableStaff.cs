using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.Timetable;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Timetable
{
    public interface ITimetableStaff
    {
        [HttpPost]
        [Route("trainer")]
        Task<IActionResult> GetOccupiedSlots([FromBody] GetOccupiedSlotsParam param);

    }
}
