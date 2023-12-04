using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse
{
    public class BirdTrainingCourseListView
    {
        public int Id { get; set; }
        public int TrainingCourseId { get; set; }
        public int BirdId { get; set; }
        public string BirdName { get; set; } = null!;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string TrainingCourseTitle { get; set; } = null!;
        public string? RegisteredDate { get; set; }
        public string? StartTrainingDate { get; set; }
        public string? TrainingDoneDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public decimal? ActualPrice { get; set; }
        public int? MembershipRankId { get; set; }
        public string? MembershipRank { get; set; }
        public int? PricePolicyId { get; set; }
        public Models.Enum.BirdTrainingCourse.Status Status { get; set; }

    }
}
