using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class Slot
    {
        public int Id { get; set; }
        public int DayId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? Reason { get; set; }
        public int? ReasonEntityId { get; set; }
        public int? Status { get; set; }

        public virtual Day Day { get; set; } = null!;
    }
}
