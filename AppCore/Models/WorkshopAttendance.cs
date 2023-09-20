using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class WorkshopAttendance
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int WorkshopId { get; set; }
        public DateTime? AttendDate { get; set; }
        public bool? Attendance { get; set; }

        public virtual CustomerWorkshopPayment CustomerWorkshopPayment { get; set; } = null!;
    }
}
