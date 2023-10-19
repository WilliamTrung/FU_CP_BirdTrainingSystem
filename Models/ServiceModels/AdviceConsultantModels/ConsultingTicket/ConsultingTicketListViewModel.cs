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
        public CustomerServiceModel customer { get; set; } = null!;
        public DateTime? ExpectedDate { get; set; }
        public int? ExpectedSlotStart { get; set; }
        public int? ExpectedSlotEnd { get; set; }
        public Enum.ConsultingTicket.Status Status { get; set; }
    }
}
