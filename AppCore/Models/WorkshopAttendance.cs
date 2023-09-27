using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class WorkshopAttendance
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int WorkshopClassId { get; set; }
        public int SlotId { get; set; }
        public int CustomerId { get; set; }
        public bool? Attendance { get; set; }

        public virtual WorkshopClassDetail WorkshopClassDetail { get; set; } = null!;
    }
}
