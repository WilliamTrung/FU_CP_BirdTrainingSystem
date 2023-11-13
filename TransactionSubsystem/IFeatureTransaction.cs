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
        Task<dynamic> CalculateConsultingTicketFinalPrice(ConsultingTicketCreateNewModel consultingTicket, int distance);
        Task<dynamic> CalculateFinalPrice(int customerId, decimal price);
        Task AddTransaction(TransactionAddModel transaction);
    }
}
