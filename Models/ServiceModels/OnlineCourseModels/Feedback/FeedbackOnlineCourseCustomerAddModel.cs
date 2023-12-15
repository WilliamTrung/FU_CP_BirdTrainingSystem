using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.OnlineCourseModels.Feedback
{
    public class FeedbackOnlineCourseCustomerAddModel
    {
        public int CourseId { get; set; }
        public string? Feedback { get; set; }
        [SP_Validator.PositiveNumber]
        public int Rating { get; set; }
    }
}
