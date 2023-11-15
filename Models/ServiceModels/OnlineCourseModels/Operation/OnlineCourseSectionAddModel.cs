using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.OnlineCourseModels.Operation
{
    public class OnlineCourseSectionAddModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

    }
}
