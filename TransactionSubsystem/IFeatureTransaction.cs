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
        Task<decimal> CalculateMemberShipDiscountedPrice(decimal price, int customerId);
        Task<dynamic> CalculateConsultingTicketFinalPrice(int ticketId);
    }
}
