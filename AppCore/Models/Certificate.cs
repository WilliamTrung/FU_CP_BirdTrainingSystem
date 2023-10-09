using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class Certificate
    {
        public Certificate()
        {
            CustomerCertificateDetails = new HashSet<CustomerCertificateDetail>();
        }

        public int Id { get; set; }
        public int OnlineCourseId { get; set; }
        public string BirdCenterName { get; set; } = null!;
        public string? Title { get; set; }
        public string? ShortDescrption { get; set; }
        public string? Picture { get; set; }

        public virtual OnlineCourse OnlineCourse { get; set; } = null!;
        public virtual ICollection<CustomerCertificateDetail> CustomerCertificateDetails { get; set; }
    }
}
