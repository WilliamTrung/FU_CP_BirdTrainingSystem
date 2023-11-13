using Models.ConfigModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.OnlineCourseModels.Certificate
{
    public class CertificateAddModel
    {
        public int OnlineCourseId { get; set; }
        public string BirdCenterName { get; } = BR_CertificateConstants.CENTER_NAME;
        public string ShortDescription { get; set; } = null!;
        public string Picture { get; } = BR_CertificateConstants.CERT_PICTURE;
        public string Title { get; set; } = null!;
    }
}
