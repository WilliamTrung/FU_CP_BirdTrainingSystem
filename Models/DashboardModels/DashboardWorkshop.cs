using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DashboardModels
{
    public class DashboardWorkshop
    {
        //Total attempts (customer enroll course, status == all)
        //Customer attempts
        //Customer present / Customer attendance ratio
        public int WorkshopClass { get; set; }
        public int CustomerAttempts { get; set; }
        public float PresentRatio { get; set; }
    }
}
