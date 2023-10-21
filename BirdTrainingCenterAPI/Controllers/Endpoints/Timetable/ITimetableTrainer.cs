using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Timetable
{
    public interface ITimetableTrainer
    {
        [HttpGet]
        [Route("self")]
        Task<IActionResult> GetOccupiedSlots([FromQuery] DateOnly from, [FromQuery] DateOnly to);
    }
}
