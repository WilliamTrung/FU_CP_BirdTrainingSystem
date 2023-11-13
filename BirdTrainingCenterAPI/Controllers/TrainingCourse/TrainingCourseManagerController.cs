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
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/trainingcourse-manager")]
    //[CustomAuthorize(roles: "Manager")]
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

        [HttpPost]
        [Route("create-trainingcourse")]
        public async Task<IActionResult> CreateCourse([FromForm] TrainingCourseAddParamModel trainingCourse)
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
        [Route("edit-trainingcourse")]
        public async Task<IActionResult> EditCourse([FromForm] TrainingCourseModParamModel trainingCourse)
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

        [HttpPut]
        [Route("active-trainingcourse")]
        public async Task<IActionResult> ActiveTrainingCourse([FromQuery] int trainingCourseId)
        {
            await _trainingCourseService.Manager.ActiveTrainingCourse(trainingCourseId);
            return Ok();
        }

        [HttpPut]
        [Route("disable-trainingcourse")]
        public async Task<IActionResult> DisableTrainingCourse([FromQuery] int trainingCourseId)
        {
            await _trainingCourseService.Manager.DisableTrainingCourse(trainingCourseId);
            return Ok();
        }

        [HttpPost]
        [Route("add-trainingskill")]
        public async Task<IActionResult> AddSkill([FromBody] AddTrainingSkillModel trainingCourseSkill)
        {
            await _trainingCourseService.Manager.AddSkill(trainingCourseSkill);
            return Ok();
        }

        [HttpPut]
        [Route("update-trainingskill")]
        public async Task<IActionResult> UpdateSkill(AddTrainingSkillModel trainingSkillModel)
        {
            await _trainingCourseService.Manager.UpdateSkill(trainingSkillModel);
            return Ok();
        }

        [HttpDelete]
        [Route("delete-trainingskill")]
        public async Task<IActionResult> DeleteSkill(DeleteTrainingSkillModel trainingSkillModel)
        {
            await _trainingCourseService.Manager.DeleteSkill(trainingSkillModel);
            return Ok();
        }

        [HttpPost]
        [Route("birdspecies")]
        public async Task<IActionResult> CreateBirdSpecies([FromBody] BirdSpeciesAddModel birdSpecies)
        {
            await _trainingCourseService.Manager.CreateBirdSpecies(birdSpecies);
            return Ok();
        }

        [HttpPut]
        [Route("birdspecies")]
        public async Task<IActionResult> EditBirdSpecies([FromBody] BirdSpeciesViewModel birdSpecies)
        {
            await _trainingCourseService.Manager.EditBirdSpecies(birdSpecies);
            return Ok();
        }

        #region BirdSkill
        [HttpPost]
        [Route("birdskill-create")]
        public async Task<IActionResult> CreateBirdSkill(BirdSkillAddModel birdSkillAdd)
        {
            await _trainingCourseService.Manager.CreateBirdSkill(birdSkillAdd);
            return Ok();
        }

        [HttpPut]
        [Route("birdskill-update")]
        public async Task<IActionResult> EditBirdSkill(BirdSkillModModel birdSkillMod)
        {
            await _trainingCourseService.Manager.EditBirdSkill(birdSkillMod);
            return Ok();
        }

        [HttpGet]
        [Route("birdskill")]
        public async Task<IActionResult> GetBirdSkills()
        {
            var result = await _trainingCourseService.Manager.GetBirdSkills();
            return Ok(result);
        }

        [HttpGet]
        [Route("birdskill-id")]
        public async Task<IActionResult> GetBirdSkillsById(int birdSkillId)
        {
            var result = await _trainingCourseService.Manager.GetBirdSkillsById(birdSkillId);
            return Ok(result);
        }

        [HttpPost]
        [Route("acquirablebirdskill-create")]
        public async Task<IActionResult> CreateAccquirableBirdSkill(AccquirableAddModBirdSkill accquirableAdd)
        {
            await _trainingCourseService.Manager.CreateAccquirableBirdSkill(accquirableAdd);
            return Ok();
        }

        [HttpPut]
        [Route("acquirablebirdskill-update")]
        public async Task<IActionResult> EditAccquirableBirdSkill(AccquirableAddModBirdSkill accquirableMod)
        {
            await _trainingCourseService.Manager.EditAccquirableBirdSkill(accquirableMod);
            return Ok();
        }
        #endregion
        #region Skill
        [HttpPost]
        [Route("skill-create")]
        public async Task<IActionResult> CreateSkill(SkillAddModel skillAddModel)
        {
            await _trainingCourseService.Manager.CreateSkill(skillAddModel);
            return Ok();
        }

        [HttpPut]
        [Route("skill-update")]
        public async Task<IActionResult> EditSkill(SkillViewModModel skillModModel)
        {
            await _trainingCourseService.Manager.EditSkill(skillModModel);
            return Ok();
        }

        [HttpGet]
        [Route("skill")]
        public async Task<IActionResult> GetSkills()
        {
            var result = await _trainingCourseService.Manager.GetSkills();
            return Ok(result);
        }

        [HttpGet]
        [Route("skill-id")]
        public async Task<IActionResult> GetSkillById(int skillId)
        {
            var result = await _trainingCourseService.Manager.GetSkillById(skillId);
            return Ok(result);
        }

        [HttpPost]
        [Route("trainerskill-create")]
        public async Task<IActionResult> CreateTrainerSkill(TrainerSkillAddModModel trainerSkillAdd)
        {
            await _trainingCourseService.Manager.CreateTrainerSkill(trainerSkillAdd);
            return Ok();
        }

        [HttpPut]
        [Route("trainerskill-update")]
        public async Task<IActionResult> EditTrainerSkill(TrainerSkillAddModModel trainerSkillMod)
        {
            await _trainingCourseService.Manager.EditTrainerSkill(trainerSkillMod);
            return Ok();
        }

        [HttpGet]
        [Route("trainerskill")]
        public async Task<IActionResult> GetTrainerSkills()
        {
            var result = await _trainingCourseService.Manager.GetTrainerSkills();
            return Ok(result);
        }

        [HttpGet]
        [Route("trainerskill-trainerid")]
        public async Task<IActionResult> GetTrainerSkillsByTrainerId(int trainerId)
        {
            var result = await _trainingCourseService.Manager.GetTrainerSkillsByTrainerId(trainerId);
            return Ok(result);
        }

        [HttpPost]
        [Route("trainableskill-create")]
        public async Task<IActionResult> CreateTrainableSkill(TrainableAddModSkillModel trainableSkillAdd)
        {
            await _trainingCourseService.Manager.CreateTrainableSkill(trainableSkillAdd);
            return Ok();
        }

        [HttpPut]
        [Route("trainableskill-udpate")]
        public async Task<IActionResult> EditTrainableSkill(TrainableAddModSkillModel trainableSkillMod)
        {
            await _trainingCourseService.Manager.EditTrainableSkill(trainableSkillMod);
            return Ok();
        }

        [HttpGet]
        [Route("trainableskill")]
        public async Task<IActionResult> GetTrainableSkills()
        {
            var result = await _trainingCourseService.Manager.GetTrainableSkills();
            return Ok(result);
        }
        #endregion
        [HttpPost]
        [Route("birdcertificate")]
        public async Task<IActionResult> CreateBirdCertitficate(BirdCertificateAddParamModel birdCertificateAddParam)
        {
            try
            {
                var pictures = string.Empty;
                if (birdCertificateAddParam.Pictures.Any(e => !e.IsImage()))
                {
                    return BadRequest("Upload image only!");
                }
                foreach (var file in birdCertificateAddParam.Pictures)
                {
                    var temp = await _firebaseService.UploadFile(file, file.FileName, FirebaseFolder.TRAININGCOURSE, _bucket.General);
                    pictures += $"{temp},";
                }
                pictures = pictures.Substring(0, pictures.Length - 1);
                var birdCertificateAdd = birdCertificateAddParam.ToBirdCertificateAddModel(pictures);

                await _trainingCourseService.Manager.CreateBirdCertitficate(birdCertificateAdd);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
