using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.TrainingCourseModels;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/trainingcourse-manager")]
    [ApiController]
    public class TrainingCourseManagerController : TrainingCourseBaseController, ITrainingCourseManager
    {
        public TrainingCourseManagerController(ITrainingCourseService trainingCourseService) : base(trainingCourseService)
        {
        }
        [HttpPut]
        [Route("active")]
        public async Task<IActionResult> ActiveTrainingCourse([FromQuery] int trainingCourseId)
        {
            await _trainingCourseService.Manager.ActiveTrainingCourse(trainingCourseId);
            return Ok();
        }
        [HttpPost]
        [Route("add-skill")]
        public async Task<IActionResult> AddSkill([FromBody] TrainingCourseSkillModel trainingCourseSkill)
        {
            await _trainingCourseService.Manager.AddSkill(trainingCourseSkill);
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateCourse([FromBody] TrainingCourseModel trainingCourse)
        {
            await _trainingCourseService.Manager.CreateCourse(trainingCourse);
            return Ok();
        }
        [HttpPut]
        [Route("disable")]
        public async Task<IActionResult> DisableTrainingCourse([FromQuery] int trainingCourseId)
        {
            await _trainingCourseService.Manager.DisableTrainingCourse(trainingCourseId);
            return Ok();
        }
        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditCourse([FromBody] TrainingCourseModel trainingCourse)
        {
            await _trainingCourseService.Manager.EditCourse(trainingCourse);
            return Ok();
        }
    }
}
