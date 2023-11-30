using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels.TrainingCourse
{
    public partial class TrainingCourseSkillModel
    {
        public BirdSkillViewModel BirdSkill { get; set; } = null!;
        public int TrainSlot { get; set; }
    }
}
