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
        public int TrainerId { get; set; }
        public string ConsultingDetail { get; set; }
        public bool OnlineOrOffline { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int ActualSlotStart { get; set; }
    }
}
