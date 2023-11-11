using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels.BirdCertificate
{
    public class BirdCertificateDetailModel
    {
        public int Id { get; set; }
        public int BirdId { get; set; }
        public int BirdTrainingCourseId { get; set; }
        public int BirdCertificateId { get; set; }
        public DateTime ReceiveDate { get; set; }
    }
}
