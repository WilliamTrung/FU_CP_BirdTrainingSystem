using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class WorkshopClassDetail
    {
        public int Id { get; set; }
        public int WorkshopClassId { get; set; }
        public int? DaySlotId { get; set; }
        public string? Detail { get; set; }

        public virtual TrainerSlot? DaySlot { get; set; }
        public virtual WorkshopClass WorkshopClass { get; set; } = null!;
    }
}
