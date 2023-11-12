using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels.BirdCertificate
{
    public class BirdCertificateViewModel
    {
        public BirdCertificateViewModel()
        {
            BirdCertificateSkillNames = new List<string>();
        }
        public int Id { get; set; }
        public int TrainingCourseId { get; set; }
        public string? BirdCenterName { get; set; }
        public string Title { get; set; } = null!;
        public string? ShortDescrption { get; set; }
        public string? Picture { get; set; } 
        public List<string> BirdCertificateSkillNames { get;set; }
    }
}
