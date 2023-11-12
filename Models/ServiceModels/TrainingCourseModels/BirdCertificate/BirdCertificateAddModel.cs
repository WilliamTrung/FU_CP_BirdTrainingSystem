using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.BirdCertificate
{
    public class BirdCertificateAddModel
    {
        public int TrainingCourseId { get; set; }
        public string? BirdCenterName { get; set; } //Dunno can set static 
        //public string Title { get; set; } = null!; auto get from query
        public string? ShortDescrption { get; set; }
        public string? Picture { get; set; }
    }
}
