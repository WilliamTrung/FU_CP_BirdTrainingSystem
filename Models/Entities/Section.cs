using System;
using System.Collections.Generic;

namespace Models.Entities
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
        public string Description { get; set; } = null!;
        public string? ResourceFiles { get; set; }

        public virtual OnlineCourse OnlineCourse { get; set; } = null!;
        public virtual ICollection<CustomerSectionDetail> CustomerSectionDetails { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
