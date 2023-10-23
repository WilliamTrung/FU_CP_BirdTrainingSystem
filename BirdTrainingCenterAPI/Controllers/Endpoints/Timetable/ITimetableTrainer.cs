using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.Timetable;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Timetable
{
    public interface ITimetableTrainer
    {
        [HttpPost]
        [Route("self")]
        Task<IActionResult> GetOccupiedSlots([FromBody] GetOccupiedSlotsTrainerOnly param);
    }
}
