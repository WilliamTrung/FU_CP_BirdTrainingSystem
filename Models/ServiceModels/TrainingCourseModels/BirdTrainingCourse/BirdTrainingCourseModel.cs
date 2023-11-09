using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
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
        public DateTime? RegisteredDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int? ReceiveStaffId { get; set; }
        public DateTime? DateReceived { get; set; }
        public string? ReceiveNote { get; set; }
        public string? ReceivePicture { get; set; }
        public int? ReturnStaffId { get; set; }
        public DateTime? DateReturn { get; set; }
        public string? ReturnNote { get; set; }
        public string? ReturnPicture { get; set; }
        public DateTime? StartTrainingDate { get; set; }
        public DateTime? TrainingDoneDate { get; set; }
        public int Status { get; set; }

        public virtual BirdModel Bird { get; set; } = null!;
        public virtual UserModel Staff { get; set; } = null!;
        public virtual UserModel ReceiveStaff { get; set; } = null!;
        public virtual UserModel ReturnStaff { get; set; } = null!;
        public virtual TrainingCourseModel TrainingCourse { get; set; } = null!;
        public virtual ICollection<BirdTrainingProgressModel>? BirdTrainingProgresses { get; set; }
        public virtual ICollection<BirdTrainingReportModel>? BirdTrainingReports { get; set; }
    }
}