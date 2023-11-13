using AppService;
using AppService.OnlineCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.OnlineCourse;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Models.AuthModels;

namespace BirdTrainingCenterAPI.Controllers.OnlineCourse
{
    [Route("api/online-course")]
    [ApiController]
    public class OnlineCourseAllRolesController : OnlineCourseBaseController, IOnlineCourseAllRoles
    {
        public OnlineCourseAllRolesController(IOnlineCourseService onlineCourseService, IAuthService authService) : base(onlineCourseService, authService)
        {
        }
        [HttpGet]
        [EnableQuery]
        [Route("courses")]
        public async Task<IActionResult> GetCourses()
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                var result_guest = await _onlineCourseService.All.GetCourses();
                return Ok(result_guest);
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            var result = await _onlineCourseService.Customer.GetCourses(Int32.Parse(customerId.Value));
            return Ok(result);
        }
        [HttpGet]
        [Route("course-by-id")]
        public async Task<IActionResult> GetCourseById([FromQuery] int courseId)
        {            
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                var result_guest = await _onlineCourseService.All.GetCourseById(courseId);
                return Ok(result_guest);
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            var result = await _onlineCourseService.Customer.GetCourseById(Int32.Parse(customerId.Value), courseId);
            return Ok(result);
        }
    }
}
