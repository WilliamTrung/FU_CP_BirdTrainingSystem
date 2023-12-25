using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DashboardModels
{
    public class DashboardOnlineCourse
    {
        public int ActiveCourseAmount { get; set; }
        public int TotalAttempts { get; set; }
        public int CompletedAttempts { get; set; }
        public float RatioCompletedAndTotal { get; set; }

    }
}
