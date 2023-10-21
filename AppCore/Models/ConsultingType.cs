﻿using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class ConsultingType
    {
        public ConsultingType()
        {
            ConsultingTickets = new HashSet<ConsultingTicket>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ConsultingTicket> ConsultingTickets { get; set; }
    }
}
