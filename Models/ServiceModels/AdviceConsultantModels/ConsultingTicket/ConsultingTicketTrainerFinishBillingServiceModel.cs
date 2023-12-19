using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels.ConsultingTicket
{
    public class ConsultingTicketTrainerFinishBillingServiceModel
    {
        public int Id { get; set; }
        public string ActualSlotStart { get; set; }
        public int ActualEndSlot { get; set; }
    }
}
