using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.OnlineCourseModels.Operation
{
    public class OnlineCourseAdminViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? Picture { get; set; }
        public decimal? Price { get; set; }
        public Models.Enum.OnlineCourse.Status? Status { get; set; }
        public IEnumerable<OnlineCourseSectionViewModel>? Sections { get; set; }
    }
}
