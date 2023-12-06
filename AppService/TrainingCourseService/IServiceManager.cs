using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using Models.ServiceModels.TrainingCourseModels.TrainingCourseCheckOutPolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.TrainingCourseService
{
    public interface IServiceManager : IServiceAll
    {
        Task<int> CreateCourse(TrainingCourseAddModel trainingCourse);
        Task EditCourse(TrainingCourseModifyModel trainingCourse);
        Task ActiveTrainingCourse(int trainingCourseId);
        Task DisableTrainingCourse(int trainingCourseId);
        Task AddSkill(AddTrainingSkillModel trainingCourseSkill);
        Task UpdateSkill(AddTrainingSkillModel trainingSkillModel);
        Task DeleteSkill(DeleteTrainingSkillModel trainingSkillModel);
        Task CreateBirdSpecies(BirdSpeciesAddModel birdSpecies);
        Task EditBirdSpecies(BirdSpeciesViewModel birdSpecies);


        #region BirdSkill
        Task CreateBirdSkill(BirdSkillAddModel birdSkillAdd);
        Task EditBirdSkill(BirdSkillModModel birdSkillMod);
        Task CreateAccquirableBirdSkill(AcquirableAddModBirdSkill accquirableAdd);
        Task EditAccquirableBirdSkill(AcquirableAddModBirdSkill accquirableMod);
        #endregion

        #region Skill
        Task CreateSkill(SkillAddModel skillAddModel);
        Task EditSkill(SkillViewModModel skillModModel);
        Task CreateTrainerSkill(TrainerSkillAddModModel trainerSkillAdd);
        Task EditTrainerSkill(TrainerSkillAddModModel trainerSkillMod);

        Task CreateTrainableSkill(TrainableAddModSkillModel trainableSkillAdd);
        Task EditTrainableSkill(TrainableAddModSkillModel trainableSkillMod);
        #endregion

        #region BirdCertificate
        Task CreateBirdCertitficate(BirdCertificateAddModel birdCertificateAdd);
        #endregion

        #region CheckOutPolicies

        Task<int> CreateCheckOutPolicy(PolicyAddModel policyAdd);
        Task EditCheckOutPolicy(PolicyModModel policyMod);
        Task ActiveCheckOutPolicy(int policyId);
        Task DisableCheckOutPolicy(int policyId);

        #endregion
    }
}
