using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse
{
    public interface ITrainingCourseTrainer
    {
        [HttpGet]
        [Route("birdtrainingprogress-trainer")]
        Task<IActionResult> GetBirdTrainingProgressByTrainerId(int trainerId);

        [HttpPut]
        [Route("mark-trainingdone")]
        Task<IActionResult> MarkTrainingSkillDone(MarkSkillDone markDone);
    }
}
