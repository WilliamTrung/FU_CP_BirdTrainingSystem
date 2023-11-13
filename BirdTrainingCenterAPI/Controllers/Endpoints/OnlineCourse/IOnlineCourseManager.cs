using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.OnlineCourse;
using Models.ServiceModels.OnlineCourseModels.Operation;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.OnlineCourse
{
    public interface IOnlineCourseManager
    {
        [HttpPost]
        [Route("/add-course")]
        Task<IActionResult> CreateOnlineCourse([FromForm] OnlineCourseAddParamModel model);
        [HttpPost]
        [Route("/add-section")]
        Task<IActionResult> AddSection([FromForm] OnlineCourseSectionAddModel model);
        [HttpPost]
        [Route("/add-lesson")]
        Task<IActionResult> AddLesson([FromForm] OnlineCourseLessonAddParamModel model);
        [HttpPut]
        [Route("/modify-section")]
        Task<IActionResult> ModifySection([FromForm] OnlineCourseSectionModifyModel model);
        [HttpPut]
        [Route("/modify-lesson")]
        Task<IActionResult> ModifyLesson([FromForm] OnlineCourseLessonModifyParamModel model);
        [HttpDelete]
        [Route("/delete-section")]
        Task<IActionResult> DeleteSection([FromBody] int sectionId);
        [HttpDelete]
        [Route("/delete-lesson")]
        Task<IActionResult> DeleteLesson([FromBody] int lessonId);
        [HttpPut]
        [Route("/activate")]
        Task<IActionResult> ActivateCourse([FromBody] int courseId);
        [HttpPut]
        [Route("/deactivate")]
        Task<IActionResult> DeactivateCourse([FromBody] int courseId);
        [HttpPut]
        [Route("/cancel")]
        Task<IActionResult> CancelCourse([FromBody] int courseId);
    }
}
