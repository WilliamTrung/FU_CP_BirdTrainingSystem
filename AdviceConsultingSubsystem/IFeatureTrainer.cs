using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdviceConsultingSubsystem
{
    public interface IFeatureTrainer
    {
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListAssignedConsultingTicket(int trainerId);
        Task UpdateAppointment(int ticketId, string ggmeetLink);
        Task FinishAppointment(ConsultingTicketTrainerFinishModel consultingTicket);
    }
}
