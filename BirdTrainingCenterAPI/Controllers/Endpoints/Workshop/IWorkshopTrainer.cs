using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Workshop
{
    public interface IWorkshopTrainer
    {
        [HttpGet]
        [Route("assigned-workshops")]
        Task<IActionResult> GetAssignedWorkshops();
        [HttpGet]
        [Route("assigned-classes")]
        Task<IActionResult> GetAssignedClasses([FromQuery] int workshopId); [HttpGet]
        [Route("assigned-slots")]
        Task<IActionResult> GetAssignedSlots([FromQuery] int workshopClassId);
    }
}
