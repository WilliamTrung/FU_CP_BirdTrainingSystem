using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem
{
    public interface ITrainingCourseFeature
    {
        IFeatureCustomer Customer { get; }
        IFeatureManager Manager { get; }
        IFeatureStaff Staff { get; }
        IFeatureTrainer Trainer { get; }
        IFeatureAll All { get; }
    }
}
