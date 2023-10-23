using AdviceConsultingSubsystem;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;

namespace AppService.AdviceConsultingService.Implementation
{
    public class ServiceCustomer : OtherService, IServiceCustomer
    {
        public ServiceCustomer(IAdviceConsultingFeature consulting) : base(consulting) 
        {
        }
        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicketByCustomerID(int customerId)
        {
            return await _consulting.Customer.GetListConsultingTicketByCustomerID(customerId);
        }

        public async Task<ConsultingTicketDetailViewModel> GetConsultingTicketDetailByID(int id)
        {
            return await _consulting.Customer.GetConsultingTicketByID(id);
        }

        public async Task SendConsultingTicket(ConsultingTicketCreateNewModel consultingTicket)
        {
            await _consulting.Customer.SendConsultingTicket(consultingTicket);
        }
    }
}
