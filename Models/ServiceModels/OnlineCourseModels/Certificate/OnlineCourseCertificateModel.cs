using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.OnlineCourseModels.Certificate
{
    public class OnlineCourseCertificateModel
    {
        public int Id { get; set; }
        public int OnlineCourseId { get; set; }
        public string BirdCenterName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Picture { get; set; }    
        public DateOnly ReceivedDate { get; set; }
        public string CustomerName { get; set; } = null!;

    }
}
