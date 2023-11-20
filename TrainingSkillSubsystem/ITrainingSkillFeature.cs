using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSkillSubsystem
{
    public interface ITrainingSkillFeature
    {
        IFeatureExtra Extra { get; }
    }
    public class TrainingSkillFeature : ITrainingSkillFeature
    {
        public IFeatureExtra Extra { get; }
        public TrainingSkillFeature(IFeatureExtra extra)
        {

            Extra = extra;

        }
    }
}
