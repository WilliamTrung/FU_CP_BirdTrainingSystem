using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.OnlineCourse
{
    public interface IOnlineCourseStaff
    {
        [HttpGet]
        [EnableQuery]
        [Route("lessons-by-section")]
        Task<IActionResult> GetLessonsBySection([FromQuery] int sectionId);
        [HttpGet]
        [EnableQuery]
        [Route("sections-by-course")]
        Task<IActionResult> GetSectionsByCourse([FromQuery]int courseId);
        [HttpGet]
        [Route("lesson-by-id")]
        Task<IActionResult> GetLessonById([FromQuery]int id);
        [HttpGet]
        [Route("section-by-id")]
        Task<IActionResult> GetSectionById([FromQuery] int id);
    }
}
