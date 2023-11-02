using System;
using System.Collections.Generic;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;

namespace Models.ServiceModels.TrainingCourseModels.TrainerSkill
{
    public partial class TrainableSkillModel
    {
        public int BirdSkillId { get; set; }
        public int SkillId { get; set; }
        public string? ShortDescription { get; set; }

        public virtual BirdSkillViewModel BirdSkill { get; set; } = null!;
        public virtual SkillModel Skill { get; set; } = null!;
    }
}