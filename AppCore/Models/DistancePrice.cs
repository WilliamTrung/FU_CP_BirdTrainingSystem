using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class DistancePrice
    {
        public DistancePrice()
        {
            ConsultingTickets = new HashSet<ConsultingTicket>();
        }

        public int Id { get; set; }
        public int ConsultingPricePolicyId { get; set; }
        public int? From { get; set; }
        public int? To { get; set; }
        public decimal? PricePerKm { get; set; }

        public virtual ICollection<ConsultingTicket> ConsultingTickets { get; set; }
    }
}
