using AppService;
using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.ApiParamModels.TrainingCourse;
using Models.ConfigModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using SP_Middleware;
using Models.ServiceModels.TrainingCourseModels.TrainerSlot;
using System;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
using BirdTrainingCenterAPI.Helper;
using Models.AuthModels;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/trainingcourse-staff")]
    [ApiController]
    //[CustomAuthorize(roles: "Staff")]
    public class TrainingCourseStaffController : TrainingCourseBaseController, ITrainingCourseStaff
    {
        private readonly IFirebaseService _firebaseService;
        private readonly FirebaseBucket _bucket;
        public TrainingCourseStaffController(ITrainingCourseService trainingCourseService, IAuthService authService, IFirebaseService firebaseService, IOptions<FirebaseBucket> bucket) : base(trainingCourseService, authService)
        {
            _firebaseService = firebaseService;
            _bucket = bucket.Value;
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
        [HttpGet]
        [Route("birdtrainingcourse-customer")]
        public async Task<IActionResult> GetBirdTrainingCourseByCustomerId([FromQuery] int customerId)
        {
            var result = await _trainingCourseService.Staff.GetBirdTrainingCourseByCustomerId(customerId);
            return Ok(result);
        }
        [HttpGet]
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
        [Route("birdtrainingprogress-requestedId")]
        public async Task<IActionResult> GetBirdTrainingCourseProgressByBirdTrainingCourseId([FromQuery] int birdTrainingCourseId)
        {
            var result = await _trainingCourseService.Staff.GetTrainingCourseSkill(birdTrainingCourseId);
            return Ok(result);
        }
        [HttpPut]
        [Route("receive-bird")]
        public async Task<IActionResult> ReceiveBird([FromForm] ReceiveBirdParamModel birdTrainingCourse)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            else
            {
                var staffId = accessToken.First(c => c.Type == CustomClaimTypes.Id);

                var pictures = string.Empty;
                if (birdTrainingCourse.ReceivePictures.Any(e => !e.IsImage()))
                {
                    return BadRequest("Upload image only!");
                }
                foreach (var file in birdTrainingCourse.ReceivePictures)
                {
                    string fileName = $"{nameof(ReceiveBird)}-{birdTrainingCourse.Id}-{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
                    var temp = await _firebaseService.UploadFile(file, fileName, FirebaseFolder.TRAININGCOURSE, _bucket.General);
                    pictures += $"{temp},";
                }
                pictures = pictures.Substring(0, pictures.Length - 1);
                var birdTrainingCourseModel = birdTrainingCourse.ToBirdTrainingCourseReceiveBird(pictures);
                birdTrainingCourseModel.ReceiveStaffId = Int32.Parse(staffId.Value);

                await _trainingCourseService.Staff.ReceiveBird(birdTrainingCourseModel);
                return Ok();
            }
        }
        [HttpPut]
        [Route("return-bird")]
        public async Task<IActionResult> ReturnBird([FromForm] ReturnBirdParamModel birdTrainingCourse)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            else
            {
                var staffId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
                var pictures = string.Empty;
                if (birdTrainingCourse.ReturnPictures.Any(e => !e.IsImage()))
                {
                    return BadRequest("Upload image only!");
                }
                foreach (var file in birdTrainingCourse.ReturnPictures)
                {
                    string fileName = $"{nameof(ReturnBird)}-{birdTrainingCourse.Id}-{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
                    var temp = await _firebaseService.UploadFile(file, fileName, FirebaseFolder.TRAININGCOURSE, _bucket.General);
                    pictures += $"{temp},";
                }
                pictures = pictures.Substring(0, pictures.Length - 1);
                var birdTrainingCourseModel = birdTrainingCourse.ToBirdTrainingCourseReturnBird(pictures);
                birdTrainingCourseModel.ReturnStaffId = Int32.Parse(staffId.Value);

                await _trainingCourseService.Staff.ReturnBird(birdTrainingCourseModel);
                return Ok();
            }
        }
        [HttpPost]
        [Route("birdtrainingcourse-confirm")]
        public async Task<IActionResult> ConfirmBirdTrainingCourse([FromQuery] int birdTrainingCourseId)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            else
            {
                var staffId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
                BirdTrainingCourseConfirm confirmModel = new BirdTrainingCourseConfirm()
                {
                    BirdTrainingCourseId = birdTrainingCourseId,
                    StaffId = Int32.Parse(staffId.Value)
                };
                var result = await _trainingCourseService.Staff.ConfirmBirdTrainingCourse(confirmModel);
                return Ok(result);
            }

            //BirdTrainingCourseConfirm confirmModel = new BirdTrainingCourseConfirm()
            //{
            //    BirdTrainingCourseId = birdTrainingCourseId,
            //    StaffId = 8
            //};
            //var result = await _trainingCourseService.Staff.ConfirmBirdTrainingCourse(confirmModel);
            //return Ok();
        }
        [HttpPost]
        [Route("birdtrainingcourse-cancel")]
        public async Task<IActionResult> CancelBirdTrainingCourse(int birdTrainingCourseId)
        {
            await _trainingCourseService.Staff.CancelBirdTrainingCourse(birdTrainingCourseId);
            return Ok();
        }
        [HttpGet]
        [Route("birdtrainingreport-progressid")]
        public async Task<IActionResult> GetReportByProgressId([FromQuery] int progressId)
        {
            var result = await _trainingCourseService.Staff.GetReportByProgressId(progressId);
            return Ok(result);
        }

        [HttpPut]
        [Route("trainerslot-modify")]
        public async Task<IActionResult> ModifyTrainingSlot([FromBody] ReportModifyModel reportModModel)
        {
            await _trainingCourseService.Staff.ModifyTrainingSlot(reportModModel);
            return Ok();
        }
        [HttpPut]
        [Route("assigntrainertoprogress")]
        public async Task<IActionResult> AssignTrainer(int progressId, int trainerId)
        {
            var result = await _trainingCourseService.Staff.AssignTrainer(progressId, trainerId);
            return Ok(result);
        }
        //[HttpPost]
        //[Route("birdcertificatedetail")]
        //public async Task<IActionResult> CreateBirdCertificateDetail([FromBody] BirdCertificateDetailAddModel birdCertificateDetailAdd)
        //{
        //    await _trainingCourseService.Staff.CreateBirdCertificateDetail(birdCertificateDetailAdd);
        //    return Ok();
        //}

        //[HttpPost]
        //[Route("generatedprogresstimetable-confirm")]
        //public async Task<IActionResult> Generatedprogresstimetable(List<int> birdTrainingProgressId)
        //{
        //    await _trainingCourseService.Staff.GenerateTrainerTimetable(birdTrainingProgressId);
        //    return Ok();
        //}
    }
}
