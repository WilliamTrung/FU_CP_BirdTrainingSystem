using OnlineCourseSubsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.OnlineCourseService.Implementation
{
    public class ServiceCustomer : ServiceAll, IServiceCustomer
    {
        public ServiceCustomer (IOnlineCourseFeature onlineCourse) : base (onlineCourse) 
        { 
        }
    }
}
