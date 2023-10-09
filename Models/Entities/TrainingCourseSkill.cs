using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class TrainingCourseSkill
    {
        public TrainingCourseSkill()
        {
            BirdTrainingProgresses = new HashSet<BirdTrainingProgress>();
        }

        public int BirdSkillId { get; set; }
        public int TrainingCourseId { get; set; }
        public int Status { get; set; }

        public virtual BirdSkill BirdSkill { get; set; } = null!;
        public virtual TrainingCourse TrainingCourse { get; set; } = null!;
        public virtual ICollection<BirdTrainingProgress> BirdTrainingProgresses { get; set; }
    }
}
