using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.DashboardInformative
{
    public interface IDashboard
    {
        [HttpGet]
        [Route("consulting-ticket")]
        [EnableQuery]
        Task<IActionResult> GetConsultingTicketOverview();
        [HttpGet]
        [Route("online-course")]
        [EnableQuery]
        Task<IActionResult> GetOnlineCourseOverview();
        [HttpGet]
        [Route("workshop")]
        [EnableQuery]
        Task<IActionResult> GetWorkshopOverview();
        [HttpGet]
        [Route("training-course")]
        [EnableQuery]
        Task<IActionResult> GetTrainingCourseOverview();
        [HttpGet]
        [Route("transactions")]
        [EnableQuery]
        Task<IActionResult> GetTransactions();
    }
}
