using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels
{
    public partial class BirdSkillModel
    {
        public BirdSkillModel()
        {
            AcquirableSkills = new HashSet<AcquirableSkillModel>();
            TrainableSkills = new HashSet<TrainableSkillModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual TrainingCourseSkillModel? TrainingCourseSkill { get; set; }
        public virtual ICollection<AcquirableSkillModel> AcquirableSkills { get; set; }
        public virtual ICollection<TrainableSkillModel> TrainableSkills { get; set; }
    }
}