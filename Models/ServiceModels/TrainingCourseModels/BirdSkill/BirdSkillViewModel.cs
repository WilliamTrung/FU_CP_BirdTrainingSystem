using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels.BirdSkill
{
    public partial class BirdSkillViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Picture { get; set; }
    }
}