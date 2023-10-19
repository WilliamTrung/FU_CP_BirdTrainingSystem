using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels.ConsultingTicket
{
    public class ConsultingTicketUpdateStatusModel
    {
        public int Id { get; set; }
        public Enum.ConsultingTicket.Status Status { get; set; }
    }
}
