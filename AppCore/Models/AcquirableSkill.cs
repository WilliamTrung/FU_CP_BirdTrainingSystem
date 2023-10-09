using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class AcquirableSkill
    {
        public int BirdSpeciesId { get; set; }
        public int BirdSkillId { get; set; }
        public string? Condition { get; set; }

        public virtual BirdSkill BirdSkill { get; set; } = null!;
        public virtual BirdSpecies BirdSpecies { get; set; } = null!;
    }
}
