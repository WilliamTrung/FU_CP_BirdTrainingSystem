using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.OnlineCourseModels
{
    public class OnlineCourseModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? Picture { get; set; }
        public decimal? Price { get; set; }
        public Models.Enum.OnlineCourse.Customer.OnlineCourse.Status? Status { get; set; }
        public IEnumerable<OnlineCourseSectionViewModel>? Sections { get; set; }
    }
}
