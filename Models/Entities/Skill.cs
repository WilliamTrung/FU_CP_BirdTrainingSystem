using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class Skill
    {
        public Skill()
        {
            TrainableSkills = new HashSet<TrainableSkill>();
            TrainerSkills = new HashSet<TrainerSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<TrainableSkill> TrainableSkills { get; set; }
        public virtual ICollection<TrainerSkill> TrainerSkills { get; set; }
    }
}
