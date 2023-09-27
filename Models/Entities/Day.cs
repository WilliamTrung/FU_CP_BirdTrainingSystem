using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class Day
    {
        public Day()
        {
            Slots = new HashSet<Slot>();
        }

        public int Id { get; set; }
        public int WeekId { get; set; }
        public int? Status { get; set; }

        public virtual Week Week { get; set; } = null!;
        public virtual ICollection<Slot> Slots { get; set; }
    }
}
