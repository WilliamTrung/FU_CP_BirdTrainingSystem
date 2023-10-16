using Models.ServiceModels.AdviceConsultantModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdviceConsultingSubsystem
{
    public interface IFeatureCustomer
    {
        Task SendConsultingTicket(ConsultingTicketServiceModel consultingTicket);
        Task<IEnumerable<ConsultingTicketServiceModel>> GetListConsultingTicket(int customerId);
        //FE09[Customer] send[Help ticket] to the center
        //FE12[Customer] send[Advice ticket] to center
        //- [Advice ticket] must be select offline or online appointment;
        //- datetime must be within[Slot] provided by the center, specified price must be detailed on center website
    }
}
