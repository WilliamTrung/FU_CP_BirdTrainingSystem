using AppService;
using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using System.Security.Claims;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/trainingcourse")]
    [ApiController]
    public class TrainingCourseBaseController : ControllerBase, ITrainingCourseAll
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
        [HttpGet]
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

        [HttpPost]
        [Route("birdskillreceived")]
        public async Task<IActionResult> CreateBirdSkillReceived([FromBody] BirdSkillReceivedAddDeleteModel addDeleteModel)
        {
            await _trainingCourseService.All.CreateBirdSkillReceived(addDeleteModel);
            return Ok();
        }

        [HttpDelete]
        [Route("birdskillreceived")]
        public async Task<IActionResult> DeleteBirdSkillReceived([FromBody] BirdSkillReceivedAddDeleteModel addDeleteModel)
        {
            await _trainingCourseService.All.DeleteBirdSkillReceived(addDeleteModel);
            return Ok();
        }

        [HttpGet]
        [Route("birdcertificatedetail")]
        public async Task<IActionResult> GetBirdCertificatesDetail()
        {
            var result = await _trainingCourseService.All.GetBirdCertificatesDetail();
            return Ok(result);
        }

        [HttpGet]
        [Route("birdcertificatedetail-bird")]
        public async Task<IActionResult> GetBirdCertificatesDetailByBirdId([FromQuery] int birdId)
        {
            var result = await _trainingCourseService.All.GetBirdCertificatesDetailByBirdId(birdId);
            return Ok(result);
        }

        [HttpGet]
        [Route("birdskillreceived")]
        public async Task<IActionResult> GetBirdSkillReceiveds()
        {
            var result = await _trainingCourseService.All.GetBirdSkillReceiveds();
            return Ok(result);
        }

        [HttpGet]
        [Route("birdskillreceived-bird")]
        public async Task<IActionResult> GetBirdSkillReceivedsByBirdId([FromQuery] int birdId)
        {
            var result = await _trainingCourseService.All.GetBirdSkillReceivedsByBirdId(birdId);
            return Ok(result);
        }

        [HttpGet]
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
        [Route("trainableskill")]
        public async Task<IActionResult> GetTrainableSkills()
        {
            var result = await _trainingCourseService.All.GetTrainableSkills();
            return Ok(result);
        }

        [HttpGet]
        [Route("trainerskill")]
        public async Task<IActionResult> GetTrainerSkills()
        {
            var result = await _trainingCourseService.All.GetTrainerSkills();
            return Ok(result);
        }

        [HttpGet]
        [Route("trainerskill-trainerid")]
        public async Task<IActionResult> GetTrainerSkillsByTrainerId([FromQuery] int trainerId)
        {
            var result = await _trainingCourseService.All.GetTrainerSkillsByTrainerId(trainerId);
            return Ok(result);
        }
    }
}
