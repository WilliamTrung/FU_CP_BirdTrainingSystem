using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class BirdTrainingCourse
    {
        public BirdTrainingCourse()
        {
            BirdTrainingProgresses = new HashSet<BirdTrainingProgress>();
            BirdTrainingReports = new HashSet<BirdTrainingReport>();
        }

        public int Id { get; set; }
        public int BirdId { get; set; }
        public int TrainingCourseId { get; set; }
        public int StaffId { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public DateTime? ExpectedStartDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? DateReceivedBird { get; set; }
        public string? ReceiveNote { get; set; }
        public string? ReceivePicture { get; set; }
        public DateTime? ExpectedDateReturn { get; set; }
        public DateTime? TrainingDoneDate { get; set; }
        public DateTime? ActualDateReturn { get; set; }
        public string? ReturnNote { get; set; }
        public string? ReturnPicture { get; set; }
        public DateTime? LastestUpdate { get; set; }
        public int Status { get; set; }

        public virtual Bird Bird { get; set; } = null!;
        public virtual User Staff { get; set; } = null!;
        public virtual TrainingCourse TrainingCourse { get; set; } = null!;
        public virtual ICollection<BirdTrainingProgress> BirdTrainingProgresses { get; set; }
        public virtual ICollection<BirdTrainingReport> BirdTrainingReports { get; set; }
    }
}
