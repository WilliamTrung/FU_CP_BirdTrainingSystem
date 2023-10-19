using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class TrainerSlot
    {
        public TrainerSlot()
        {
            BirdTrainingReports = new HashSet<BirdTrainingReport>();
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
        public virtual ICollection<BirdTrainingReport> BirdTrainingReports { get; set; }
        public virtual ICollection<WorkshopClassDetail> WorkshopClassDetails { get; set; }
    }
}
