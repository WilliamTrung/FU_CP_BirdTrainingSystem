using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Workshop
{
    public interface IWorkshopAllRoles
    {
        Task<IActionResult> GetWorkshopsAsync();
        [Route("class")]
        Task<IActionResult> GetClassesOnSelectedWorkshopAsync([FromQuery] int workshopId);
        [Route("class-slots")]
        Task<IActionResult> GetWorkshopClassDetailsAsync([FromQuery] int workshopClassId);
        [Route("slot-detail")]
        Task<IActionResult> GetClassSlotDetailsAsync([FromQuery] int workshopClassDetailId);
        [Route("refund-policies")]
        Task<IActionResult> GetWorkshopRefuncPolicies();


    }
}
