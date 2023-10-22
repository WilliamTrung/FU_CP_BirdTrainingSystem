using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Timetable
{
    public interface ISlotGeneral
    {
        [HttpGet]
        [Route("time")]
        Task<IActionResult> GetSlots();

    }
}
