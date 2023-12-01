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
using TimetableSubsystem;
using TrainingCourseSubsystem;

namespace AppService.TrainingCourseService.Implement
{
    public class ServiceManager : ServiceAll, IServiceManager
    {
        public ServiceManager(ITrainingCourseFeature trainingCourse, ITimetableFeature timetable) : base(trainingCourse, timetable)
        {
        }
        #region ManagerBase
        public async Task CreateCourse(TrainingCourseAddModel trainingCourse)
        {
            await _trainingCourse.Manager.CreateCourse(trainingCourse);
        }

        public async Task EditCourse(TrainingCourseModifyModel trainingCourse)
        {
            await _trainingCourse.Manager.EditCourse(trainingCourse);
        }

        public async Task ActiveTrainingCourse(int trainingCourseId)
        {
            await _trainingCourse.Manager.ActiveTrainingCourse(trainingCourseId);
        }

        public async Task DisableTrainingCourse(int trainingCourseId)
        {
            await _trainingCourse.Manager.DisableTrainingCourse(trainingCourseId);
        }

        public async Task AddSkill(AddTrainingSkillModel trainingCourseSkill)
        {
            await _trainingCourse.Manager.AddSkillToCourse(trainingCourseSkill);
        }
        public async Task UpdateSkill(AddTrainingSkillModel trainingSkillModel)
        {
            await _trainingCourse.Manager.UpdateSkill(trainingSkillModel);
        }
        public async Task DeleteSkill(DeleteTrainingSkillModel trainingSkillModel)
        {
            await _trainingCourse.Manager.DeleteSkill(trainingSkillModel);
        }

        public async Task CreateBirdSpecies(BirdSpeciesAddModel birdSpecies)
        {
            await _trainingCourse.Manager.CreateBirdSpecies(birdSpecies);
        }
        public async Task EditBirdSpecies(BirdSpeciesViewModel birdSpecies)
        {
            await _trainingCourse.Manager.EditBirdSpecies(birdSpecies);
        }
        #endregion
        #region Extend
        #region BirdSkill
        public async Task CreateBirdSkill(BirdSkillAddModel birdSkillAdd)
        {
            await _trainingCourse.Manager.CreateBirdSkill(birdSkillAdd);
        }

        public async Task EditBirdSkill(BirdSkillModModel birdSkillMod)
        {
            await _trainingCourse.Manager.EditBirdSkill(birdSkillMod);
        }

        public async Task CreateAccquirableBirdSkill(AcquirableAddModBirdSkill accquirableAdd)
        {
            await _trainingCourse.Manager.CreateAccquirableBirdSkill(accquirableAdd);
        }

        public async Task EditAccquirableBirdSkill(AcquirableAddModBirdSkill accquirableMod)
        {
            await _trainingCourse.Manager.EditAccquirableBirdSkill(accquirableMod);
        }
        #region Skill
        public async Task CreateSkill(SkillAddModel skillAddModel)
        {
            await _trainingCourse.Manager.CreateSkill(skillAddModel);
        }

        public async Task EditSkill(SkillViewModModel skillModModel)
        {
            await _trainingCourse.Manager.EditSkill(skillModModel);
        }

        public async Task CreateTrainerSkill(TrainerSkillAddModModel trainerSkillAdd)
        {
            await _trainingCourse.Manager.CreateTrainerSkill(trainerSkillAdd);
        }

        public async Task EditTrainerSkill(TrainerSkillAddModModel trainerSkillMod)
        {
            await _trainingCourse.Manager.EditTrainerSkill(trainerSkillMod);
        }

        public async Task CreateTrainableSkill(TrainableAddModSkillModel trainableSkillAdd)
        {
            await _trainingCourse.Manager.CreateTrainableSkill(trainableSkillAdd);
        }

        public async Task EditTrainableSkill(TrainableAddModSkillModel trainableSkillMod)
        {
            await _trainingCourse.Manager.EditTrainableSkill(trainableSkillMod);
        }
        #endregion
        #endregion
        public async Task CreateBirdCertitficate(BirdCertificateAddModel birdCertificateAdd)
        {
            await _trainingCourse.Manager.CreateBirdCertitficate(birdCertificateAdd);
        }

        #region CheckOutPolicies

        public async Task CreateCheckOutPolicy(PolicyAddModel policyAdd)
        {
            await _trainingCourse.Manager.CreateCheckOutPolicy(policyAdd);
        }
        public async Task EditCheckOutPolicy(PolicyModModel policyMod)
        {
            await _trainingCourse.Manager.EditCheckOutPolicy(policyMod);
        }
        public async Task ActiveCheckOutPolicy(int policyId)
        {
            await _trainingCourse.Manager.ActiveCheckOutPolicy(policyId);
        }
        public async Task DisableCheckOutPolicy(int policyId)
        {
            await _trainingCourse.Manager.DisableCheckOutPolicy(policyId);
        }

        #endregion
        #endregion
    }
}
