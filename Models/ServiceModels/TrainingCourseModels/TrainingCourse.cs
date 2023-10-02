﻿namespace Models.ServiceModels.TrainingCourseModels
{
    public partial class TrainingCourse
    {
        public int Id { get; set; }
        public int BirdSpeciesId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int? TotalSlot { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual BirdSpecies BirdSpecies { get; set; } = null!;
        public virtual ICollection<BirdCertificate> BirdCertificates { get; set; }
        public virtual ICollection<BirdTrainingCourse> BirdTrainingCourses { get; set; }
        public virtual ICollection<TrainingCourseSkill> TrainingCourseSkills { get; set; }
    }
}
