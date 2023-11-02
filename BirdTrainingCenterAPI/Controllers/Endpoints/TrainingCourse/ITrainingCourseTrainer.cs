using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.TrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse
{
    public interface ITrainingCourseTrainer : ITrainingCourseAll
    {
        [HttpGet]
        [Route("birdtrainingprogress-trainer")]
        Task<IActionResult> GetBirdTrainingProgressByTrainerId([FromQuery]int trainerId);

        [HttpPut]
        [Route("mark-trainingskilldone")]
        Task<IActionResult> MarkTrainingSkillDone([FromForm]TrainerMarkDoneParamModel markDone);

        [HttpGet]
        [Route("timetable-slot-itemdetail")]
        Task<IActionResult> GetTimetableReportView([FromQuery]int birdTrainingReportId);

        [HttpPut]
        [Route("mark-trainingslotdone")]
        Task<IActionResult> MarkTrainingSlotDone(int birdTrainingProgressId);
    }
}
