using AppCore.Models;
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

        public async Task<dynamic> CalculateConsultingTicketFinalPrice(int ticketId)
        {
            var ticket = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == ticketId);
            if (ticket == null)
            {
                throw new KeyNotFoundException($"{nameof(ticket)} not found for id: {ticketId}");
            }
#pragma warning disable CS8629 // Nullable value type may be null.
            int distance = (int)ticket.Distance;
#pragma warning restore CS8629 // Nullable value type may be null.
            var distancePrice = await CalculateDistancePrice(distance);

            var pricePolicy = await _unitOfWork.ConsultingPricePolicyRepository.GetFirst(x => x.OnlineOrOffline == ticket.OnlineOrOffline);
            var totalPrice = distancePrice + pricePolicy.Price;
            var discountedPrice = await CalculateMemberShipDiscountedPrice(totalPrice, ticket.CustomerId);
            var finalPrice = totalPrice - discountedPrice;
            //return finalPrice;
            return new
            {
                FinalPrice = finalPrice,
                DiscountedPrice = discountedPrice
            };
        }

        public async Task<decimal> CalculateDistancePrice(int distance)
        {
            if (distance == 0)
            {
                return 0;
            }
            var DistancePricePolicy = await _unitOfWork.DistancePriceRepository.Get();
            List<decimal> listDistancePrice = new List<decimal>();
            foreach (var  distancePrice in DistancePricePolicy)
            {
#pragma warning disable CS8629 // Nullable value type may be null.
                listDistancePrice.Add((decimal)distancePrice.PricePerKm);
#pragma warning restore CS8629 // Nullable value type may be null.
            }

            decimal calculated = distance;

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

            decimal discountRate = (decimal)customer.MembershipRank.Discount;

            decimal discountedAmount = price * discountRate;

            return discountedAmount;
        }
    }
}
