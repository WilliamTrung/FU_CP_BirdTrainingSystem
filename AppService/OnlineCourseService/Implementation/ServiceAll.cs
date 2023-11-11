using OnlineCourseSubsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.OnlineCourseService.Implementation
{
    public class ServiceAll : IServiceAll
    {
        private readonly IOnlineCourseFeature _onlineCourse;
        public ServiceAll(IOnlineCourseFeature onlineCourse)
        {
            _onlineCourse = onlineCourse;
        }
    }
}
