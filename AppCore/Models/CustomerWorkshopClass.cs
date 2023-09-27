using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class CustomerWorkshopClass
    {
        public int CustomerId { get; set; }
        public int WorkshopClassId { get; set; }
        public decimal? Price { get; set; }
        public float? Discount { get; set; }
        public float? RefundRate { get; set; }
        public int? Status { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual WorkshopClass WorkshopClass { get; set; } = null!;
    }
}
