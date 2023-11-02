using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Microsoft.AspNetCore.Mvc;

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
    }
}
