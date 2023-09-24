using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class WorkShopCategory
    {
        public WorkShopCategory()
        {
            Workshops = new HashSet<Workshop>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Duration { get; set; }
        public int? TotalDate { get; set; }

        public virtual ICollection<Workshop> Workshops { get; set; }
    }
}
