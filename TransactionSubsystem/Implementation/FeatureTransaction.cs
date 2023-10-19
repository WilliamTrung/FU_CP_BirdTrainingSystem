using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionSubsystem.Implementation
{
    public class FeatureTransaction : IFeatureTransaction
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        public FeatureTransaction(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<decimal> CalculateDistancePrice(float distance)
        {
            var DistancePricePolicy = await _unitOfWork.DistancePriceRepository.Get();
            List<decimal> listDistancePrice = new List<decimal>();
            foreach (var  distancePrice in DistancePricePolicy)
            {
#pragma warning disable CS8629 // Nullable value type may be null.
                listDistancePrice.Add((decimal)distancePrice.PricePerKm);
#pragma warning restore CS8629 // Nullable value type may be null.
            }

            decimal calculated = (decimal)distance;

            int bachientai = 0;
            int khoangcachbac = Models.ConfigModels.TransactionConstant.KhoangCachBac;
            decimal totalDistancePrice = 0;
            decimal t = calculated - khoangcachbac;
            bool check = true;
            while (check)
            {
                if (t > 0)
                {
                    totalDistancePrice += listDistancePrice.ElementAt(bachientai) * khoangcachbac;
                    calculated = t;
                    if (bachientai < listDistancePrice.Count())
                    {
                        bachientai++;
                    }
                }
                else
                {
                    totalDistancePrice += listDistancePrice.ElementAt(bachientai) * calculated;
                    check = false;
                }
            }

            return totalDistancePrice;
        }

        public async Task<decimal> CalculateMemberShipDiscountedPrice(decimal price, int customerId)
        {
            var customer = await _unitOfWork.CustomerRepository.GetFirst(x => x.Id == customerId, nameof(Customer.MembershipRank));
            if (customer == null)
            {
                throw new KeyNotFoundException($"{nameof(customer)} not found for id: {customerId}");
            }

#pragma warning disable CS8629 // Nullable value type may be null.
            decimal discountRate = (decimal)customer.MembershipRank.Discount;
#pragma warning restore CS8629 // Nullable value type may be null.

            decimal discountedAmount = price * discountRate;

            return discountedAmount;
        }
    }
}
