using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    public class TrainingCourseTrainerController : TrainingCourseBaseController, ITrainingCourseTrainer
    {
        public TrainingCourseTrainerController(ITrainingCourseService trainingCourseService) : base(trainingCourseService)
        {
        }

        public async Task<IActionResult> GetBirdTrainingProgressByTrainerId(int trainerId)
        {
            var result = await _trainingCourseService.Trainer.GetBirdTrainingProgressByTrainerId(trainerId);
            return Ok(result);
        }

        public async Task<IActionResult> MarkTrainingSkillDone(MarkSkillDone markDone)
        {
            await _trainingCourseService.Trainer.MarkTrainingSkillDone(markDone);
            return Ok();
        }
    }
}
