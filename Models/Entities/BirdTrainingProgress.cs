﻿using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class BirdTrainingProgress
    {
        public int Id { get; set; }
        public int BirdTrainingCourseId { get; set; }
        public int TrainingCourseSkillId { get; set; }
        public int TrainerId { get; set; }
        public DateTime? TrainingDoneDate { get; set; }
        public string? Evidence { get; set; }
        public bool? IsComplete { get; set; }

        public virtual BirdTrainingCourse BirdTrainingCourse { get; set; } = null!;
        public virtual Trainer Trainer { get; set; } = null!;
        public virtual TrainingCourseSkill TrainingCourseSkill { get; set; } = null!;
    }
}
