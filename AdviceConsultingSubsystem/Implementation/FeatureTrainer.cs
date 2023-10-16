using AppRepository.UnitOfWork;
using AutoMapper;
using Models.ServiceModels.AdviceConsultantModels;
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

        public async Task<IEnumerable<ConsultingTicketServiceModel>> ViewAssignedAppointment (int id)
        {
            var entities = await _unitOfWork.ConsultingTicketRepository.Get(x => x.Trainer.Id == id && x.Status == 1);
            var models = _mapper.Map<IEnumerable<ConsultingTicketServiceModel>>(entities);
            return models;
        }

        public async Task FillOutBillingForm(ConsultingTicketServiceModel consultingTicket, int actualSlotStart, int actualEndSlot)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == consultingTicket.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {consultingTicket.Id}");
            }

            if (entity.Price == 0)
            {
                var price = await _unitOfWork.ConsultingPricePolicyRepository.GetFirst(x => x.OnlineOrOffline == entity.OnlineOrOffline);
                var totalSlot = actualEndSlot - actualSlotStart;
                //Tinh toan tien 
                var totalPrice = price.Price * totalSlot;
                var membershipDiscount = await _unitOfWork.MembershipRankRepository.GetFirst(x => x.Id == consultingTicket.customer.MembershipRankId);
                var finalPrice = totalPrice - totalPrice * (int)membershipDiscount.Discount;
            }
        }
    }
}
