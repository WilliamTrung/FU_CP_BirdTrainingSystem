using System;
using System.Collections.Generic;
using Models.ServiceModels.TrainingCourseModels.Bird;

namespace Models.ServiceModels.TrainingCourseModels
{
    public partial class BirdSpeciesModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ShortDetail { get; set; }

        public virtual ICollection<AcquirableSkillModel> AcquirableSkills { get; set; }
        public virtual ICollection<BirdModel> Birds { get; set; }
        public virtual ICollection<TrainingCourseModel> TrainingCourses { get; set; }
    }
}