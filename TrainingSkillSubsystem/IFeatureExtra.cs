using Models.ServiceModels.TrainingCourseModels.BirdSkill;
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
    }
}
