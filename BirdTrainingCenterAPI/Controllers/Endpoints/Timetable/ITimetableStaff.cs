using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Timetable
{
    public interface ITimetableStaff
    {
        [HttpGet]
        [Route("trainer")]
        Task<IActionResult> GetOccupiedSlots([FromQuery]int trainerId, [FromQuery] DateOnly from, [FromQuery] DateOnly to);

    }
}
