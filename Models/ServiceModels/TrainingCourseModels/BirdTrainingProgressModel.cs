using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels
{
    public partial class BirdTrainingProgressModel
    {
        public int Id { get; set; }
        public int BirdTrainingCourseId { get; set; }
        public int TrainingCourseSkillId { get; set; }
        public int TrainerId { get; set; }
        public DateTime? TrainingDoneDate { get; set; }
        public bool? IsComplete { get; set; }

        public virtual BirdTrainingCourseModel BirdTrainingCourse { get; set; } = null!;
        public virtual Trainer Trainer { get; set; } = null!;
        public virtual TrainingCourseSkillModel TrainingCourseSkill { get; set; } = null!;
    }
}
