using AppService;
using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.ApiParamModels.TrainingCourse;
using Models.ConfigModels;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using SP_Extension;
using SP_Middleware;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/trainingcourse-customer")]
    [ApiController]
    //[CustomAuthorize(roles: "Customer")]
    public class TrainingCourseCustomerController : TrainingCourseBaseController, ITrainingCourseCustomer
    {
        private readonly IFirebaseService _firebaseService;
        private readonly FirebaseBucket _bucket;
        public TrainingCourseCustomerController(ITrainingCourseService trainingCourseService, IAuthService authService, IFirebaseService firebaseService, IOptions<FirebaseBucket> bucket) : base(trainingCourseService)
        {
            _firebaseService = firebaseService;
            _bucket = bucket.Value;
        }
        [HttpPost]
        [Route("register-bird")]
        public async Task<IActionResult> RegisterBird([FromForm] BirdAddParamModel bird)
        {
            try
            {
                var pictures = string.Empty;
                if (bird.Pictures.Any(e => !e.IsImage()))
                {
                    return BadRequest("Upload image only!");
                }
                foreach (var file in bird.Pictures)
                {
                    var temp = await _firebaseService.UploadFile(file, file.FileName, FirebaseFolder.TRAININGCOURSE, _bucket.General);
                    pictures += $"{temp},";
                }
                pictures = pictures.Substring(0, pictures.Length - 1);
                var birdModel = bird.ToBirdAddModel(pictures);

                await _trainingCourseService.Customer.RegisterBird(birdModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        [Route("update-bird")]
        public async Task<IActionResult> UpdateBirdProfile([FromForm] BirdModifyParamModel bird)
        {
            try
            {
                var pictures = string.Empty;
                if (bird.Pictures.Any(e => !e.IsImage()))
                {
                    return BadRequest("Upload image only!");
                }
                foreach (var file in bird.Pictures)
                {
                    var temp = await _firebaseService.UploadFile(file, file.FileName, FirebaseFolder.TRAININGCOURSE, _bucket.General);
                    pictures += $"{temp},";
                }
                pictures = pictures.Substring(0, pictures.Length - 1);
                var birdModel = bird.ToBirdModifyModel(pictures);

                await _trainingCourseService.Customer.UpdateBirdProfile(birdModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("customer-bird")]
        public async Task<IActionResult> GetBirdByCustomerId([FromQuery] int customerId)
        {
            var result = await _trainingCourseService.Customer.GetBirdByCustomerId(customerId);
            return Ok(result);
        }
        [HttpGet]
        [Route("trainingcourse")]
        public async Task<IActionResult> GetTrainingCourse()
        {
            var result = await _trainingCourseService.Customer.GetTrainingCourse();
            return Ok(result);
        }
        [HttpGet]
        [Route("trainingcourse-species")]
        public async Task<IActionResult> GetTrainingCourseBySpeciesId([FromQuery] int birdSpeciesId)
        {
            var result = await _trainingCourseService.Customer.GetTrainingCourseBySpeciesId(birdSpeciesId);
            return Ok(result);
        }
        [HttpGet]
        [Route("trainingcourse-id")]
        public async Task<IActionResult> GetTrainingCourseById([FromQuery] int trainingCourseId)
        {
            var result = await _trainingCourseService.Customer.GetTrainingCourseById(trainingCourseId);
            return Ok(result);
        }
        [HttpPost]
        [Route("register-trainingcourse")]
        public async Task<IActionResult> RegisterTrainingCourse(BirdTrainingCourseRegister birdTrainingCourseRegister)
        {
            await _trainingCourseService.Customer.RegisterTrainingCourse(birdTrainingCourseRegister);
            return Ok();
        }
        [HttpGet]
        [Route("registered-birdtrainingcourseprogress")]
        public async Task<IActionResult> GetRegisteredBirdTrainingCourseProgress([FromQuery] int birdTrainingCourseId)
        {
            var result = await _trainingCourseService.Customer.ViewBirdTrainingCourseProgress(birdTrainingCourseId);
            return Ok(result);
        }
        [HttpGet]
        [Route("registered-birdtrainingcoursereport")]
        public async Task<IActionResult> GetRegisteredBirdTrainingCourseReport([FromQuery] int birdTrainingProgressId)
        {
            var result = await _trainingCourseService.Customer.ViewBirdTrainingCourseReport(birdTrainingProgressId);
            return Ok(result);
        }
        [HttpGet]
        [Route("registered-birdtrainingcourse")]
        public async Task<IActionResult> GetRegisteredTrainingCourse([FromQuery] int birdId, [FromQuery] int customerId)
        {
            var result = await _trainingCourseService.Customer.ViewRegisteredTrainingCourse(birdId: birdId, customerId: customerId);
            return Ok(result);
        }
    }
}
