using AppService;
using AppService.OnlineCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.OnlineCourse;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Models.ApiParamModels.OnlineCourse;
using Models.AuthModels;
using Models.ServiceModels.OnlineCourseModels.Feedback;
using Models.ServiceModels.OnlineCourseModels.Transaction;
using Org.BouncyCastle.Utilities;
using SP_Middleware;
using TEST_CERTSAMPLE;

namespace BirdTrainingCenterAPI.Controllers.OnlineCourse
{
    [Route("api/online-course")]
    [ApiController]
    [CustomAuthorize(roles: "Customer")]
    public class OnlineCourseCustomerController : OnlineCourseBaseController, IOnlineCourseCustomer
    {
        private readonly IPdfGenerator _pdf;
        public OnlineCourseCustomerController(IOnlineCourseService onlineCourseService, IAuthService authService, IPdfGenerator pdfGenerator) : base(onlineCourseService, authService)
        {
            _pdf = pdfGenerator;
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
        public async Task<IActionResult> CheckCompleteLesson([FromBody] LessonIdModel model)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            await _onlineCourseService.Customer.CheckCompleteLesson(Int32.Parse(customerId.Value), model.LessonId);
            return Ok();
        }
        [HttpPut]
        [Route("check-section")]
        public async Task<IActionResult> CheckCompleteSection([FromBody] SectionIdModel model)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            await _onlineCourseService.Customer.CheckCompleteSection(Int32.Parse(customerId.Value), model.SectionId);
            return Ok();
        }
        [HttpPut]
        [Route("check-course")]
        public async Task<IActionResult> CheckCompleteCourse([FromBody] CourseIdModel model)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            await _onlineCourseService.Customer.CheckCompleteCourse(Int32.Parse(customerId.Value), model.CourseId);
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

            var certBytes = _pdf.GenerateCertificate(result.CustomerName, result.Title, result.ReceivedDate.ToDateTime(new TimeOnly()));
            return File(certBytes, "application/pdf");
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
