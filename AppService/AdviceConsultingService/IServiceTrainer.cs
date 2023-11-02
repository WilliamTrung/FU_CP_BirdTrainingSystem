using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.AdviceConsultingService
{
    public interface IServiceTrainer : IOtherService
    {
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListAssignedConsultingTicket(int trainerId);
        Task UpdateAppointment(int ticketId, string ggmeetLink);
        Task FinishAppointment(ConsultingTicketTrainerFinishModel consultingTicket);
    }
}
