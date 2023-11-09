using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class BirdTrainingCourse
    {
        public BirdTrainingCourse()
        {
            BirdTrainingProgresses = new HashSet<BirdTrainingProgress>();
            BirdCertificateDetails = new HashSet<BirdCertificateDetail>();
        }

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

        public virtual Bird Bird { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual User Staff { get; set; } = null!;
        public virtual TrainingCourse TrainingCourse { get; set; } = null!;
        public virtual ICollection<BirdTrainingProgress> BirdTrainingProgresses { get; set; }
        public virtual ICollection<BirdCertificateDetail> BirdCertificateDetails { get; set; }
    }
}
