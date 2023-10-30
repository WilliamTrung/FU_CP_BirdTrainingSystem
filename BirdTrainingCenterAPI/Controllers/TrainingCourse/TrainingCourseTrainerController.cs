using AppService;
using AppService.Implementation;
using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Google.Apis.Storage.v1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.ApiParamModels.TrainingCourse;
using Models.ConfigModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using SP_Extension;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/trainingcourse-trainer")]
    [ApiController]
    public class TrainingCourseTrainerController : TrainingCourseBaseController, ITrainingCourseTrainer
    {
        private readonly IFirebaseService _firebaseService;
        private readonly FirebaseBucket _bucket;
        public TrainingCourseTrainerController(ITrainingCourseService trainingCourseService, IAuthService authService, IFirebaseService firebaseService, IOptions<FirebaseBucket> bucket) : base(trainingCourseService)
        {
            _firebaseService = firebaseService;
            _bucket = bucket.Value;
        }
        [HttpGet]
        [Route("birdtrainingprogress-trainer")]
        public async Task<IActionResult> GetBirdTrainingProgressByTrainerId([FromQuery] int trainerId)
        {
            var result = await _trainingCourseService.Trainer.GetBirdTrainingProgressByTrainerId(trainerId);
            return Ok(result);
        }

        [HttpGet]
        [Route("timetable-slot-itemdetail")]
        public async Task<IActionResult> GetTimetableReportView([FromQuery] int birdTrainingReportId)
        {
            var result = await _trainingCourseService.Trainer.GetTimetableReportView(birdTrainingReportId);
            return Ok(result);
        }

        [HttpPut]
        [Route("mark-trainingdone")]
        public async Task<IActionResult> MarkTrainingSkillDone([FromForm] TrainerMarkDoneParamModel markDone)
        {
            try
            {
                var pictures = string.Empty;
                if (markDone.Evidences.Any(e => !e.IsImage()))
                {
                    return BadRequest("Upload image only!");
                }
                else if (markDone.Evidences.Any(e => !e.IsVideo()))
                {
                    return BadRequest("Upload image only!");
                }
                foreach (var file in markDone.Evidences)
                {
                    var temp = await _firebaseService.UploadFile(file, file.FileName, FirebaseFolder.TRAININGCOURSE, _bucket.General);
                    pictures += $"{temp},";
                }
                pictures = pictures.Substring(0, pictures.Length - 1);
                var markSkillDone = markDone.ToMarkSkill(pictures);

                await _trainingCourseService.Trainer.MarkTrainingSkillDone(markSkillDone);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
