using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class WorkshopClassDetail
    {
        public WorkshopClassDetail()
        {
            WorkshopAttendances = new HashSet<WorkshopAttendance>();
        }

        public int WorkshopClassId { get; set; }
        public int TrainerId { get; set; }
        public int SlotId { get; set; }
        public string? Detail { get; set; }

        public virtual Trainer Trainer { get; set; } = null!;
        public virtual WorkshopClass WorkshopClass { get; set; } = null!;
        public virtual ICollection<WorkshopAttendance> WorkshopAttendances { get; set; }
    }
}
