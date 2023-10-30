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
        [Route("registration-info")]
        Task<IActionResult> GetRegistrationAmount([FromQuery] int workshopClassId);
        [Route("get-by-id")]
        Task<IActionResult> GetWorkshopById([FromQuery] int workshopId);
        [Route("class-by-id")]
        Task<IActionResult> GetClassById([FromQuery] int workshopClassId);
    }
}
