using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.Workshop;
using Models.ServiceModels.WorkshopModels;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Workshop
{
    public interface IWorkshopManager
    {
        [HttpPost]
        [Route("create")]
        Task<IActionResult> CreateWorkshop([FromForm] WorkshopAddParamModel workshop);
        [HttpPut]
        [Route("modify")]
        Task<IActionResult> ModifyWorkshop([FromForm] WorkshopModifyParamModel workshop);

        [HttpGet]
        [Route("detail-template")]
        Task<IActionResult> GetWorkshopDetailTemplate([FromQuery] int workshopId);
        [HttpPut]
        [Route("modify-detail-template")]
        Task<IActionResult> ModifyWorkshopDetail([FromBody] WorkshopDetailTemplateModiyModel workshopDetail);
        [HttpPut]
        [Route("activate")]
        Task<IActionResult> ActivateWorkshop([FromQuery] int workshopId);
        [HttpPut]
        [Route("deactivate")]
        Task<IActionResult> DeactivateWorkshop([FromQuery] int workshopId);
        [HttpGet]
        [Route("status")]
        Task<IActionResult> GetWorkshopStatuses();

    }
}
