using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.OnlineCourse
{
    public interface IOnlineCourseAllRoles
    {
        [HttpGet]
        [EnableQuery]
        [Route("/courses")]
        Task<IActionResult> GetCourses();
        [HttpGet]
        [Route("/course-by-id")]
        Task<IActionResult> GetCourseById([FromQuery]int courseId);
    }
}
