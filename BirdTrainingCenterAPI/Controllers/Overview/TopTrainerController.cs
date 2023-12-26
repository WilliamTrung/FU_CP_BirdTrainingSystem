using AppService.DashboardService;
using BirdTrainingCenterAPI.Controllers.Endpoints.DashboardInformative;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace BirdTrainingCenterAPI.Controllers.Overview
{
    [Route("api/top-trainer")]
    [ApiController]
    public class TopTrainerController : ControllerBase
    {
        private readonly IDashboardService _dashboard;
        public TopTrainerController(IDashboardService dashboardService)
        {
            _dashboard = dashboardService;
        }
        [HttpGet]        
        public async Task<IActionResult> GetTopTrainer(int? month, int? year)
        {
            if(month == null)
            {
                month = DateTime.UtcNow.AddHours(7).Month;
            }
            if (year == null)
            {
                year = DateTime.UtcNow.AddHours(7).Year;
            }
            var result = await _dashboard.Top.TopTrainer((int)month, (int)year);
            return Ok(result);
        }
    }
}
