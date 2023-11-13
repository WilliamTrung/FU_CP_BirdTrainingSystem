using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.OnlineCourseModels.Operation
{
    public class OnlineCourseLessonAddModel
    {
        public int SectionId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public string? Video { get; set; }
    }
}
