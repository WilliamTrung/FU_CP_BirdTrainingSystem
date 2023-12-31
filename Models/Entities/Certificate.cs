﻿using System;
using System.Collections.Generic;

namespace Models.Entities
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
        public string? ShortDescription { get; set; }
        public string? Picture { get; set; }

        public virtual OnlineCourse OnlineCourse { get; set; } = null!;
        public virtual ICollection<CustomerCertificateDetail> CustomerCertificateDetails { get; set; }
    }
}
