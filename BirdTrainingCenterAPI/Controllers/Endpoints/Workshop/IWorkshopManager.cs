using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.WorkshopModels;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Workshop
{
    public interface IWorkshopManager
    {
        [HttpPost]
        [Route("create")]
        Task<IActionResult> CreateWorkshop([FromForm] WorkshopAddModel workshop);

        [HttpGet]
        [Route("detail-template")]
        Task<IActionResult> GetWorkshopDetailTemplate([FromQuery] int workshopId);
        [HttpPut]
        [Route("modify-detail-template")]
        Task<IActionResult> ModifyWorkshopDetail([FromBody] WorkshopDetailTemplateModiyModel workshopDetail);
        [HttpPut]
        [Route("modify-status")]
        Task<IActionResult> ModifyWorkshopStatus([FromBody] WorkshopStatusModifyModel workshop);
        [HttpGet]
        [Route("status")]
        Task<IActionResult> GetWorkshopStatuses();

    }
}
