﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels
{
    public class ConsultingPricePolicy
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public Enum.ConsultingTicket.OnlineOrOffline OnlineOrOffline { get; set; }
    }
}
