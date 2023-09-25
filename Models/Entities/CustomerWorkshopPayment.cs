using System;
using System.Collections.Generic;
    
namespace Models.Entities
{
    public partial class CustomerWorkshopPayment
    {
        public CustomerWorkshopPayment()
        {
            WorkshopAttendances = new HashSet<WorkshopAttendance>();
        }

        public int CustomerId { get; set; }
        public int WorkshopId { get; set; }
        public decimal? TotalPrice { get; set; }
        public float? Discount { get; set; }
        public bool? Status { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Workshop Workshop { get; set; } = null!;
        public virtual ICollection<WorkshopAttendance> WorkshopAttendances { get; set; }
    }
}
