using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/trainingcourse")]
    [ApiController]
    public class TrainingCourseBaseController : ControllerBase, ITrainingCourseAll
    {
        internal readonly ITrainingCourseService _trainingCourseService;
        public TrainingCourseBaseController(ITrainingCourseService trainingCourseService)
        {
            _trainingCourseService = trainingCourseService;
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
        public async Task<IActionResult> GetTrainingCoursesById(int courseId)
        {
            var result = await _trainingCourseService.All.GetTrainingCoursesById(courseId);
            return Ok(result);
        }

        [HttpPost]
        [Route("birdskillreceived")]
        public async Task<IActionResult> CreateBirdSkillReceived(BirdSkillReceivedAddDeleteModel addDeleteModel)
        {
            await _trainingCourseService.All.CreateBirdSkillReceived(addDeleteModel);
            return Ok();
        }

        [HttpDelete]
        [Route("birdskillreceived")]
        public async Task<IActionResult> DeleteBirdSkillReceived(BirdSkillReceivedAddDeleteModel addDeleteModel)
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
        public async Task<IActionResult> GetBirdCertificatesDetailByBirdId(int birdId)
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
        public async Task<IActionResult> GetBirdSkillReceivedsByBirdId(int birdId)
        {
            var result = await _trainingCourseService.All.GetBirdSkillReceivedsByBirdId(birdId);
            return Ok(result);
        }
    }
}
