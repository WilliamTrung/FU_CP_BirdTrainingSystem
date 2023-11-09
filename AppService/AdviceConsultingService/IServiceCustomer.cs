using Models.ServiceModels.AdviceConsultantModels;
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
        Task SendConsultingTicket(ConsultingTicketCreateNewModel consultingTicket, int distance);
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicketByCustomerID(int customerId);
        Task<ConsultingTicketDetailViewModel> GetConsultingTicketDetailByID(int customerId);
        Task<bool> ValidateBeforeUsingSendConsultingTicket(int customerId);
        Task<AddressServiceModel> GetListAddress(int customerId);
        Task<bool> CreateNewAddress (CreateNewAddressServiceModel address);
    }
}
