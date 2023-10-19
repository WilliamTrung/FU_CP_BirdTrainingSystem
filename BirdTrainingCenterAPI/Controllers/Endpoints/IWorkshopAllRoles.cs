using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Endpoints
{
    public interface IWorkshopAllRolesEndpoint
    {
        Task<IActionResult> GetWorkshopsAsync();
        [Route("class")]
        Task<IActionResult> GetClassesOnSelectedWorkshopAsync([FromQuery]int workshopId);
        [Route("class-slots")]
        Task<IActionResult> GetWorkshopClassDetailsAsync([FromQuery]int workshopClassId);
        [Route("slot-detail")]
        Task<IActionResult> GetClassSlotDetailsAsync([FromQuery]int workshopClassDetailId);
        [Route("refund-policy")]
        Task<IActionResult> GetWorkshopRefuncPolicy();
    
    
    }
}
