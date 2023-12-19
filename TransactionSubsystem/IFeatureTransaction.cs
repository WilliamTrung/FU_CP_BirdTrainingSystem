using Models.Entities;
using Models.ServiceModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionSubsystem
{
    public interface IFeatureTransaction
    {
        Task<decimal> CalculateDistancePrice(int distance);
        Task<decimal> CalculateMemberShipDiscountedPrice(int customerId, decimal price);
        Task<dynamic> CalculateConsultingTicketFinalPrice(int ticketId, int distance);
        Task<dynamic> CalculateConsultingTicketFinalPriceForTrainer(int ticketId, int totalSlot);
        Task<dynamic> CalculateConsultingTicketFinalPriceForCustomer(ConsultingTicketCreateNewModel consultingTicket, int distance);
        Task<dynamic> CalculateFinalPrice(int customerId, decimal price);
        Task<Transaction> AddTransaction(TransactionAddModel transaction);
    }
}
