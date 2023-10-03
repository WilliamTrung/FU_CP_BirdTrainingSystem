using Models.ServiceModels;
using Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSkillSubsystem
{
    public interface ISkillFeature
    {
        Task GetTrainerSkills(int trainerId);
        Task<List<TrainerSkillModel>> GetTrainerSkillsByBirdSkill(string birdSkillName);
        Task<List<TrainerModel>> GetTrainersByBirdSkill(string birdSkillName);
        Task<List<BirdSkillModel>> GetBirdSkillsTrainedByTrainerSkill(string trainerSkillName);
    }
}
