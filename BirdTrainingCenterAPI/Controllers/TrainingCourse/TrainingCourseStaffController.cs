using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/trainingcourse-staff")]
    [ApiController]
    public class TrainingCourseStaffController : TrainingCourseBaseController, ITrainingCourseStaff
    {
        public TrainingCourseStaffController(ITrainingCourseService trainingCourseService) : base(trainingCourseService)
        {
        }

        [HttpPost]
        [Route("assign-trainer")]
        public async Task<IActionResult> AssignTrainer([FromBody] AssignTrainerToCourse assignTrainer)
        {
            await _trainingCourseService.Staff.AssignTrainer(assignTrainer);
            return Ok();
        }
        [HttpPost]
        [Route("generate-trainerslot")]
        public async Task<IActionResult> GenerateTrainerTimetable([FromBody] InitReportTrainerSlot report)
        {
            await _trainingCourseService.Staff.GenerateTrainerTimetable(report);
            return Ok();
        }
        [HttpGet]
        [Route("birdtrainingcourse")]
        public async Task<IActionResult> GetBirdTrainingCourse()
        {
            var result = await _trainingCourseService.Staff.GetBirdTrainingCourse();
            return Ok(result);
        }
        [HttpGet]
        [Route("birdtrainingcourse-bird")]
        public async Task<IActionResult> GetBirdTrainingCourseByBirdId([FromQuery] int birdId)
        {
            var result = await _trainingCourseService.Staff.GetBirdTrainingCourseByBirdId(birdId);
            return Ok(result);
        }
        [HttpPost]
        [Route("trainer")]
        public async Task<IActionResult> GetTrainer()
        {
            var result = await _trainingCourseService.Staff.GetTrainer();
            return Ok(result);
        }
        [HttpGet]
        [Route("trainer-birdskill")]
        public async Task<IActionResult> GetTrainerByBirdSkillId([FromQuery] int birdSkillId)
        {
            var result = await _trainingCourseService.Staff.GetTrainerByBirdSkillId(birdSkillId);
            return Ok(result);
        }
        [HttpPost]
        [Route("trainer-id")]
        public async Task<IActionResult> GetTrainerById([FromQuery] int trainerId)
        {
            var result = await _trainingCourseService.Staff.GetTrainerById(trainerId);
            return Ok(result);
        }
        [HttpPost]
        [Route("trainer-skill")]
        public async Task<IActionResult> GetTrainerByTrainerSkillId([FromQuery] int trainerSkillId)
        {
            var result = await _trainingCourseService.Staff.GetTrainerByTrainerSkillId(trainerSkillId);
            return Ok(result);
        }
        [HttpGet]
        [Route("birdtrainingcourse-skill")]
        public async Task<IActionResult> GetTrainingCourseSkill([FromQuery] int trainingCourseId)
        {
            var result = await _trainingCourseService.Staff.GetTrainingCourseSkill(trainingCourseId);
            return Ok(result);
        }
        [HttpPut]
        [Route("modify-birdtrainingcourse-starttime")]
        public async Task<IActionResult> InitStartTime([FromBody] BirdTrainingCourseStartTime birdTrainingCourse)
        {
            await _trainingCourseService.Staff.InitStartTime(birdTrainingCourse);
            return Ok();
        }
        [HttpPut]
        [Route("receive-bird")]
        public async Task<IActionResult> ReceiveBird([FromBody] BirdTrainingCourseReceiveBird birdTrainingCourse)
        {
            await _trainingCourseService.Staff.ReceiveBird(birdTrainingCourse);
            return Ok();
        }
        [HttpPut]
        [Route("return-bird")]
        public async Task<IActionResult> ReturnBird([FromBody] BirdTrainingCourseReturnBird birdTrainingCourse)
        {
            await _trainingCourseService.Staff.ReturnBird(birdTrainingCourse);
            return Ok();
        }
    }
}
