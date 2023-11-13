using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Models.ServiceModels.OnlineCourseModels.Feedback;
using Models.ServiceModels.OnlineCourseModels.Transaction;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.OnlineCourse
{
    public interface IOnlineCourseCustomer
    {
        [HttpGet]
        [Route("/billing-information")]
        Task<IActionResult> GetBillingInformation([FromQuery] int courseId);
        [HttpPost]
        [Route("/enroll")]
        Task<IActionResult> EnrollCourse([FromBody] BillingModel billing);
        [HttpGet]
        [EnableQuery]
        [Route("/enrolled-courses")]
        Task<IActionResult> GetEnrolledCourses();
        [HttpPut]
        [Route("/check-lesson")]
        Task<IActionResult> CheckCompleteLesson([FromBody]int lessonId);
        [HttpPut]
        [Route("/check-section")]
        Task<IActionResult> CheckCompleteSection([FromBody]int sectionId);
        [HttpPut]
        [Route("/check-course")]
        Task<IActionResult> CheckCompleteCourse([FromBody]int courseId);
        [HttpGet]
        [EnableQuery]
        [Route("/completed-courses")]
        Task<IActionResult> GetCompletedCourse();
        [HttpGet]
        [Route("/certificate")]
        Task<IActionResult> GetCertificate([FromQuery]int courseId);
        [HttpGet]
        [Route("/certificates")]
        Task<IActionResult> GetCertificates();
        [HttpPost]
        [Route("/feedback")]
        Task<IActionResult> DoFeedback([FromBody] FeedbackOnlineCourseCustomerAddModel feedback);
        [HttpGet]
        [Route("/feedback")]
        Task<IActionResult> GetFeedback([FromQuery]int courseId);
    }
}
