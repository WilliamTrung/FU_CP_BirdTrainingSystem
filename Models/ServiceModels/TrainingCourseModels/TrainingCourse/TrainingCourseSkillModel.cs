﻿using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels.TrainingCourse
{
    public partial class TrainingCourseSkillModel
    {
        public int BirdSkillId { get; set; }
        public int TrainingCourseId { get; set; }
        public int TotalSlot { get; set; }

        public virtual BirdSkillViewModel BirdSkillModel { get; set; } = null!;
        public virtual TrainingCourseModel TrainingCourseModel { get; set; } = null!;
        public virtual ICollection<BirdTrainingProgressModel> BirdTrainingProgresses { get; set; }
    }
}