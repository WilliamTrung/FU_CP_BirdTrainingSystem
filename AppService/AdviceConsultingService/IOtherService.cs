﻿using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.AdviceConsultingService
{
    public interface IOtherService
    {
        Task<ConsultingTicketDetailViewModel> GetConsultingTicketById(int id);
        Task<IEnumerable<ConsultingTicketListViewModel>> GetConsultingTicketList();
        Task<IEnumerable<ConsultingPricePolicyServiceModel>> GetConsultingPricePolicy();
        Task<IEnumerable<DistancePriceServiceModel>> GetDistancePrice();
        Task<IEnumerable<ConsultingTypeServiceModel>> GetConsultingType();
    }
}