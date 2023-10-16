using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels
{
    public partial class AcquirableSkillModel
    {
        public int BirdSpeciesId { get; set; }
        public int BirdSkillId { get; set; }
        public string? Condition { get; set; }

        public virtual BirdSkillModel BirdSkill { get; set; } = null!;
        public virtual BirdSpeciesModel BirdSpecies { get; set; } = null!;
    }
}
