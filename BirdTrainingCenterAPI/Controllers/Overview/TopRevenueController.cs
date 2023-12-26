using AppService.DashboardService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace BirdTrainingCenterAPI.Controllers.Overview
{
    [Route("api/top-revenue")]
    [ApiController]
    public class TopRevenueController : ControllerBase
    {
        private readonly IDashboardService _dashboard;
        public TopRevenueController(IDashboardService dashboardService)
        {
            _dashboard = dashboardService;
        }
        [HttpGet]
        [Route("workshop")]
        [EnableQuery]
        public async Task<IActionResult> GetTopWorkshop(int? year)
        {
            if (year == null)
            {
                year = DateTime.UtcNow.AddHours(7).Year;
            }
            var result = await _dashboard.Top.RevenueWorkshop((int)year);
            return Ok(new { Title = result.Title, DataPoints = result.DataPoints});
        }
        [HttpGet]
        [Route("training-course")]
        [EnableQuery]
        public async Task<IActionResult> GetTopTrainingCourse(int? year)
        {
            if (year == null)
            {
                year = DateTime.UtcNow.AddHours(7).Year;
            }
            var result = await _dashboard.Top.RevenueTrainingCourse((int)year);
            return Ok(new { Title = result.Title, DataPoints = result.DataPoints });
        }
        [HttpGet]
        [Route("online-course")]
        [EnableQuery]
        public async Task<IActionResult> GetTopOnlineCourse(int? year)
        {
            if (year == null)
            {
                year = DateTime.UtcNow.AddHours(7).Year;
            }
            var result = await _dashboard.Top.RevenueOnlineCourse((int)year);
            return Ok(new { Title = result.Title, DataPoints = result.DataPoints });
        }
    }
}
