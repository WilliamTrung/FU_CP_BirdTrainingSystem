using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSkillSubsystem;

namespace AppService.TrainingSkillService
{
    public interface IServiceExtra
    {
        Task DeleteAcquirableSkill(AcquirableAddModBirdSkill model);
        Task DeleteTrainableSkill(TrainableAddModSkillModel model);
    }
    public class ServiceExtra : IServiceExtra
    {
        private ITrainingSkillFeature _trainingSkillFeature;
        public ServiceExtra(ITrainingSkillFeature trainingSkillFeature)
        {
            _trainingSkillFeature = trainingSkillFeature;
        }

        public async Task DeleteAcquirableSkill(AcquirableAddModBirdSkill model)
        {
            await _trainingSkillFeature.Extra.DeleteAcquirableSkill(model);
        }

        public async Task DeleteTrainableSkill(TrainableAddModSkillModel model)
        {
            await _trainingSkillFeature.Extra.DeleteTrainableSkill(model);
        }
    }
}
