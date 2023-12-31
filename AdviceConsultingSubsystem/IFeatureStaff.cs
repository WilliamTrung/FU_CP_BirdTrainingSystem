﻿using Models.DashboardModels.TicketRatioBetweenOnlOff;
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
        Task AssignTrainer(int trainerId, int ticketId, int distance, decimal finalPrice, decimal discountedPrice, decimal distancePrice);
        Task ApproveConsultingTicket(int ticketId, int distance, decimal finalPrice, decimal discountedPrice, decimal distancePrice);
        Task CancelConsultingTicket(int ticketId);
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListNotAssignedConsultingTicket();
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListAssignedConsultingTicket();
        Task CreateNewConsultingPricePolicy(ConsultingPricePolicyCreateNewServiceModel pricePolicy);
        Task UpdateConsultantPricePolicy(ConsultingPricePolicyUpdateServiceModel pricePolicy);
        Task DeleteConsultingPricePolicy(int policyId);
        Task CreateNewDistancePricePolicy(DistancePricePolicyCreateNewServiceModel distancePricePolicy);
        Task UpdateDistancePricePolicy(DistancePricePolicyUpdateServiceModel distancePricePolicy);
        Task DeleteDistancePricePolicy(int distancePricePolicyId);
        Task CreateConsultingType(ConsultingTypeCreateNewServiceModel consultingType);
        Task UpdateConsultingType(ConsultingTypeServiceModel consultingType);
        Task DeleteConsultingType(int consultingTypeId);
        Task<TicketRatioOnlOff> GetTicketRatioOnlOff(int year);
        Task<TicketRatioOnlOff> GetTicketRatioOnlOffByMonth(int month);
    }
}
