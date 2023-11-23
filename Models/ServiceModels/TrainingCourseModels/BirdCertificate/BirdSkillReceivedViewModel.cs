using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.BirdCertificate
{
    public class BirdSkillReceivedViewModel
    {
        public int BirdId { get; set; }
        public string BirdName { get; set; } = null!;
        public int BirdSkillId { get; set; }
        public string BirdSkillName { get; set; } = null!;
        public string? BirdSkillDescription { get; set; }
        public string? BirdSkillPicture { get; set; }
        public DateTime ReceivedDate { get; set; }
    }
}
