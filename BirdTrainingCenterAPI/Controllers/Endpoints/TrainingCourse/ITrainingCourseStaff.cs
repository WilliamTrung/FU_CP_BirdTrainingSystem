using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.TrainingCourse;
using Models.ServiceModels.TrainingCourseModels.TrainerSlot;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse
{
    public interface ITrainingCourseStaff : ITrainingCourseAll
    {
        [HttpGet]
        [Route("birdtrainingcourse")]
        Task<IActionResult> GetBirdTrainingCourse();

        [HttpGet]
        [Route("birdtrainingcourse-bird")]
        Task<IActionResult> GetBirdTrainingCourseByBirdId([FromQuery] int birdId);

        [HttpGet]
        [Route("birdtrainingcourse-customer")]
        Task<IActionResult> GetBirdTrainingCourseByCustomerId(int customerId);

        //[HttpPost]
        //[Route("confirm-birdtrainingcourse")]
        //Task ConfirmBirdTrainingCourse(int birdTrainingCourseId);

        [HttpGet]
        [Route("birdtrainingprogress-skill")]
        Task<IActionResult> GetTrainingCourseSkill([FromQuery] int birdTrainingCourseId);

        [HttpGet]
        [Route("trainer")]
        Task<IActionResult> GetTrainer();

        [HttpGet]
        [Route("trainer-birdskill")]
        Task<IActionResult> GetTrainerByBirdSkillId([FromQuery] int birdSkillId);

        [HttpPost]
        [Route("trainer-id")]
        Task<IActionResult> GetTrainerById([FromQuery] int trainerId);

        [HttpPost]
        [Route("trainer-skill")]
        Task<IActionResult> GetTrainerByTrainerSkillId([FromQuery] int trainerSkillId);

        [HttpPost]
        [Route("assign-trainer")]
        Task<IActionResult> AssignTrainer([FromBody] AssignTrainerToCourse assignTrainer);

        [HttpPost]
        [Route("generate-trainerslot")]
        Task<IActionResult> GenerateTrainerTimetable([FromBody] IEnumerable<int> progressId);

        [HttpPut]
        [Route("modify-trainerslot")]
        Task<IActionResult> ModifyTrainerSlot([FromBody] ModifyTrainerSlot trainerSlot);

        [HttpPut]
        [Route("modify-birdtrainingcourse-starttime")]
        Task<IActionResult> InitStartTime([FromBody] BirdTrainingCourseStartTime birdTrainingCourse);

        [HttpPut]
        [Route("receive-bird")]
        Task<IActionResult> ReceiveBird([FromForm] ReceiveBirdParamModel birdTrainingCourse);

        [HttpPut]
        [Route("return-bird")]
        Task<IActionResult> ReturnBird([FromForm] ReturnBirdParamModel birdTrainingCourse);
        //Task Update(BirdTrainingProgressModel birdTrainingProgress);
    }
}
