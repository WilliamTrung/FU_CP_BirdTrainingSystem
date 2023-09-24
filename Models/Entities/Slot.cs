using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class Slot
    {
        public int Id { get; set; }
        public int DayId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Reason { get; set; }
        public int? ReasonEntityId { get; set; }
        public bool? IsFree { get; set; }

        public virtual Day Day { get; set; } = null!;
    }
}
