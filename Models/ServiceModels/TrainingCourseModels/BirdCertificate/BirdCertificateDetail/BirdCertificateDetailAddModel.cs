using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail
{
    public class BirdCertificateDetailAddModel
    {
        public int BirdId { get; set; }
        public int BirdTrainingCourseId { get; set; }
        public int BirdCertificateId { get; set; }
    }
}
