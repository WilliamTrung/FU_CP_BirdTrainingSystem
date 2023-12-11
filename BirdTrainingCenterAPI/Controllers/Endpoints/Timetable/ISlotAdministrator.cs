using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Timetable
{
    public interface ISlotAdministrator
    {
        [HttpPut]
        [Route("updateSlot")]
        Task<IActionResult> UpdateSlot(int minute);
    }
}
