using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class WorkshopRefundPolicy
    {
        public WorkshopRefundPolicy()
        {
            CustomerWorkshopClasses = new HashSet<CustomerWorkshopClass>();
        }

        public int Id { get; set; }
        public int TotalDayBeforeStart { get; set; }
        public float? RefundRate { get; set; }

        public virtual ICollection<CustomerWorkshopClass> CustomerWorkshopClasses { get; set; }
    }
}
