using Models.Entities;
using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse
{
    public partial class BirdTrainingCourseModel
    {
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

        public virtual BirdModel Bird { get; set; } = null!;
        //public virtual UserModel Staff { get; set; } = null!;
        public virtual TrainingCourseModel TrainingCourse { get; set; } = null!;
        public virtual ICollection<BirdTrainingProgressModel> BirdTrainingProgresses { get; set; }
        public virtual ICollection<BirdTrainingReportModel> BirdTrainingReports { get; set; }
    }
}
