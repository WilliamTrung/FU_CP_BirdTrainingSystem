using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
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

        public async Task<Transaction> AddTransaction(TransactionAddModel transaction)
        {
            var entity = _mapper.Map<Transaction>(transaction);
            await _unitOfWork.TransactionRepository.Add(entity);

            var customer = await _unitOfWork.CustomerRepository.GetFirst(x => x.Id == entity.CustomerId);
            if (customer != null) 
            {
                customer.TotalPayment += entity.TotalPayment;
#pragma warning disable CS8629 // Nullable value type may be null.
                var membership = await MembershipRankAtCost((decimal)customer.TotalPayment);
                if (customer.MembershipRankId != membership.Id)
                {
                    customer.MembershipRankId = membership.Id;
                }
#pragma warning restore CS8629 // Nullable value type may be null.
                await _unitOfWork.CustomerRepository.Update(customer);
            }
            return entity;
        }

        public async Task<dynamic> CalculateConsultingTicketFinalPrice(int ticketId, int distance)
        {
            var ticket = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == ticketId);
            var distancePrice = await CalculateDistancePrice(distance);

            decimal pricePolicy = (decimal)ticket.ConsultingPricePolicyCalculate;
            decimal totalPrice = distancePrice + pricePolicy;
            var discountedPrice = await CalculateMemberShipDiscountedPrice(ticket.CustomerId, totalPrice);
            var finalPrice = totalPrice - discountedPrice;

            dynamic price = new { FinalPrice = finalPrice, DiscountedPrice = discountedPrice, DistancePrice = distancePrice };
            return price;
        }

        public async Task<dynamic> CalculateConsultingTicketFinalPriceForCustomer(ConsultingTicketCreateNewModel consultingTicket, int distance)
        {
            var distancePrice = await CalculateDistancePrice(distance);

            var pricePolicy = await _unitOfWork.ConsultingPricePolicyRepository.GetFirst(x => x.OnlineOrOffline == consultingTicket.OnlineOrOffline);
            var totalPrice = distancePrice + pricePolicy.Price;
            var discountedPrice = await CalculateMemberShipDiscountedPrice(consultingTicket.CustomerId, totalPrice);
            var finalPrice = totalPrice - discountedPrice;

            dynamic price = new { FinalPrice = finalPrice, DiscountedPrice = discountedPrice, DistancePrice = distancePrice };
            return price;
        }

        public async Task<dynamic> CalculateConsultingTicketFinalPriceForTrainer(int ticketId, int totalSlot)
        {
            var ticket = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == ticketId);
            decimal distancePrice = (decimal)ticket.DistancePriceCalculate;
            var pricePolicy = (decimal)ticket.ConsultingPricePolicyCalculate;
            var totalPrice = distancePrice + pricePolicy*totalSlot;
            var discountedPrice = await CalculateMemberShipDiscountedPrice(ticket.CustomerId, totalPrice);
            var finalPrice = totalPrice - distancePrice;

            dynamic price = new { FinalPrice = finalPrice, DiscountedPrice = discountedPrice, DistancePrice = distancePrice };
            return price;
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
            bool check = true;
            while (check)
            {
                decimal t = calculated - khoangcachbac;
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

        public async Task<dynamic> CalculateFinalPrice(int customerId, decimal price)
        {
            var discountedPrice = await CalculateMemberShipDiscountedPrice(customerId, price);
            var finalPrice = price - discountedPrice;
            return new
            {
                FinalPrice = finalPrice,
                DiscountedPrice = discountedPrice
            };
        }

        public async Task<decimal> CalculateMemberShipDiscountedPrice(int customerId, decimal price)
        {
            var customer = await _unitOfWork.CustomerRepository.GetFirst(x => x.Id == customerId, nameof(Customer.MembershipRank));
            if (customer == null)
            {
                throw new KeyNotFoundException($"{nameof(customer)} not found for id: {customerId}");
            }
            var membership = await MembershipRankAtCost((decimal)customer.TotalPayment);
            decimal discountRate = (decimal)membership.Discount;

            decimal discountedAmount = price * discountRate;

            return discountedAmount;
        }
        private async Task<MembershipRank?> MembershipRankAtCost(decimal totalAmount)
        {
            var memberships = await _unitOfWork.MembershipRankRepository.Get(c => totalAmount >= c.Requirement);
            var membershipRank = memberships.MaxBy(c => c.Requirement);
            return membershipRank;
        }
    }
}
