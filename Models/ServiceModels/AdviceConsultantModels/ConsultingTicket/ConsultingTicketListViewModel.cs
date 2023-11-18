using System;
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
        public DateTime? AppointmentDate { get; set; }
        public string ActualSlotStart { get; set; }
        public string? ActualEndSlot { get; set; }
        public Models.Enum.ConsultingTicket.Status Status { get; set; }
    }
}
