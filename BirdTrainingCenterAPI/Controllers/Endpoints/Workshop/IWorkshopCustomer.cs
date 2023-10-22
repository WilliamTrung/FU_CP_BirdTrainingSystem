using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Workshop
{
    public interface IWorkshopCustomer
    {
        [HttpPost]
        [Route("register")]
        Task<IActionResult> Register([FromQuery] int workshopClassId);

        [HttpGet]
        [Route("customer-registered")]
        Task<IActionResult> GetRegisteredClasses();
    }
}
