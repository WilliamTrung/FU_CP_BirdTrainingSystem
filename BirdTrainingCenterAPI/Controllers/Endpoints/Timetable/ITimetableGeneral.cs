using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Timetable
{
    public interface ITimetableGeneral
    {
        [HttpGet]
        [Route("slot-detail")]
        Task<IActionResult> GetOccupiedSlots([FromQuery] int trainerSlotId);
    }
}
