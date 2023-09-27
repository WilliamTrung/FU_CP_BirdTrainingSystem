using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class BirdTrainingCourse
    {
        public BirdTrainingCourse()
        {
            BirdTrainingProgresses = new HashSet<BirdTrainingProgress>();
        }

        public int BirdId { get; set; }
        public int TrainingCourseId { get; set; }
        public DateTime? TrainingDoneDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? Status { get; set; }

        public virtual Bird Bird { get; set; } = null!;
        public virtual TrainingCourse TrainingCourse { get; set; } = null!;
        public virtual ICollection<BirdTrainingProgress> BirdTrainingProgresses { get; set; }
    }
}
