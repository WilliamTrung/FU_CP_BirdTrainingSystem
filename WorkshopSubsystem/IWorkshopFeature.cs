using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem
{
    public interface IWorkshopFeature
    {
        IFeatureAll All { get; }
        IFeatureCustomer Customer { get; }
        IFeatureManager Manager { get; }
        IFeatureTrainer Trainer { get; }
        IFeatureStaff Staff { get; }
    }
}
