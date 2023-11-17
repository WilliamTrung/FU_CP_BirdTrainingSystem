using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.TrainingCourse;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse
{
    public interface ITrainingCourseManager : ITrainingCourseAll
    {
        [HttpPost]
        [Route("create-trainingcourse")]
        Task<IActionResult> CreateCourse([FromForm] TrainingCourseAddParamModel trainingCourse);

        [HttpPut]
        [Route("edit-trainingcourse")]
        Task<IActionResult> EditCourse([FromForm] TrainingCourseModParamModel trainingCourse);

        [HttpPut]
        [Route("active-trainingcourse")]
        Task<IActionResult> ActiveTrainingCourse([FromQuery] int trainingCourseId);

        [HttpPut]
        [Route("disable-trainingcourse")]
        Task<IActionResult> DisableTrainingCourse([FromQuery] int trainingCourseId);

        [HttpPost]
        [Route("add-trainingskill")]
        Task<IActionResult> AddSkill([FromBody] AddTrainingSkillModel trainingCourseSkill);

        [HttpPut]
        [Route("update-trainingskill")]
        Task<IActionResult> UpdateSkill(AddTrainingSkillModel trainingSkillModel);

        [HttpDelete]
        [Route("delete-trainingskill")]
        Task<IActionResult> DeleteSkill(DeleteTrainingSkillModel trainingSkillModel);

        [HttpPost]
        [Route("birdspecies")]
        Task<IActionResult> CreateBirdSpecies([FromBody] BirdSpeciesAddModel birdSpecies);

        [HttpPut]
        [Route("birdspecies")]
        Task<IActionResult> EditBirdSpecies([FromBody] BirdSpeciesViewModel birdSpecies);


        #region BirdSkill
        [HttpPost]
        [Route("birdskill-create")]
        Task<IActionResult> CreateBirdSkill(BirdSkillAddParamModel birdSkillAdd);

        [HttpPut]
        [Route("birdskill-update")]
        Task<IActionResult> EditBirdSkill(BirdSkillModParamModel birdSkillMod);

        [HttpPost]
        [Route("acquirablebirdskill-create")]
        Task<IActionResult> CreateAccquirableBirdSkill(AcquirableAddModBirdSkill accquirableAdd);

        [HttpPut]
        [Route("acquirablebirdskill-update")]
        Task<IActionResult> EditAccquirableBirdSkill(AcquirableAddModBirdSkill accquirableMod);
        #endregion

        #region Skill
        [HttpPost]
        [Route("skill-create")]
        Task<IActionResult> CreateSkill(SkillAddModel skillAddModel);

        [HttpPut]
        [Route("skill-update")]
        Task<IActionResult> EditSkill(SkillViewModModel skillModModel);

        [HttpPost]
        [Route("trainerskill-create")]
        Task<IActionResult> CreateTrainerSkill(TrainerSkillAddModModel trainerSkillAdd);

        [HttpPut]
        [Route("trainerskill-update")]
        Task<IActionResult> EditTrainerSkill(TrainerSkillAddModModel trainerSkillMod);

        [HttpPost]
        [Route("trainableskill-create")]
        Task<IActionResult> CreateTrainableSkill(TrainableAddModSkillModel trainableSkillAdd);

        [HttpPut]
        [Route("trainableskill-udpate")]
        Task<IActionResult> EditTrainableSkill(TrainableAddModSkillModel trainableSkillMod);
        #endregion

        #region BirdCertificate

        [HttpPost]
        [Route("birdcertificate")]
        Task<IActionResult> CreateBirdCertitficate(BirdCertificateAddParamModel birdCertificateAddParam);
        #endregion
    }
}
