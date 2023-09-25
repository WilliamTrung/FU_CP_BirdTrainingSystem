using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int FeedbackTypeId { get; set; }
        public int CustomerId { get; set; }
        public int? FeedbackEntityId { get; set; }
        public string? FeedbackDetail { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual FeedbackType FeedbackType { get; set; } = null!;
    }
}
