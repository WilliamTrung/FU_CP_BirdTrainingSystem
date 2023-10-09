using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class TrainableSkill
    {
        public int BirdSkillId { get; set; }
        public int SkillId { get; set; }
        public string? ShortDescription { get; set; }

        public virtual BirdSkill BirdSkill { get; set; } = null!;
        public virtual Skill Skill { get; set; } = null!;
    }
}
