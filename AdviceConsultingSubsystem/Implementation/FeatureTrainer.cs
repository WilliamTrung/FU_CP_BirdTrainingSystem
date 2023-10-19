using AppRepository.UnitOfWork;
using AutoMapper;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdviceConsultingSubsystem.Implementation
{
    public class FeatureTrainer : IFeatureTrainer
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        public FeatureTrainer(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> ViewAssignedAppointment (int id)
        {
            var entities = await _unitOfWork.ConsultingTicketRepository.Get(x => x.Trainer.Id == id);
            var models = _mapper.Map<IEnumerable<ConsultingTicketListViewModel>>(entities);
            return models;
        }

        public async Task UpdateAppointment(ConsultingTicketUpdateModel consultingTicket)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == consultingTicket.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {consultingTicket.Id}");
            }

            if (consultingTicket.GgMeetLink != null)
            {
                entity.GgMeetLink = consultingTicket.GgMeetLink;
            }
            await _unitOfWork.ConsultingTicketRepository.Update(entity);
        }

        public async Task FillOutBillingForm(ConsultingTicketUpdateModel consultingTicket)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == consultingTicket.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {consultingTicket.Id}");
            }

            var actualSlotStart = consultingTicket.ActualSlotStart;
            var actualEndSlot = consultingTicket.ActualEndSlot;

            if (entity.Price == 0)
            {
                int distancePrice = await CalculateDistancePrice(entity.DistancePrice.PricePerKm);
                var slotPrice = await _unitOfWork.ConsultingPricePolicyRepository.GetFirst(x => x.OnlineOrOffline == entity.OnlineOrOffline);
                var totalSlot = actualEndSlot - actualSlotStart;
                //Tinh toan tien 
                var totalPrice = slotPrice.Price * totalSlot + distancePrice;
                var membershipDiscount = await _unitOfWork.MembershipRankRepository.GetFirst(x => x.Id == entity.Customer.MembershipRankId);
                var finalPrice = totalPrice - totalPrice * (int)membershipDiscount.Discount;
            }
        }

        public async Task<decimal> CalculateDistancePrice (float distance)
        {
            var DistancePricePolicy = await _unitOfWork.DistancePriceRepository.Get();
            List<decimal> listDistancePrice = new List<decimal>();
            foreach (var item in DistancePricePolicy)
            {
#pragma warning disable CS8629 // Nullable value type may be null.
                listDistancePrice.Add((decimal)item.PricePerKm);
#pragma warning restore CS8629 // Nullable value type may be null.
            }
            //1k 2k 3k 4k

            decimal calculate = (decimal)distance; 
            int bachientai = 0;
            int khoangcachbac = 10;
            decimal totalDistancePrice = 0;
            decimal t = calculate - khoangcachbac;
            bool check = true;
            while (check)
            {
                if (t > 0)
                {
                    totalDistancePrice += listDistancePrice.ElementAt(bachientai) * khoangcachbac; 
                    calculate = t;
                    if (bachientai < listDistancePrice.Count()) 
                        {
                        bachientai ++;
                        }
                }
                else
                {
                    totalDistancePrice += listDistancePrice.ElementAt(bachientai) * calculate;
                    check = false;
                }
            }
            

            return totalDistancePrice;
        }
    }
}
