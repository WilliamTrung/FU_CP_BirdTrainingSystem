using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class Skill
    {
        public Skill()
        {
            BirdSkills = new HashSet<BirdSkill>();
            Trainers = new HashSet<Trainer>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<BirdSkill> BirdSkills { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
