using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class BirdTrainingCourse
    {
        public BirdTrainingCourse()
        {
            BirdTrainingProgressDetails = new HashSet<BirdTrainingProgressDetail>();
        }

        public int BirdId { get; set; }
        public int TrainingCourseId { get; set; }
        public int? TotalTrainingDay { get; set; }
        public DateTime? TrainingDoneDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public bool? IsComplete { get; set; }

        public virtual Bird Bird { get; set; } = null!;
        public virtual TrainingCourse TrainingCourse { get; set; } = null!;
        public virtual ICollection<BirdTrainingProgressDetail> BirdTrainingProgressDetails { get; set; }
    }
}
