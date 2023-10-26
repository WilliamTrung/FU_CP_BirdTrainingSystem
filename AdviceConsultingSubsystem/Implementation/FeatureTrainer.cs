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

        public async Task UpdateAppointment(int ticketId, string ggmeetLink)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == ticketId);
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {ticketId}");
            }

            if (entity.OnlineOrOffline == true && ggmeetLink != null)
            {
                entity.GgMeetLink = ggmeetLink;
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
        public async Task<ConsultingTicketBillModel> FillOutBillingForm(ConsultingTicketBillModel consultingTicket)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == consultingTicket.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {consultingTicket.Id}");
            }

            entity.ActualSlotStart = consultingTicket.ActualSlotStart;
            entity.ActualEndSlot = consultingTicket.ActualEndSlot;
            entity.Evidence = consultingTicket.Evidence;

            if (consultingTicket.Price > 0)
            {
                entity.Price = consultingTicket.Price;
                entity.DiscountedPrice = consultingTicket.DiscountedPrice;
            }

            await _unitOfWork.ConsultingTicketRepository.Update(entity);

            var model = _mapper.Map<ConsultingTicketBillModel>(entity);
            return model;
        }

        public Task UploadEvidence(int ticketId, string evidence)
        {
            throw new NotImplementedException();
        }
    }
}
