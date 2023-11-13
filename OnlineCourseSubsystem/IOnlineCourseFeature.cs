using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseSubsystem
{
    public interface IOnlineCourseFeature
    {
        IFeatureCustomer Customer { get; }
        IFeatureStaff Staff { get; }
        IFeatureAll All { get; }
        IFeatureManager Manager { get; }
    }
}
