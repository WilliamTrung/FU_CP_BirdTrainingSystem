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
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.Entities;
using Models.Skills;
using Models.ServiceModels.TrainingCourseModels.TrainingCourseCheckOutPolicy;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/trainingcourse-manager")]
    [CustomAuthorize(roles: "Manager")]
    [ApiController]
    public class TrainingCourseManagerController : TrainingCourseBaseController, ITrainingCourseManager
    {
        private readonly IFirebaseService _firebaseService;
        private readonly FirebaseBucket _bucket;
        public TrainingCourseManagerController(ITrainingCourseService trainingCourseService, IAuthService authService, IFirebaseService firebaseService, IOptions<FirebaseBucket> bucket) : base(trainingCourseService, authService)
        {
            _firebaseService = firebaseService;
            _bucket = bucket.Value;
        }

        [HttpPost]
        [Route("create-trainingcourse")]
        public async Task<IActionResult> CreateCourse([FromForm] TrainingCourseAddParamModel trainingCourse)
        {
            var pictures = string.Empty;
            if (trainingCourse.Pictures.Any(e => !e.IsImage()))
            {
                return BadRequest("Upload image only!");
            }
            foreach (var file in trainingCourse.Pictures)
            {
                string fileName = $"{nameof(TrainingCourseModel)}-{trainingCourse.Title}-{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
                var temp = await _firebaseService.UploadFile(file, fileName, FirebaseFolder.TRAININGCOURSE, _bucket.General);
                pictures += $"{temp},";
            }
            pictures = pictures.Substring(0, pictures.Length - 1);
            var trainingCourseModel = trainingCourse.ToTrainingCourseModel(pictures);

            await _trainingCourseService.Manager.CreateCourse(trainingCourseModel);
            return Ok();
        }

        [HttpPut]
        [Route("edit-trainingcourse")]
        public async Task<IActionResult> EditCourse([FromForm] TrainingCourseModParamModel trainingCourse)
        {
            var pictures = string.Empty;
            if(trainingCourse.Pictures != null)
            {
                if (trainingCourse.Pictures.Any(e => !e.IsImage()))
                {
                    return BadRequest("Upload image only!");
                }
                foreach (var file in trainingCourse.Pictures)
                {
                    string fileName = $"{nameof(TrainingCourseModel)}-{trainingCourse.Id}-{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
                    var temp = await _firebaseService.UploadFile(file, fileName, FirebaseFolder.TRAININGCOURSE, _bucket.General);
                    pictures += $"{temp},";
                }
                pictures = pictures.Substring(0, pictures.Length - 1);
            }
            else
            {
                pictures = null;
            }
            var trainingCourseModel = trainingCourse.ToTrainingCourseModel(pictures);

            await _trainingCourseService.Manager.EditCourse(trainingCourseModel);
            return Ok();
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
        public async Task<IActionResult> UpdateSkill([FromBody] AddTrainingSkillModel trainingSkillModel)
        {
            await _trainingCourseService.Manager.UpdateSkill(trainingSkillModel);
            return Ok();
        }

        [HttpDelete]
        [Route("delete-trainingskill")]
        public async Task<IActionResult> DeleteSkill([FromBody] DeleteTrainingSkillModel trainingSkillModel)
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
        public async Task<IActionResult> CreateBirdSkill([FromForm] BirdSkillAddParamModel birdSkillAdd)
        {
            var pictures = string.Empty;
            if (birdSkillAdd.Picture != null)
            {
                if (!birdSkillAdd.Picture.IsImage())
                {
                    return BadRequest("Upload image only!");
                }
                string fileName = $"{nameof(BirdCertificate)}-{birdSkillAdd.Name}-{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
                var temp = await _firebaseService.UploadFile(birdSkillAdd.Picture, fileName, FirebaseFolder.TRAININGCOURSE, _bucket.General);
                pictures += $"{temp},";
                pictures = pictures.Substring(0, pictures.Length - 1);
            }
            var birdSkillAddModel = birdSkillAdd.ToBirdSkillAddModel(pictures);
            await _trainingCourseService.Manager.CreateBirdSkill(birdSkillAddModel);
            return Ok();
        }

        [HttpPut]
        [Route("birdskill-update")]
        public async Task<IActionResult> EditBirdSkill([FromForm] BirdSkillModParamModel birdSkillMod)
        {
            var pictures = string.Empty;
            if(birdSkillMod.Picture != null)
            {
                if (!birdSkillMod.Picture.IsImage())
                {
                    return BadRequest("Upload image only!");
                }
                string fileName = $"{nameof(BirdCertificate)}-{birdSkillMod.Id}-{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
                var temp = await _firebaseService.UploadFile(birdSkillMod.Picture, fileName, FirebaseFolder.TRAININGCOURSE, _bucket.General);
                pictures += $"{temp},";
                pictures = pictures.Substring(0, pictures.Length - 1);
            }
            else
            {
                pictures = null;
            }
            var birdSkillModModel = birdSkillMod.ToBirdSkillModModel(pictures);
            await _trainingCourseService.Manager.EditBirdSkill(birdSkillModModel);
            return Ok();
        }

        [HttpPost]
        [Route("acquirablebirdskill-create")]
        public async Task<IActionResult> CreateAccquirableBirdSkill([FromBody] AcquirableAddModBirdSkill accquirableAdd)
        {
            await _trainingCourseService.Manager.CreateAccquirableBirdSkill(accquirableAdd);
            return Ok();
        }

        [HttpPut]
        [Route("acquirablebirdskill-update")]
        public async Task<IActionResult> EditAccquirableBirdSkill([FromBody] AcquirableAddModBirdSkill accquirableMod)
        {
            await _trainingCourseService.Manager.EditAccquirableBirdSkill(accquirableMod);
            return Ok();
        }
        #endregion
        #region Skill
        [HttpPost]
        [Route("skill-create")]
        public async Task<IActionResult> CreateSkill([FromBody] SkillAddModel skillAddModel)
        {
            await _trainingCourseService.Manager.CreateSkill(skillAddModel);
            return Ok();
        }

        [HttpPut]
        [Route("skill-update")]
        public async Task<IActionResult> EditSkill([FromBody] SkillViewModModel skillModModel)
        {
            await _trainingCourseService.Manager.EditSkill(skillModModel);
            return Ok();
        }

        [HttpPost]
        [Route("trainerskill-create")]
        public async Task<IActionResult> CreateTrainerSkill([FromBody] TrainerSkillAddModModel trainerSkillAdd)
        {
            await _trainingCourseService.Manager.CreateTrainerSkill(trainerSkillAdd);
            return Ok();
        }

        [HttpPut]
        [Route("trainerskill-update")]
        public async Task<IActionResult> EditTrainerSkill([FromBody] TrainerSkillAddModModel trainerSkillMod)
        {
            await _trainingCourseService.Manager.EditTrainerSkill(trainerSkillMod);
            return Ok();
        }

        [HttpPost]
        [Route("trainableskill-create")]
        public async Task<IActionResult> CreateTrainableSkill([FromBody] TrainableAddModSkillModel trainableSkillAdd)
        {
            await _trainingCourseService.Manager.CreateTrainableSkill(trainableSkillAdd);
            return Ok();
        }

        [HttpPut]
        [Route("trainableskill-udpate")]
        public async Task<IActionResult> EditTrainableSkill([FromBody] TrainableAddModSkillModel trainableSkillMod)
        {
            await _trainingCourseService.Manager.EditTrainableSkill(trainableSkillMod);
            return Ok();
        }
        #endregion
        [HttpPost]
        [Route("birdcertificate")]
        public async Task<IActionResult> CreateBirdCertitficate([FromForm] BirdCertificateAddParamModel birdCertificateAddParam)
        {
            var pictures = string.Empty;
            if(birdCertificateAddParam.Picture != null)
            {
                if (!birdCertificateAddParam.Picture.IsImage())
                {
                    return BadRequest("Upload image only!");
                }
                string fileName = $"{nameof(BirdCertificate)}-{birdCertificateAddParam.TrainingCourseId}-{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
                var temp = await _firebaseService.UploadFile(birdCertificateAddParam.Picture, fileName, FirebaseFolder.TRAININGCOURSE, _bucket.General);
                pictures += $"{temp},";
                pictures = pictures.Substring(0, pictures.Length - 1);
            }
            var birdCertificateAdd = birdCertificateAddParam.ToBirdCertificateAddModel(pictures);

            await _trainingCourseService.Manager.CreateBirdCertitficate(birdCertificateAdd);
            return Ok();
        }

        #region CheckOutPolicies
        [HttpPost]
        [Route("create-checkoutpolicy")]
        public async Task<IActionResult> CreateCheckOutPolicy([FromBody] PolicyAddModel policyAdd)
        {
            await _trainingCourseService.Manager.CreateCheckOutPolicy(policyAdd);
            return Ok();
        }

        [HttpPut]
        [Route("edit-checkoutpolicy")]
        public async Task<IActionResult> EditCheckOutPolicy([FromBody] PolicyModModel policyMod)
        {
            await _trainingCourseService.Manager.EditCheckOutPolicy(policyMod);
            return Ok();
        }

        [HttpPut]
        [Route("active-checkoutpolicy")]
        public async Task<IActionResult> ActiveCheckOutPolicy([FromQuery] int policyId)
        {
            await _trainingCourseService.Manager.ActiveCheckOutPolicy(policyId);
            return Ok();
        }

        [HttpPut]
        [Route("disable-checkoutpolicy")]
        public async Task<IActionResult> DisableCheckOutPolicy([FromQuery] int policyId)
        {
            await _trainingCourseService.Manager.DisableCheckOutPolicy(policyId);
            return Ok();
        }

        #endregion
    }
}
