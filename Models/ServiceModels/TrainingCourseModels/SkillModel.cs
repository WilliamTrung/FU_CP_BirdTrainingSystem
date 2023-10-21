using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels
{
    public partial class SkillModel
    {
        public SkillModel()
        {
            TrainableSkills = new HashSet<TrainableSkillModel>();
            TrainerSkills = new HashSet<TrainerSkillModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<TrainableSkillModel> TrainableSkills { get; set; }
        public virtual ICollection<TrainerSkillModel> TrainerSkills { get; set; }
    }
}