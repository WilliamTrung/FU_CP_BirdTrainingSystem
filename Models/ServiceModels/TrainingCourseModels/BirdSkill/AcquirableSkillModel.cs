using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.Skills;
using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels.BirdSkill
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