﻿using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class TrainerSlot
    {
        public TrainerSlot()
        {
            WorkshopClassDetails = new HashSet<WorkshopClassDetail>();
        }

        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int SlotId { get; set; }
        public DateTime Date { get; set; }
        public string? Reason { get; set; }
        public int EntityTypeId { get; set; }
        public int? EntityId { get; set; }
        public int Status { get; set; }

        public virtual Slot Slot { get; set; } = null!;
        public virtual Trainer Trainer { get; set; } = null!;
        public virtual ICollection<WorkshopClassDetail> WorkshopClassDetails { get; set; }
    }
}
