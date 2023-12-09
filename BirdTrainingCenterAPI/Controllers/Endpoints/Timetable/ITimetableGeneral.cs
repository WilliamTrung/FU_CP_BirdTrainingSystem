using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.Timetable;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Timetable
{
    public interface ITimetableGeneral
    {
        [HttpGet]
        [Route("slot-detail")]
        Task<IActionResult> GetOccupiedSlots([FromQuery] int trainerSlotId);
        [HttpPost]
        [Route("free-trainers")]
        Task<IActionResult> GetTrainerFreeOnSlotAndDate([FromBody] GetTrainerFreeOnSlotAndDate model);
    }
}
