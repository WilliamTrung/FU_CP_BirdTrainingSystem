using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class BirdCertificate
    {
        public BirdCertificate()
        {
            BirdBirdCertificateDetails = new HashSet<BirdCertificateDetail>();
        }

        public int Id { get; set; }
        public int TrainingCourseId { get; set; }
        public string? Title { get; set; }
        public string? ShortDescrption { get; set; }
        public string? BirdCenterName { get; set; }
        public int? Picture { get; set; }
        public int? TrainerId { get; set; }

        public virtual TrainingCourse TrainingCourse { get; set; } = null!;
        public virtual ICollection<BirdCertificateDetail> BirdBirdCertificateDetails { get; set; }
    }
}
