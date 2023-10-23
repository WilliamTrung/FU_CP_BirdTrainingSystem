using AppRepository.Repository;
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

            if (entity.OnlineOrOffline == true && consultingTicket.GgMeetLink != null)
            {
                entity.GgMeetLink = consultingTicket.GgMeetLink;
            }
            await _unitOfWork.ConsultingTicketRepository.Update(entity);
        }

        public async Task FinishAppointment(ConsultingTicketUpdateStatusModel consultingTicket)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == consultingTicket.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {consultingTicket.Id}");
            }

            entity.Status = consultingTicket.Status;

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

            if (entity.Price == 0 && consultingTicket.Price > 0)
            {
                entity.Price = consultingTicket.Price;
                entity.DiscountedPrice = consultingTicket.DiscountedPrice;
            }

            await _unitOfWork.ConsultingTicketRepository.Update(entity);
        }
    }
}
