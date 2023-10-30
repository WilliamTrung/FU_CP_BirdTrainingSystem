using AppService;
using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.ApiParamModels.TrainingCourse;
using Models.ConfigModels;
using Models.ServiceModels.TrainingCourseModels;
using SP_Middleware;
using SP_Extension;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/trainingcourse-manager")]
    [CustomAuthorize(roles: "Manager")]
    [ApiController]
    public class TrainingCourseManagerController : TrainingCourseBaseController, ITrainingCourseManager
    {
        private readonly IFirebaseService _firebaseService;
        private readonly FirebaseBucket _bucket;
        public TrainingCourseManagerController(ITrainingCourseService trainingCourseService, IAuthService authService, IFirebaseService firebaseService, IOptions<FirebaseBucket> bucket) : base(trainingCourseService)
        {
            _firebaseService = firebaseService;
            _bucket = bucket.Value;
        }
        [HttpPut]
        [Route("active")]
        public async Task<IActionResult> ActiveTrainingCourse([FromQuery] int trainingCourseId)
        {
            await _trainingCourseService.Manager.ActiveTrainingCourse(trainingCourseId);
            return Ok();
        }
        [HttpPost]
        [Route("add-skill")]
        public async Task<IActionResult> AddSkill([FromBody] TrainingCourseSkillModel trainingCourseSkill)
        {
            await _trainingCourseService.Manager.AddSkill(trainingCourseSkill);
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateCourse([FromForm] TrainingCourseParamModel trainingCourse)
        {
            try
            {
                var pictures = string.Empty;
                if (trainingCourse.Pictures.Any(e => !e.IsImage()))
                {
                    return BadRequest("Upload image only!");
                }
                foreach (var file in trainingCourse.Pictures)
                {
                    var temp = await _firebaseService.UploadFile(file, file.FileName, FirebaseFolder.TRAININGCOURSE, _bucket.General);
                    pictures += $"{temp},";
                }
                pictures = pictures.Substring(0, pictures.Length - 1);
                var trainingCourseModel = trainingCourse.ToTrainingCourseModel(pictures);

                await _trainingCourseService.Manager.CreateCourse(trainingCourseModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        [Route("disable")]
        public async Task<IActionResult> DisableTrainingCourse([FromQuery] int trainingCourseId)
        {
            await _trainingCourseService.Manager.DisableTrainingCourse(trainingCourseId);
            return Ok();
        }
        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditCourse([FromForm] TrainingCourseParamModel trainingCourse)
        {
            try
            {
                var pictures = string.Empty;
                if (trainingCourse.Pictures.Any(e => !e.IsImage()))
                {
                    return BadRequest("Upload image only!");
                }
                foreach (var file in trainingCourse.Pictures)
                {
                    var temp = await _firebaseService.UploadFile(file, file.FileName, FirebaseFolder.TRAININGCOURSE, _bucket.General);
                    pictures += $"{temp},";
                }
                pictures = pictures.Substring(0, pictures.Length - 1);
                var trainingCourseModel = trainingCourse.ToTrainingCourseModel(pictures);

                await _trainingCourseService.Manager.EditCourse(trainingCourseModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
