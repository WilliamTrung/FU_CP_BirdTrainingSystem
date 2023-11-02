using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.Skills;
using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels.BirdSkill
{
    public partial class AcquirableSkillViewModel
    {
        public int BirdSpeciesId { get; set; }
        public string BirdSpeciesName { get; set; } = null!;
        public int BirdSkillId { get; set; }
        public string BirdSkillName { get; set; } = null!;
        public string? Condition { get; set; }
    }
}