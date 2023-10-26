using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.ServiceModels.WorkshopModels.WorkshopClass;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Workshop
{
    public interface IWorkshopStaff
    {
        [HttpPost]
        [Route("create-class")]
        Task<IActionResult> CreateWorkshopClass([FromBody] WorkshopClassAddModel workshopClass);
        [HttpGet]
        [Route("get-classes")]
        Task<IActionResult> GetClassesByWorkshop([FromQuery] int workshopId);
        [HttpGet]
        [Route("get-class-details")]
        Task<IActionResult> GetDetailsByClass([FromQuery] int workshopClassId);
        [HttpPut]
        [Route("modify-trainer")]
        Task<IActionResult> ModifyTrainerForDetail([FromBody] WorkshopClassDetailTrainerSlotModifyModel workshopClassDetail);
        [HttpPut]
        [Route("modify-slot")]
        Task<IActionResult> ModifyTrainerForDetailSlot([FromBody] WorkshopClassDetailTrainerSlotOnlyModifyModel workshopClassDetail);
        [HttpPut]
        [Route("cancel")]
        Task<IActionResult> CancelWorkshopClass([FromQuery] int workshopClassId);
        [HttpPut]
        [Route("complete")]
        Task<IActionResult> CompleteWorkshopClass([FromQuery] int workshopClassId);

    }
}
