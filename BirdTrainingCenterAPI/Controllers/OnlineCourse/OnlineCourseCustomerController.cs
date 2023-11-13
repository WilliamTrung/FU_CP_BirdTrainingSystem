using AppService;
using AppService.OnlineCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.OnlineCourse;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Models.AuthModels;
using Models.ServiceModels.OnlineCourseModels.Feedback;
using Models.ServiceModels.OnlineCourseModels.Transaction;
using SP_Middleware;

namespace BirdTrainingCenterAPI.Controllers.OnlineCourse
{
    [Route("api/online-course")]
    [ApiController]
    [CustomAuthorize(roles: "Customer")]
    public class OnlineCourseCustomerController : OnlineCourseBaseController, IOnlineCourseCustomer
    {
        public OnlineCourseCustomerController(IOnlineCourseService onlineCourseService, IAuthService authService) : base(onlineCourseService, authService)
        {
        }
        [HttpGet]
        [Route("billing-information")]
        public async Task<IActionResult> GetBillingInformation([FromQuery] int courseId)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            var billing = await _onlineCourseService.Customer.GetBillingInformation(Int32.Parse(customerId.Value),courseId);
            return Ok(billing);
        }
        [HttpPost]
        [Route("enroll")]
        public async Task<IActionResult> EnrollCourse([FromBody] BillingModel billing)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            await _onlineCourseService.Customer.EnrollCourse(Int32.Parse(customerId.Value), billing);
            return Ok();
        }
        [HttpGet]
        [EnableQuery]
        [Route("enrolled-courses")]
        public async Task<IActionResult> GetEnrolledCourses()
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            var result = await _onlineCourseService.Customer.GetEnrolledCourses(Int32.Parse(customerId.Value));
            return Ok(result);
        }
        [HttpPut]
        [Route("check-lesson")]
        public async Task<IActionResult> CheckCompleteLesson([FromBody] int lessonId)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            await _onlineCourseService.Customer.CheckCompleteLesson(Int32.Parse(customerId.Value), lessonId);
            return Ok();
        }
        [HttpPut]
        [Route("check-section")]
        public async Task<IActionResult> CheckCompleteSection([FromBody] int sectionId)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            await _onlineCourseService.Customer.CheckCompleteSection(Int32.Parse(customerId.Value), sectionId);
            return Ok();
        }
        [HttpPut]
        [Route("check-course")]
        public async Task<IActionResult> CheckCompleteCourse([FromBody] int courseId)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            await _onlineCourseService.Customer.CheckCompleteCourse(Int32.Parse(customerId.Value), courseId);
            return Ok();
        }
        [HttpGet]
        [EnableQuery]
        [Route("completed-courses")]
        public async Task<IActionResult> GetCompletedCourse()
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            var result = await _onlineCourseService.Customer.GetCompletedCourses(Int32.Parse(customerId.Value));
            return Ok(result);
        }
        [HttpGet]
        [Route("certificate")]
        public async Task<IActionResult> GetCertificate([FromQuery] int courseId)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            var result = await _onlineCourseService.Customer.GetCourseCertificate(Int32.Parse(customerId.Value), courseId);
            return Ok(result);
        }
        [HttpGet]
        [Route("certificates")]
        public async Task<IActionResult> GetCertificates()
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            var result = await _onlineCourseService.Customer.GetCertificates(Int32.Parse(customerId.Value));
            return Ok(result);
        }
        [HttpPost]
        [Route("feedback")]
        public async Task<IActionResult> DoFeedback([FromBody] FeedbackOnlineCourseCustomerAddModel feedback)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("feedback")]
        public async Task<IActionResult> GetFeedback([FromQuery] int courseId)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            throw new NotImplementedException();
        }
    }
}
