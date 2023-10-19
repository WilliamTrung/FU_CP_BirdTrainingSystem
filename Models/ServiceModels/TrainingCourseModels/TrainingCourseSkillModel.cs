using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels
{
    public partial class TrainingCourseSkillModel
    {
        public int BirdSkillId { get; set; }
        public int TrainingCourseId { get; set; }
        public int? TrainerId { get; set; }
        public int Status { get; set; }

        public virtual BirdSkillModel BirdSkill { get; set; } = null!;
        public virtual TrainerModel? Trainer { get; set; }
        public virtual TrainingCourseModel TrainingCourse { get; set; } = null!;
    }
}
