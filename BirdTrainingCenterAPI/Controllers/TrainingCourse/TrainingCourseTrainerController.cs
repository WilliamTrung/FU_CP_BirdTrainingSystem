using AppService;
using AppService.Implementation;
using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Google.Apis.Storage.v1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.ApiParamModels.TrainingCourse;
using Models.ConfigModels;
using SP_Extension;
using SP_Middleware;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/trainingcourse-trainer")]
    [ApiController]
    //[CustomAuthorize(roles: "Trainer")]
    public class TrainingCourseTrainerController : TrainingCourseBaseController, ITrainingCourseTrainer
    {
        private readonly IFirebaseService _firebaseService;
        private readonly FirebaseBucket _bucket;
        public TrainingCourseTrainerController(ITrainingCourseService trainingCourseService, IAuthService authService, IFirebaseService firebaseService, IOptions<FirebaseBucket> bucket) : base(trainingCourseService, authService)
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
        [Route("mark-trainingskilldone")]
        public async Task<IActionResult> MarkTrainingSkillDone([FromForm] TrainerMarkDoneParamModel markDone)
        {
            var pictures = string.Empty;
            if(markDone.Evidences == null)
            {
                return BadRequest("Please upload evidences video");
            }
            else
            {
                if (markDone.Evidences.Any(e => !e.IsVideo()))
                {
                    return BadRequest("Upload video only!");
                }
                foreach (var file in markDone.Evidences)
                {
                    string fileName = $"{nameof(MarkTrainingSkillDone)}-{markDone.Id}-{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
                    var temp = await _firebaseService.UploadFile(file, fileName, FirebaseFolder.TRAININGCOURSE, _bucket.General);
                    pictures += $"{temp},";
                }
                pictures = pictures.Substring(0, pictures.Length - 1);
            }
            var markSkillDone = markDone.ToMarkSkill(pictures);

            await _trainingCourseService.Trainer.MarkTrainingSkillDone(markSkillDone);
            return Ok();
        }
        [HttpPut]
        [Route("mark-trainingslotdone")]
        public async Task<IActionResult> MarkTrainingSlotDone([FromQuery] int birdTrainingReportId)
        {
            var result = await _trainingCourseService.Trainer.MarkTrainingSlotDone(birdTrainingReportId);
            if (result == (int)Models.Enum.BirdTrainingReport.FirstOrEnd.EndSlot)
            {
                return StatusCode(206);
            }
            else
            {
                return Ok();
            }
        }
    }
}
