using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.AdviceConsultingService
{
    public interface IServiceCustomer : IOtherService
    {
        Task SendConsultingTicket(ConsultingTicketCreateNewModel consultingTicket, int distance, string address, string consultingType);
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicketByCustomerID(int customerId);
        Task<ConsultingTicketDetailViewModel> GetConsultingTicketDetailByID(int customerId);
        Task<bool> ValidateBeforeUsingSendConsultingTicket(int customerId);
    }
}
