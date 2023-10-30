using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using Models.ServiceModels.TrainingCourseModels;
using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.TrainingCourse;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse
{
    public interface ITrainingCourseStaff
    {
        [HttpGet]
        [Route("birdtrainingcourse")]
        Task<IActionResult> GetBirdTrainingCourse();

        [HttpGet]
        [Route("birdtrainingcourse-skill")]
        Task<IActionResult> GetTrainingCourseSkill([FromQuery] int trainingCourseId);

        [HttpGet]
        [Route("trainer-birdskill")]
        Task<IActionResult> GetTrainerByBirdSkillId([FromQuery] int birdSkillId);

        [HttpPost]
        [Route("assign-trainer")]
        Task<IActionResult> AssignTrainer([FromBody] AssignTrainerToCourse assignTrainer);

        [HttpPost]
        [Route("generate-trainerslot")]
        Task<IActionResult> GenerateTrainerTimetable([FromBody] InitReportTrainerSlot report);

        [HttpPut]
        [Route("modify-birdtrainingcourse-starttime")]
        Task<IActionResult> InitStartTime([FromBody] BirdTrainingCourseStartTime birdTrainingCourse);

        [HttpPut]
        [Route("modify-trainerslot")]
        Task<IActionResult> ModifyTrainerSlot([FromBody] ModifyTrainerSlot trainerSlot);

        [HttpPut]
        [Route("receive-bird")]
        Task<IActionResult> ReceiveBird([FromForm] ReceiveBirdParamModel birdTrainingCourse);

        [HttpPut]
        [Route("return-bird")]
        Task<IActionResult> ReturnBird([FromForm] ReturnBirdParamModel birdTrainingCourse);
        //Task Update(BirdTrainingProgressModel birdTrainingProgress);

        [HttpGet]
        [Route("birdtrainingcourse-bird")]
        Task<IActionResult> GetBirdTrainingCourseByBirdId([FromQuery] int birdId);

        [HttpGet]
        [Route("birdtrainingcourse-customer")]
        Task<IActionResult> GetBirdTrainingCourseByCustomerId(int customerId);

        [HttpPost]
        [Route("trainer")]
        Task<IActionResult> GetTrainer();

        [HttpPost]
        [Route("trainer-id")]
        Task<IActionResult> GetTrainerById([FromQuery] int trainerId);

        [HttpPost]
        [Route("trainer-skill")]
        Task<IActionResult> GetTrainerByTrainerSkillId([FromQuery] int trainerSkillId);
    }
}
