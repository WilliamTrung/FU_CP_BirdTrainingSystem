using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Timetable
{
    public interface ISlotStaff
    {
        [HttpGet]        
        Task<IActionResult> GetFreeSlotOfTrainerByDate([FromQuery]int trainerId, [FromQuery] DateOnly date);
        [HttpGet]
        [Route("trainer")]
        Task<IActionResult> GetFreeTrainersOnDate([FromQuery] DateOnly date);
    }
}
