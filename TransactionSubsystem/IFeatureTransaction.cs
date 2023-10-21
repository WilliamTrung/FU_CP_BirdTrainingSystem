using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionSubsystem
{
    public interface IFeatureTransaction
    {
        Task<decimal> CalculateDistancePrice(float distance);
        Task<decimal> CalculateMemberShipDiscountedPrice(decimal price, int customerId);
    }
}
