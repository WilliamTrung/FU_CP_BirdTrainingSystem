using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels.TrainingCourse
{
    public partial class TrainingCourseModel
    {
        public int Id { get; set; }
        public int BirdSpeciesId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int TotalSlot { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual BirdSpeciesModel BirdSpecies { get; set; } = null!;
        //public virtual ICollection<BirdCertificateModel> BirdCertificates { get; set; }
        public virtual ICollection<BirdTrainingCourseModel> BirdTrainingCourses { get; set; }
        public virtual ICollection<TrainingCourseSkillModel> TrainingCourseSkills { get; set; }
    }
}
