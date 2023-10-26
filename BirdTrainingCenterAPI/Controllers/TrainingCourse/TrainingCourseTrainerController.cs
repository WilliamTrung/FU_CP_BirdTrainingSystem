using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/trainingcourse-trainer")]
    [ApiController]
    public class TrainingCourseTrainerController : TrainingCourseBaseController, ITrainingCourseTrainer
    {
        public TrainingCourseTrainerController(ITrainingCourseService trainingCourseService) : base(trainingCourseService)
        {
        }
        [HttpGet]
        [Route("birdtrainingprogress-trainer")]
        public async Task<IActionResult> GetBirdTrainingProgressByTrainerId(int trainerId)
        {
            var result = await _trainingCourseService.Trainer.GetBirdTrainingProgressByTrainerId(trainerId);
            return Ok(result);
        }

        [HttpGet]
        [Route("timetable-slot-itemdetail")]
        public async Task<IActionResult> GetTimetableReportView(int birdTrainingReportId)
        {
            var result = await _trainingCourseService.Trainer.GetTimetableReportView(birdTrainingReportId);
            return Ok(result);
        }

        [HttpPut]
        [Route("mark-trainingdone")]
        public async Task<IActionResult> MarkTrainingSkillDone(MarkSkillDone markDone)
        {
            await _trainingCourseService.Trainer.MarkTrainingSkillDone(markDone);
            return Ok();
        }
    }
}
