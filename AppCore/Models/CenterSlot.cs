using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class CenterSlot
    {
        public int Id { get; set; }
        public int SlotId { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }

        public virtual Slot Slot { get; set; } = null!;
    }
}
