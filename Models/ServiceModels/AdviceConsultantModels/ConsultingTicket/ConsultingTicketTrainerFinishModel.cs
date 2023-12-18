using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels.ConsultingTicket
{
    public class ConsultingTicketTrainerFinishModel
    {
        public int Id { get; set; }
        public int ActualEndSlot { get; set; }
        public string? Evidence { get; set; }
    }
}
