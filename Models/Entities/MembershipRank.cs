using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class MembershipRank
    {
        public MembershipRank()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public float? Discount { get; set; }
        public decimal? Requirement { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
