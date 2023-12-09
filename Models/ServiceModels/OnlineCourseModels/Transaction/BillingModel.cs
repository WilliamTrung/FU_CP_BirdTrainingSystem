using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.OnlineCourseModels.Transaction
{
    public class BillingModel
    {
        public int CourseId { get; set; }
        public string Email { get; set; } = null!;
        public string CourseTitle { get; set; } = null!;
        public decimal CoursePrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public float DiscountRate { get; set; }
        public string MembershipName { get; set; } = null!;
    }
}
