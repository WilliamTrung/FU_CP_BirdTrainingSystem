﻿using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class ConsultingPricePolicy
    {
        public ConsultingPricePolicy()
        {
            ConsultingTickets = new HashSet<ConsultingTicket>();
        }

        public int Id { get; set; }
        public decimal Price { get; set; }
        public int OnlineOrOffline { get; set; }

        public virtual ICollection<ConsultingTicket> ConsultingTickets { get; set; }
    }
}
