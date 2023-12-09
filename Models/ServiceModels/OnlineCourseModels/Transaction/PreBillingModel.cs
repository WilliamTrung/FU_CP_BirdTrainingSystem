using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.OnlineCourseModels.Transaction
{
    public class PreBillingModel
    {
        public string Email { get; set; } = null!;
        public string CourseTitle { get; set; } = null!;
        public string MembershipName { get; set; } = null!;
        public float DiscountPercent { get; set; }
        public decimal CoursePrice { get; set; }
    }
}
