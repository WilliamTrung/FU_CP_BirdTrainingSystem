using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdviceConsultingSubsystem
{
    public interface IFeatureStaff
    {
        //Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicket();
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicketsByCustomerID(int customerID);
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListHandledConsultingTicket();
        Task<ConsultingTicketDetailViewModel> GetConsultingTicketByID(int id);
        Task AssignTrainer(int trainerId, int ticketId);
        Task ApproveConsultingTicket(int ticketId);
        Task CancelConsultingTicket(int ticketId);
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListNotAssignedConsultingTicket();
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListAssignedConsultingTicket();
    }
}
