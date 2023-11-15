using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.OnlineCourseModels
{
    public class OnlineCourseSectionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IEnumerable<OnlineCourseLessonViewModel>? Lessions { get; set; } 
    }
}
