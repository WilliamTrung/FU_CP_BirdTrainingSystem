using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DashboardModels
{
    public class DashboardTrainingCourse
    {
        public int OnGoingCourseAmount { get; set; }
        public int ClientAmount { get; set; }
        public int UnhandledAttempts { get; set; }
    }
}
