using AppService;
using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using SP_Middleware;
using System.Security.Claims;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/trainingcourse")]
    [ApiController]
    public class TrainingCourseBaseController : ODataController, ITrainingCourseAll
    {
        internal readonly ITrainingCourseService _trainingCourseService;

        internal readonly IAuthService _authService;
        public TrainingCourseBaseController(ITrainingCourseService trainingCourseService, IAuthService authService)
        {
            _trainingCourseService = trainingCourseService;
            _authService = authService;
        }
        internal List<Claim>? DeserializeToken()
        {
            var authHeader = Request.Headers["Authorization"];
            if (authHeader.Count == 0 || !authHeader[0].StartsWith("Bearer "))
            {
                return null;
            }
            string accessToken = authHeader[0].Split(' ')[1];
            return _authService.DeserializedToken(accessToken);
        }
        [HttpPost]
        [Route("sendnoticonfirmedrequest")]
        public async Task<IActionResult> SendNotiConfirmedRequest([FromQuery] int requestedId)
        {
            var requesteds = await _trainingCourseService.Staff.GetBirdTrainingCourse();
            var requested = requesteds.FirstOrDefault(e => e.Id == requestedId);
            if (requested == null)
            {
                throw new KeyNotFoundException("BirdTrainingCourse not found" + requestedId);
            }
            else
            {
                await _trainingCourseService.All.SendNotiSendBirdToCenter(requested);
            }
            return Ok();
        }
        [HttpPost]
        [Route("sendnotitrainingdonerequest")]
        public async Task<IActionResult> SendNotiTrainingDoneRequest([FromQuery] int requestedId)
        {
            var requesteds = await _trainingCourseService.Staff.GetBirdTrainingCourse();
            var requested = requesteds.FirstOrDefault(e => e.Id == requestedId);
            if (requested == null)
            {
                throw new KeyNotFoundException("BirdTrainingCourse not found" + requestedId);
            }
            else
            {
                await _trainingCourseService.All.SendNotiReceiveBirdFromCenter(requested);
            }
            return Ok();
        }
        [HttpGet]
        [EnableQuery]
        [Route("birdtrainingcourse")]
        public async Task<IActionResult> GetBirdTrainingCourse()
        {
            var result = await _trainingCourseService.Staff.GetBirdTrainingCourse();
            return Ok(result);
        }
        [HttpGet]
        [EnableQuery]
        [Route("birdtrainingcourse-bird")]
        public async Task<IActionResult> GetBirdTrainingCourseByBirdId([FromQuery] int birdId)
        {
            var result = await _trainingCourseService.Staff.GetBirdTrainingCourseByBirdId(birdId);
            return Ok(result);
        }
        [HttpGet]
        [EnableQuery]
        [Route("birdtrainingcourse-customer")]
        public async Task<IActionResult> GetBirdTrainingCourseByCustomerId([FromQuery] int customerId)
        {
            var result = await _trainingCourseService.Staff.GetBirdTrainingCourseByCustomerId(customerId);
            return Ok(result);
        }
        [HttpGet]
        [Route("birdtrainingprogress-requestedId")]
        public async Task<IActionResult> GetBirdTrainingCourseProgressByBirdTrainingCourseId([FromQuery] int birdTrainingCourseId)
        {
            var result = await _trainingCourseService.Staff.GetTrainingCourseSkill(birdTrainingCourseId);
            return Ok(result);
        }
        [HttpGet]
        [Route("birdtrainingreport-progressid")]
        public async Task<IActionResult> GetReportByProgressId([FromQuery] int progressId)
        {
            var result = await _trainingCourseService.Staff.GetReportByProgressId(progressId);
            return Ok(result);
        }
        //[HttpGet]
        //[Route("test-auth")]
        //public IActionResult TestAuth()
        //{
        //    var role = DeserializeToken();
        //    return Ok(role);
        //}
        [HttpGet]
        [EnableQuery]
        [Route("birdspecies")]
        public async Task<IActionResult> GetBirdSpecies()
        {
            var result = await _trainingCourseService.All.GetBirdSpecies();
            return Ok(result);
        }
        [HttpGet]
        [Route("birdspecies-id")]
        public async Task<IActionResult> GetBirdSpeciesById([FromQuery] int birdSpeciesId)
        {
            var result = await _trainingCourseService.All.GetBirdSpeciesById(birdSpeciesId);
            return Ok(result);
        }

        [HttpGet]
        [Route("birdtrainingprogress-statuses")]
        public IActionResult GetEnumBirdTrainingProgressStatuses()
        {
            var result = _trainingCourseService.All.GetEnumBirdTrainingProgressStatuses();
            return Ok(result);
        }

        [HttpGet]
        [EnableQuery]
        [Route("basetrainingcourse")]
        public async Task<IActionResult> GetTrainingCourses()
        {
            var result = await _trainingCourseService.All.GetTrainingCourses();
            return Ok(result);
        }

        [HttpGet]
        [Route("basetrainingcourse-id")]
        public async Task<IActionResult> GetTrainingCoursesById([FromQuery] int courseId)
        {
            var result = await _trainingCourseService.All.GetTrainingCoursesById(courseId);
            return Ok(result);
        }

        [CustomAuthorize(roles: "Manager,Staff")]
        [HttpPost]
        [Route("birdskillreceived")]
        public async Task<IActionResult> CreateBirdSkillReceived([FromBody] BirdSkillReceivedAddDeleteModel addDeleteModel)
        {
            await _trainingCourseService.All.CreateBirdSkillReceived(addDeleteModel);
            return Ok();
        }

        [CustomAuthorize(roles: "Manager,Staff")]
        [HttpDelete]
        [Route("birdskillreceived")]
        public async Task<IActionResult> DeleteBirdSkillReceived([FromBody] BirdSkillReceivedAddDeleteModel addDeleteModel)
        {
            await _trainingCourseService.All.DeleteBirdSkillReceived(addDeleteModel);
            return Ok();
        }

        [HttpGet]
        [EnableQuery]
        [Route("birdskillreceived")]
        public async Task<IActionResult> GetBirdSkillReceiveds()
        {
            var result = await _trainingCourseService.All.GetBirdSkillReceiveds();
            return Ok(result);
        }

        [HttpGet]
        [EnableQuery]
        [Route("birdskillreceived-bird")]
        public async Task<IActionResult> GetBirdSkillReceivedsByBirdId([FromQuery] int birdId)
        {
            var result = await _trainingCourseService.All.GetBirdSkillReceivedsByBirdId(birdId);
            return Ok(result);
        }

        [HttpGet]
        [EnableQuery]
        [Route("birdcertificatedetail")]
        public async Task<IActionResult> GetBirdCertificatesDetail()
        {
            var result = await _trainingCourseService.All.GetBirdCertificatesDetail();
            return Ok(result);
        }

        [HttpGet]
        [EnableQuery]
        [Route("birdcertificatedetail-bird")]
        public async Task<IActionResult> GetBirdCertificatesDetailByBirdId([FromQuery] int birdId)
        {
            var result = await _trainingCourseService.All.GetBirdCertificatesDetailByBirdId(birdId);
            return Ok(result);
        }

        [HttpGet]
        [EnableQuery]
        [Route("birdskill")]
        public async Task<IActionResult> GetBirdSkills()
        {
            var result = await _trainingCourseService.All.GetBirdSkills();
            return Ok(result);
        }

        [HttpGet]
        [Route("birdskill-id")]
        public async Task<IActionResult> GetBirdSkillsById([FromQuery] int birdSkillId)
        {
            var result = await _trainingCourseService.All.GetBirdSkillsById(birdSkillId);
            return Ok(result);
        }

        [HttpGet]
        [EnableQuery]
        [Route("skill")]
        public async Task<IActionResult> GetSkills()
        {
            var result = await _trainingCourseService.All.GetSkills();
            return Ok(result);
        }

        [HttpGet]
        [Route("skill-id")]
        public async Task<IActionResult> GetSkillById(int skillId)
        {
            var result = await _trainingCourseService.All.GetSkillById(skillId);
            return Ok(result);
        }

        [HttpGet]
        [EnableQuery]
        [Route("trainableskill")]
        public async Task<IActionResult> GetTrainableSkills()
        {
            var result = await _trainingCourseService.All.GetTrainableSkills();
            return Ok(result);
        }

        [HttpGet]
        [EnableQuery]
        [Route("trainerskill")]
        public async Task<IActionResult> GetTrainerSkills()
        {
            var result = await _trainingCourseService.All.GetTrainerSkills();
            return Ok(result);
        }

        [HttpGet]
        [EnableQuery]
        [Route("trainerskill-trainerid")]
        public async Task<IActionResult> GetTrainerSkillsByTrainerId([FromQuery] int trainerId)
        {
            var result = await _trainingCourseService.All.GetTrainerSkillsByTrainerId(trainerId);
            return Ok(result);
        }

        [HttpGet]
        [EnableQuery]
        [Route("accquirablebirdskill")]
        public async Task<IActionResult> GetAccquirableBirdSkill()
        {
            var result = await _trainingCourseService.All.GetAccquirableBirdSkill();
            return Ok(result);
        }

        [HttpGet]
        [EnableQuery]
        [Route("accquirablebirdskill-birdspecies")]
        public async Task<IActionResult> GetAccquirableBirdSkillByBirdSpeciesId(int birdSpeciesId)
        {
            var result = await _trainingCourseService.All.GetAccquirableBirdSkillByBirdSpeciesId(birdSpeciesId);
            return Ok(result);
        }

        [HttpGet]
        [EnableQuery]
        [Route("bird-receivedskill")]
        public async Task<IActionResult> ViewBirdSkillReceived(int birdId)
        {
            var result = await _trainingCourseService.All.ViewBirdSkillReceived(birdId);
            return Ok(result);
        }
        [HttpGet]
        [EnableQuery]
        [Route("trainer")]
        public async Task<IActionResult> GetTrainer()
        {
            var result = await _trainingCourseService.All.GetTrainer();
            return Ok(result);
        }
        [HttpGet]
        [EnableQuery]
        [Route("trainer-birdskill")]
        public async Task<IActionResult> GetTrainerByBirdSkillId([FromQuery] int birdSkillId)
        {
            var result = await _trainingCourseService.All.GetTrainerByBirdSkillId(birdSkillId);
            return Ok(result);
        }
        [HttpGet]
        [Route("trainer-id")]
        public async Task<IActionResult> GetTrainerById([FromQuery] int trainerId)
        {
            var result = await _trainingCourseService.All.GetTrainerById(trainerId);
            return Ok(result);
        }
        [HttpGet]
        [EnableQuery]
        [Route("trainer-skill")]
        public async Task<IActionResult> GetTrainerByTrainerSkillId([FromQuery] int trainerSkillId)
        {
            var result = await _trainingCourseService.All.GetTrainerByTrainerSkillId(trainerSkillId);
            return Ok(result);
        }
        [HttpGet]
        [EnableQuery]
        [Route("birdskillreceived-birdid")]
        public async Task<IActionResult> GetBirdSkillReceivedByBirdId(int birdId)
        {
            var result = await _trainingCourseService.All.GetBirdSkillReceivedByBirdId(birdId);
            return Ok(result);
        }
        [HttpGet]
        [EnableQuery]
        [Route("all-requested-users")]
        public async Task<IActionResult> GetCustomerModels()
        {
            var result = await _trainingCourseService.All.GetCustomerModels();
            return Ok(result);
        }

        [HttpGet]
        [Route("timetable-slot-itemdetail")]
        public async Task<IActionResult> GetTimetableReportView([FromQuery] int trainerSlotId)
        {
            var result = await _trainingCourseService.Trainer.GetTimetableReportView(trainerSlotId);
            return Ok(result);
        }

        [HttpGet]
        [EnableQuery]
        [Route("trainingcourse-checkoutpolicies")]
        public async Task<IActionResult> GetTrainingCoursePricePolicies()
        {
            var result = await _trainingCourseService.All.GetTrainingCoursePricePolicies();
            return Ok(result);
        }
    }
}
