using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class WorkshopDetailTemplate
    {
        public WorkshopDetailTemplate()
        {
            WorkshopClassDetails = new HashSet<WorkshopClassDetail>();
        }

        public int Id { get; set; }
        public int WorkshopId { get; set; }
        public string? Detail { get; set; }

        public virtual Workshop Workshop { get; set; } = null!;
        public virtual ICollection<WorkshopClassDetail> WorkshopClassDetails { get; set; }
    }
}
