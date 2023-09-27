using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class ConsultingType
    {
        public ConsultingType()
        {
            ConsultingPricePolicies = new HashSet<ConsultingPricePolicy>();
            ConsultingTickets = new HashSet<ConsultingTicket>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<ConsultingPricePolicy> ConsultingPricePolicies { get; set; }
        public virtual ICollection<ConsultingTicket> ConsultingTickets { get; set; }
    }
}
