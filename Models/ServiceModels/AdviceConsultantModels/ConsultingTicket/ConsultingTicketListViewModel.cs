﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels.ConsultingTicket
{
    public class ConsultingTicketListViewModel
    {
        public int Id { get; set; }
        public bool OnlineOrOffline { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int ActualSlotStart { get; set; }
        public int ActualEndSlot { get; set; }
        public int Status { get; set; }
    }
}
