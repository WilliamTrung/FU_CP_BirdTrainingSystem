using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels.ConsultingTicket
{
    public class ConsultingTicketCreateNewModel
    {
        public int CustomerId { get; set; }
        public string? Address { get; set; }
        public string ConsultingType { get; set; }
        public int TrainerId { get; set; }
        public string ConsultingDetail { get; set; }
        public bool OnlineOrOffline { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public int ActualSlotStart { get; set; }
    }
}
