﻿using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class WorkshopClassDetail
    {
        public WorkshopClassDetail()
        {
            WorkshopAttendances = new HashSet<WorkshopAttendance>();
        }
        public int Id { get; set; }
        public int WorkshopClassId { get; set; }
        public int DetailId { get; set; }
        public int? DaySlotId { get; set; }
        public DateTime? UpdateDate { get; set; }

        //public virtual WorkshopDetailTemplate Detail { get; set; } = null!;
        public virtual TrainerSlot? DaySlot { get; set; }
        public virtual WorkshopClass WorkshopClass { get; set; } = null!;
        public virtual WorkshopDetailTemplate WorkshopDetailTemplate { get; set; } = null!;
        public virtual ICollection<WorkshopAttendance> WorkshopAttendances { get; set; } 
    }
}
