using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.TrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse
{
    public interface ITrainingCourseTrainer
    {
        [HttpGet]
        [Route("birdtrainingprogress-trainer")]
        Task<IActionResult> GetBirdTrainingProgressByTrainerId([FromQuery]int trainerId);

        [HttpPut]
        [Route("mark-trainingdone")]
        Task<IActionResult> MarkTrainingSkillDone([FromForm]TrainerMarkDoneParamModel markDone);

        [HttpGet]
        [Route("timetable-slot-itemdetail")]
        Task<IActionResult> GetTimetableReportView([FromQuery]int birdTrainingReportId);
    }
}
