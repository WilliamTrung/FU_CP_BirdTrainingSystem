using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Microsoft.AspNetCore.Mvc;
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
    }
}
