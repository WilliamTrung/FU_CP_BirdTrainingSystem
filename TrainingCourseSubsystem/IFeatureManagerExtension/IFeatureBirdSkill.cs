using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem.IFeatureManagerExtension
{
    public interface IFeatureBirdSkill
    {
        Task CreateBirdSkill(BirdSkillAddModel birdSkillAdd);
        Task EditBirdSkill(BirdSkillModModel birdSkillMod);
        Task<IEnumerable<BirdSkillViewModel>> GetBirdSkills();
        Task<BirdSkillViewModel> GetBirdSkillsById(int birdSkillId);
        Task CreateAccquirableBirdSkill(AccquirableAddModBirdSkill accquirableAdd);
        Task EditAccquirableBirdSkill(AccquirableAddModBirdSkill accquirableMod);
    }
}
