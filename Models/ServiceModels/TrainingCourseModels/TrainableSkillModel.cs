using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels
{
    public partial class TrainableSkillModel
    {
        public int BirdSkillId { get; set; }
        public int SkillId { get; set; }
        public string? ShortDescription { get; set; }

        public virtual BirdSkillModel BirdSkill { get; set; } = null!;
        public virtual SkillModel Skill { get; set; } = null!;
    }
}