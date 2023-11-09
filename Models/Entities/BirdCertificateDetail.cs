using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class BirdCertificateDetail
    {
        public int Id { get; set; }
        public int BirdId { get; set; }
        public int BirdTrainingCourseId { get; set; }
        public int BirdCertificateId { get; set; }
        public DateTime ReceiveDate { get; set; }

        public virtual Bird? Bird { get; set; }
        public virtual BirdCertificate? BirdCertificate { get; set; }
        public virtual BirdTrainingCourse? BirdTrainingCourse { get; set;}
    }
}
