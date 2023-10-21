using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Endpoints
{
    public interface IWorkshopCustomerEnpoints
    {
        [HttpPost]
        [Route("register")]
        Task<IActionResult> Register([FromQuery]int workshopClassId);

        [HttpGet]
        [Route("customer-registered")]
        Task<IActionResult> GetRegisteredClasses();
    }
}
