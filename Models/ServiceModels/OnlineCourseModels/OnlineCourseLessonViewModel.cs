using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.OnlineCourseModels
{
    public class OnlineCourseLessonViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public string? Video { get; set; }
        public Models.Enum.OnlineCourse.Customer.Lesson.Status? Status { get; set; }
    }
}
