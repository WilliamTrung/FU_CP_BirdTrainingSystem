using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class TrainerSkill
    {
        public int TrainerId { get; set; }
        public int SkillId { get; set; }
        public string? Description { get; set; }

        public virtual Skill Skill { get; set; } = null!;
        public virtual Trainer Trainer { get; set; } = null!;
    }
}
