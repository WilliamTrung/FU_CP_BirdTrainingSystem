using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class OnlineCourse
    {
        public OnlineCourse()
        {
            Certificates = new HashSet<Certificate>();
            CustomerOnlineCourseDetails = new HashSet<CustomerOnlineCourseDetail>();
            Sections = new HashSet<Section>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public decimal? Price { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<CustomerOnlineCourseDetail> CustomerOnlineCourseDetails { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
