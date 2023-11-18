using Models.Entities;
using Models.ServiceModels;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdviceConsultingSubsystem
{
    public interface IOtherFeature
    {
        Task<IEnumerable<ConsultingPricePolicyServiceModel>> GetConsultingPricePolicy();
        Task<IEnumerable<DistancePriceServiceModel>> GetDistancePricePolicy();
        Task<ConsultingTicketDetailViewModel> GetConsultingTicketById(int id);
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicket();
        Task<IEnumerable<ConsultingTypeServiceModel>> GetConsutlingType();
        Task CheckOutDateTicket();
        Task<int> GetTrainerIdByTicketId (int ticketId);
        Task<ConsultingTicket> GetConsultingTicketByIDForDoingFunction(int id);
    }
}
