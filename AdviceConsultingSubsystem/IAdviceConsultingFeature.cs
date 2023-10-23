using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdviceConsultingSubsystem
{
    public interface IAdviceConsultingFeature
    {
        IFeatureCustomer Customer { get; }
        IFeatureStaff Staff { get; }
        IFeatureTrainer Trainer { get; }
        IOtherFeature Other {  get; }
    }
}
