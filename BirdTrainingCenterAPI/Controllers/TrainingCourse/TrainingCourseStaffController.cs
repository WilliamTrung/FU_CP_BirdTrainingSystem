using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    public class TrainingCourseStaffController : TrainingCourseBaseController, ITrainingCourseStaff
    {
        public TrainingCourseStaffController(ITrainingCourseService trainingCourseService) : base(trainingCourseService)
        {
        }

        public async Task<IActionResult> AssignTrainer([FromBody] AssignTrainerToCourse assignTrainer)
        {
            await _trainingCourseService.Staff.AssignTrainer(assignTrainer);
            return Ok();
        }

        public async Task<IActionResult> GenerateTrainerTimetable([FromBody] InitReportTrainerSlot report)
        {
            await _trainingCourseService.Staff.GenerateTrainerTimetable(report);
            return Ok();
        }

        public async Task<IActionResult> GetBirdTrainingCourse()
        {
            var result = await _trainingCourseService.Staff.GetBirdTrainingCourse();
            return Ok(result);
        }

        public async Task<IActionResult> GetBirdTrainingCourseByBirdId([FromQuery] int birdId)
        {
            var result = await _trainingCourseService.Staff.GetBirdTrainingCourseByBirdId(birdId);
            return Ok(result);
        }

        public async Task<IActionResult> GetTrainer()
        {
            var result = await _trainingCourseService.Staff.GetTrainer();
            return Ok(result);
        }

        public async Task<IActionResult> GetTrainerByBirdSkillId([FromQuery] int birdSkillId)
        {
            var result = await _trainingCourseService.Staff.GetTrainerByBirdSkillId(birdSkillId);
            return Ok(result);
        }

        public async Task<IActionResult> GetTrainerById([FromQuery] int trainerId)
        {
            var result = await _trainingCourseService.Staff.GetTrainerById(trainerId);
            return Ok(result);
        }

        public async Task<IActionResult> GetTrainerByTrainerSkillId([FromQuery] int trainerSkillId)
        {
            var result = await _trainingCourseService.Staff.GetTrainerByTrainerSkillId(trainerSkillId);
            return Ok(result);
        }

        public async Task<IActionResult> GetTrainingCourseSkill([FromQuery] int trainingCourseId)
        {
            var result = await _trainingCourseService.Staff.GetTrainingCourseSkill(trainingCourseId);
            return Ok(result);
        }

        public async Task<IActionResult> InitStartTime([FromBody] BirdTrainingCourseStartTime birdTrainingCourse)
        {
            await _trainingCourseService.Staff.InitStartTime(birdTrainingCourse);
            return Ok();
        }

        public async Task<IActionResult> ReceiveBird([FromBody] BirdTrainingCourseReceiveBird birdTrainingCourse)
        {
            await _trainingCourseService.Staff.ReceiveBird(birdTrainingCourse);
            return Ok();
        }

        public async Task<IActionResult> ReturnBird([FromBody] BirdTrainingCourseReturnBird birdTrainingCourse)
        {
            await _trainingCourseService.Staff.ReturnBird(birdTrainingCourse);
            return Ok();
        }
    }
}
