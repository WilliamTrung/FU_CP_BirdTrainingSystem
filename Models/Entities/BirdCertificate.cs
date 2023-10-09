using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class BirdCertificate
    {
        public BirdCertificate()
        {
            BirdCertificateDetails = new HashSet<BirdCertificateDetail>();
            BirdCertificateSkills = new HashSet<BirdCertificateSkill>();
        }

        public int Id { get; set; }
        public int TrainingCourseId { get; set; }
        public string? BirdCenterName { get; set; }
        public string Title { get; set; } = null!;
        public string? ShortDescrption { get; set; }
        public string? Picture { get; set; }

        public virtual TrainingCourse TrainingCourse { get; set; } = null!;
        public virtual ICollection<BirdCertificateDetail> BirdCertificateDetails { get; set; }
        public virtual ICollection<BirdCertificateSkill> BirdCertificateSkills { get; set; }
    }
}
