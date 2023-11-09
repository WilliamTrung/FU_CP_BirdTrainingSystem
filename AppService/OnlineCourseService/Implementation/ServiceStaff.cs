using OnlineCourseSubsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.OnlineCourseService.Implementation
{
    public class ServiceStaff : ServiceAll, IServiceStaff
    {
        public ServiceStaff(IOnlineCourseFeature onlineCourse) : base(onlineCourse)
        {
        }
    }
}
