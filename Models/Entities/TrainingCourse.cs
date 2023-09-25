using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class TrainingCourse
    {
        public TrainingCourse()
        {
            BirdCertificates = new HashSet<BirdCertificate>();
            BirdTrainingCourses = new HashSet<BirdTrainingCourse>();
            TrainingCourseBirdSkills = new HashSet<TrainingCourseBirdSkill>();
        }

        public int Id { get; set; }
        public int BirdSpeciesId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public float? Rating { get; set; }
        public int? TotalTrainingDay { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual BirdSpecies BirdSpecies { get; set; } = null!;
        public virtual ICollection<BirdCertificate> BirdCertificates { get; set; }
        public virtual ICollection<BirdTrainingCourse> BirdTrainingCourses { get; set; }
        public virtual ICollection<TrainingCourseBirdSkill> TrainingCourseBirdSkills { get; set; }
    }
}
