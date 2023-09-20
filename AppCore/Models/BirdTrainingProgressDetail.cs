using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class BirdTrainingProgressDetail
    {
        public int TrainingCourseId { get; set; }
        public int BirdId { get; set; }
        public int TrainingCourseSkillId { get; set; }
        public DateTime TrainingDate { get; set; }
        public int TrainerId { get; set; }
        public int? SlotStart { get; set; }
        public int? SlotEnd { get; set; }
        public float? Progress { get; set; }
        public string? Comment { get; set; }
        public DateTime? TrainingDoneDate { get; set; }
        public bool? IsComplete { get; set; }

        public virtual BirdTrainingCourse BirdTrainingCourse { get; set; } = null!;
        public virtual Trainer Trainer { get; set; } = null!;
        public virtual TrainingCourseBirdSkill TrainingCourse { get; set; } = null!;
    }
}
