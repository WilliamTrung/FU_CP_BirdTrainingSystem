using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSkillSubsystem
{
    public interface IFeatureExtra
    {
        Task DeleteAcquirableSkill(AcquirableAddModBirdSkill model);
        Task DeleteTrainableSkill(TrainableAddModSkillModel model);
        Task DeleteTrainerSkill(TrainerSkillAddModModel model);        
    }
}
