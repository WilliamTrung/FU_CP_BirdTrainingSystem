using AppService;
using AppService.OnlineCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.OnlineCourse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace BirdTrainingCenterAPI.Controllers.OnlineCourse
{
    [Route("api/online-course/management")]
    [ApiController]
    public class OnlineCourseStaffController : OnlineCourseBaseController, IOnlineCourseStaff
    {
        public OnlineCourseStaffController(IOnlineCourseService onlineCourseService, IAuthService authService) : base(onlineCourseService, authService)
        {
        }
        [HttpGet]
        [EnableQuery]
        [Route("lessons-by-section")]
        public async Task<IActionResult> GetLessonsBySection([FromQuery] int sectionId)
        {
            var result = await _onlineCourseService.Staff.GetLessonsBySection(sectionId);
            return Ok(result);
        }
        [HttpGet]
        [EnableQuery]
        [Route("sections-by-course")]
        public async Task<IActionResult> GetSectionsByCourse([FromQuery] int courseId)
        {
            var result = await _onlineCourseService.Staff.GetSectionsByCourse(courseId);
            return Ok(result);
        }
        [HttpGet]
        [Route("lesson-by-id")]
        public async Task<IActionResult> GetLessonById([FromQuery] int id)
        {
            var result = await _onlineCourseService.Staff.GetLessonById(id);
            return Ok(result);
        }
        [HttpGet]
        [Route("section-by-id")]
        public async Task<IActionResult> GetSectionById([FromQuery] int id)
        {
            var result = await _onlineCourseService.Staff.GetSectionById(id);
            return Ok(result);
        }
    }
}
