using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.TrainingCourseService
{
    public interface IServiceManager : IServiceAll
    {
        Task CreateCourse(TrainingCourseAddModel trainingCourse);
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
        Task<IEnumerable<BirdSkillViewModel>> GetBirdSkills();
        Task<BirdSkillViewModel> GetBirdSkillsById(int birdSkillId);
        Task CreateAccquirableBirdSkill(AccquirableAddModBirdSkill accquirableAdd);
        Task EditAccquirableBirdSkill(AccquirableAddModBirdSkill accquirableMod);
        #endregion

        #region Skill
        Task CreateSkill(SkillAddModel skillAddModel);
        Task EditSkill(SkillViewModModel skillModModel);
        Task<IEnumerable<SkillViewModModel>> GetSkills();
        Task<SkillViewModModel> GetSkillById(int skillId);
        Task CreateTrainerSkill(TrainerSkillAddModModel trainerSkillAdd);
        Task EditTrainerSkill(TrainerSkillAddModModel trainerSkillMod);
        Task<IEnumerable<TrainerSkillViewModel>> GetTrainerSkills();
        Task<IEnumerable<TrainerSkillViewModel>> GetTrainerSkillsByTrainerId(int trainerId);

        Task CreateTrainableSkill(TrainableAddModSkillModel trainableSkillAdd);
        Task EditTrainableSkill(TrainableAddModSkillModel trainableSkillMod);
        Task<IEnumerable<TrainableViewSkillModel>> GetTrainableSkills();
        #endregion

        #region BirdCertificate
        Task CreateBirdCertitficate(BirdCertificateAddModel birdCertificateAdd);
        #endregion
    }
}
