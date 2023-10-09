using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class Section
    {
        public Section()
        {
            CustomerSectionDetails = new HashSet<CustomerSectionDetail>();
            Lessons = new HashSet<Lesson>();
        }

        public int Id { get; set; }
        public int OnlineCourseId { get; set; }
        public string Title { get; set; } = null!;

        public virtual OnlineCourse OnlineCourse { get; set; } = null!;
        public virtual ICollection<CustomerSectionDetail> CustomerSectionDetails { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
