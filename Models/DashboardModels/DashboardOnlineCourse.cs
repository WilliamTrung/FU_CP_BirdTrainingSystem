using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DashboardModels
{
    public class DashboardOnlineCourse
    {
        //Total attempts (customer enroll course, status == all)
        //Customer attempts (not complete course)
        //Customer completes course / Customer attempts (not complete course) ratio
        public int TotalAttempts { get; set; }
        public int CustomerCompleted { get; set; }
        public float CompleteCourseRatio { get; set; }

    }
}
