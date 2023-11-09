using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int FeedbackType { get; set; }
        public int CustomerId { get; set; }
        public int EntityTypeId { get; set; }
        public int? EntityId { get; set; }
        public string? FeedbackDetail { get; set; }
        public int? Rating { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}
