using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class WorkshopAttendance
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int WorkshopClassDetailId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual WorkshopClassDetail WorkshopClassDetail { get; set; } = null!;
    }
}
