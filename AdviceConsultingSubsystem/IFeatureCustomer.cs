﻿using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdviceConsultingSubsystem
{
    public interface IFeatureCustomer
    {
        Task SendConsultingTicket(ConsultingTicketCreateNewModel consultingTicket, int distance, decimal finalPrice, decimal discountedPrice, decimal distancePrice);
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicketByCustomerID(int customerId);
        Task<ConsultingTicketDetailViewModel> GetConsultingTicketByID(int customerId);
        Task<bool> ValidateBeforeUsingSendConsultingTicket(int customerId);
        Task<AddressServiceModel> GetListAddress(int customerId);
        Task<bool> CreateNewAddress(CreateNewAddressServiceModel address);
        //- [Advice ticket] must be select offline or online appointment;
        //- datetime must be within[Slot] provided by the center, specified price must be detailed on center website
    }
}
