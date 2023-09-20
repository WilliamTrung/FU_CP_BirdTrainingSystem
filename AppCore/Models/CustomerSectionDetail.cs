using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class CustomerSectionDetail
    {
        public int CustomerId { get; set; }
        public int SectionId { get; set; }
        public bool? IsComplete { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Section Section { get; set; } = null!;
    }
}
