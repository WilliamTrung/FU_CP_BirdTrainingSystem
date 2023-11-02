using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem.IFeatureManagerExtension
{
    public interface IFeatureTrainerSkill
    {
        Task CreateSkill(SkillAddModel skillAddModel);
        Task EditSkill(SkillViewModModel skillModModel);
        Task<IEnumerable<SkillViewModModel>> GetSkills();
        Task<SkillViewModModel> GetSkillById(int skillId);
        Task CreateTrainerSkill(TrainerSkillAddModModel trainerSkillAdd);
        Task EditTrainerSkill(TrainerSkillAddModModel trainerSkillMod);
        Task<IEnumerable<TrainerSkillViewModel>> GetTrainerSkills();
        Task<IEnumerable<TrainerSkillViewModel>> GetTrainerSkillsByTrainerId(int trainerId);

        Task CreateTrainableSkill(TrainableAddModSkillModel trainableSkillAdd);
        Task EditTrainableSkill(TrainerSkillAddModModel trainableSkillMod);
        Task<IEnumerable<TrainableViewSkillModel>> GetTrainableSkills();
    }
}
