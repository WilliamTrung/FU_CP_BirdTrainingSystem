using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.TrainingCourseModels;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    public class TrainingCourseManagerController : TrainingCourseBaseController, ITrainingCourseManager
    {
        public TrainingCourseManagerController(ITrainingCourseService trainingCourseService) : base(trainingCourseService)
        {
        }

        public async Task<IActionResult> ActiveTrainingCourse([FromQuery] int trainingCourseId)
        {
            await _trainingCourseService.Manager.ActiveTrainingCourse(trainingCourseId);
            return Ok();
        }

        public async Task<IActionResult> AddSkill([FromBody] TrainingCourseSkillModel trainingCourseSkill)
        {
            await _trainingCourseService.Manager.AddSkill(trainingCourseSkill);
            return Ok();
        }

        public async Task<IActionResult> CreateCourse([FromBody] TrainingCourseModel trainingCourse)
        {
            await _trainingCourseService.Manager.CreateCourse(trainingCourse);
            return Ok();
        }

        public async Task<IActionResult> DisableTrainingCourse([FromQuery] int trainingCourseId)
        {
            await _trainingCourseService.Manager.DisableTrainingCourse(trainingCourseId);
            return Ok();
        }

        public async Task<IActionResult> EditCourse([FromBody] TrainingCourseModel trainingCourse)
        {
            await _trainingCourseService.Manager.EditCourse(trainingCourse);
            return Ok();
        }
    }
}
