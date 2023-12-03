using Models.Entities;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.AdviceConsultingService
{
    public interface IServiceStaff : IOtherService
    {
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicketsByCustomerID(int customerID);
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListHandledConsultingTicket();
        Task<ConsultingTicketDetailViewModel> GetConsultingTicketByID(int id);
        Task<ConsultingTicket> GetConsultingTicketByIDForDoingFunction(int id);
        Task AssignTrainer(int trainerId, int ticketId);
        Task ApproveConsultingTicket(int ticketId);
        Task CancelConsultingTicket(int ticketId);
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListNotAssignedConsultingTicket();
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListAssignedConsultingTicket();
        Task CreateNewPricePolicy(ConsultingPricePolicyCreateNewServiceModel pricePolicy);
        Task UpdateConsultantPricePolicy(ConsultingPricePolicyServiceModel pricePolicy);
        Task DeleteConsultingPricePolicy(int policyId);
        Task CreateNewDistancePricePolicy(DistancePricePolicyCreateNewServiceModel distancePricePolicy);
        Task UpdateDistancePricePolicy(DistancePricePolicyUpdateServiceModel distancePricePolicy);
        Task DeleteDistancePricePolicy(int distancePricePolicyId);
    }
}
