using AdviceConsultingSubsystem;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;

namespace AppService.AdviceConsultingService.Implementation
{
    public class OtherService : IOtherService
    {
        internal readonly IAdviceConsultingFeature _consulting;

        public OtherService(IAdviceConsultingFeature consulting)
        {
            _consulting = consulting;
        }

        public async Task<IEnumerable<ConsultingPricePolicyServiceModel>> GetConsultingPricePolicy()
        {
            return await _consulting.Other.GetConsultingPricePolicy();
        }

        public async Task<ConsultingTicketDetailViewModel> GetConsultingTicketById(int id)
        {
            return await _consulting.Other.GetConsultingTicketById(id);
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetConsultingTicketList()
        {
            return await _consulting.Other.GetListConsultingTicket();
        }

        public async Task<IEnumerable<ConsultingTypeServiceModel>> GetConsultingType()
        {
            return await _consulting.Other.GetConsutlingType();
        }

        public async Task<IEnumerable<DistancePriceServiceModel>> GetDistancePrice()
        {
            return await _consulting.Other.GetDistancePricePolicy();
        }
    }
}
