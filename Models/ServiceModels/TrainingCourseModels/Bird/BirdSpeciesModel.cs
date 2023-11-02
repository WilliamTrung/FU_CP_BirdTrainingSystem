using System;
using System.Collections.Generic;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;

namespace Models.ServiceModels.TrainingCourseModels.Bird
{
    public partial class BirdSpeciesModel
    {
        public BirdSpeciesModel()
        {
            AcquirableSkills = new HashSet<AcquirableSkillModel>();
            Birds = new HashSet<BirdModel>();
            TrainingCourses = new HashSet<TrainingCourseModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ShortDetail { get; set; }

        public virtual ICollection<AcquirableSkillModel> AcquirableSkills { get; set; }
        public virtual ICollection<BirdModel> Birds { get; set; }
        public virtual ICollection<TrainingCourseModel> TrainingCourses { get; set; }
    }
}