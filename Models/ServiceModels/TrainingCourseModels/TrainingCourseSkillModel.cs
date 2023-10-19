using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels
{
    public partial class TrainingCourseSkillModel
    {
        public int BirdSkillId { get; set; }
        public int TrainingCourseId { get; set; }
        public int TotalSlot { get; set; }

        public virtual BirdSkill BirdSkill { get; set; } = null!;
        public virtual TrainingCourse TrainingCourse { get; set; } = null!;
        public virtual ICollection<BirdTrainingProgressModel> BirdTrainingProgresses { get; set; }
    }
}
