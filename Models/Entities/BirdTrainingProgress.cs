using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class BirdTrainingProgress
    {
        public BirdTrainingProgress()
        {
            BirdTrainingDetails = new HashSet<BirdTrainingDetail>();
        }

        public int Id { get; set; }
        public int TrainingCourseId { get; set; }
        public int BirdId { get; set; }
        public int TrainingCourseSkillId { get; set; }
        public int TrainerId { get; set; }
        public DateTime? TrainingDoneDate { get; set; }
        public bool? IsComplete { get; set; }

        public virtual BirdTrainingCourse BirdTrainingCourse { get; set; } = null!;
        public virtual Trainer Trainer { get; set; } = null!;
        public virtual TrainingCourseBirdSkill TrainingCourse { get; set; } = null!;
        public virtual ICollection<BirdTrainingDetail> BirdTrainingDetails { get; set; }
    }
}
