using System;
using System.Collections.Generic;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;

namespace Models.ServiceModels.TrainingCourseModels.TrainerSkill
{
    public partial class TrainableAddModSkillModel
    {
        public int BirdSkillId { get; set; }
        public int SkillId { get; set; }
        public string? ShortDescription { get; set; }
    }
}