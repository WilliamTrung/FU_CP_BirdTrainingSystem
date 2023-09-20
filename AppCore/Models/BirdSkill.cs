using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class BirdSkill
    {
        public BirdSkill()
        {
            TrainingCourseBirdSkills = new HashSet<TrainingCourseBirdSkill>();
            BirdSpecies = new HashSet<BirdSpecies>();
            Skills = new HashSet<Skill>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<TrainingCourseBirdSkill> TrainingCourseBirdSkills { get; set; }

        public virtual ICollection<BirdSpecies> BirdSpecies { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
