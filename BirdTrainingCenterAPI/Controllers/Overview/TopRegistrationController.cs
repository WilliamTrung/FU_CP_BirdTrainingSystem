using AppService.DashboardService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BirdTrainingCenterAPI.Controllers.Overview
{
    [Route("api/top-registration")]
    [ApiController]
    public class TopRegistrationController : ODataController
    {
        private readonly IDashboardService _dashboard;
        public TopRegistrationController(IDashboardService dashboardService)
        {
            _dashboard = dashboardService;
        }
        #region ByYear
        [HttpGet]
        [Route("workshop")]
        [EnableQuery]
        public async Task<IActionResult> GetTopWorkshop(int? year)
        {
            if(year == null)
            {
                year = DateTime.UtcNow.AddHours(7).Year;
            }
            var result = await _dashboard.Top.RegistrationWorkshop((int)year);
            return Ok(new { Title = result.Title, DataPoints = result.DataPoints });
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
            var result = await _dashboard.Top.RegistrationTrainingCourse((int)year);
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
            var result = await _dashboard.Top.RegistrationOnlineCourse((int)year);
            return Ok(new { Title = result.Title, DataPoints = result.DataPoints });
        }
        #endregion
        #region ByMonth
        [HttpGet]
        [Route("workshop-month")]
        [EnableQuery]
        public async Task<IActionResult> GetTopWorkshop(int? month, int? year)
        {
            if (month == null)
            {
                month = DateTime.UtcNow.AddHours(7).Month;
            }
            if (year == null)
            {
                year = DateTime.UtcNow.AddHours(7).Year;
            }
            var result = await _dashboard.Top.RegistrationWorkshop((int)month, (int)year);
            return Ok(new { Title = result.Title, DataPoints = result.DataPoints });
        }
        [HttpGet]
        [Route("training-course-month")]
        [EnableQuery]
        public async Task<IActionResult> GetTopTrainingCourse(int? month, int? year)
        {
            if (month == null)
            {
                month = DateTime.UtcNow.AddHours(7).Month;
            }
            if (year == null)
            {
                year = DateTime.UtcNow.AddHours(7).Year;
            }
            var result = await _dashboard.Top.RegistrationTrainingCourse((int)month, (int)year);
            return Ok(new { Title = result.Title, DataPoints = result.DataPoints });
        }
        [HttpGet]
        [Route("online-course-month")]
        [EnableQuery]
        public async Task<IActionResult> GetTopOnlineCourse(int? month, int? year)
        {
            if (month == null)
            {
                month = DateTime.UtcNow.AddHours(7).Month;
            }
            if (year == null)
            {
                year = DateTime.UtcNow.AddHours(7).Year;
            }
            var result = await _dashboard.Top.RegistrationOnlineCourse((int)month, (int)year);
            return Ok(new { Title = result.Title, DataPoints = result.DataPoints });
        }
        #endregion
    }
}
