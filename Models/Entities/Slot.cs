using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class Slot
    {
        public Slot()
        {
            CenterSlots = new HashSet<CenterSlot>();
            TrainerSlots = new HashSet<TrainerSlot>();
        }

        public int Id { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        public virtual ICollection<CenterSlot> CenterSlots { get; set; }
        public virtual ICollection<TrainerSlot> TrainerSlots { get; set; }
    }
}
