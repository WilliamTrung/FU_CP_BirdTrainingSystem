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

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListAssignedConsultingTicket(int trainerId)
        {
            var entities = await _unitOfWork.ConsultingTicketRepository.Get(x => x.Trainer.Id == trainerId
                                                                                && x.Status == (int)Models.Enum.ConsultingTicket.Status.Approved);
            var models = new List<ConsultingTicketListViewModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<ConsultingTicketListViewModel>(entity);
                models.Add(model);
            }
                
            return models;
        }

        public async Task UpdateAppointment(int ticketId, string ggmeetLink)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == ticketId);
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {ticketId}");
            }

            if (entity.OnlineOrOffline == true)
            {
                entity.GgMeetLink = ggmeetLink;
            }
            await _unitOfWork.ConsultingTicketRepository.Update(entity);
        }

        public async Task FinishAppointment(ConsultingTicketTrainerFinishModel ticket)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == ticket.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {ticket.Id}");
            }

            entity.ActualEndSlot = ticket.ActualEndSlot;
            entity.Evidence = ticket.Evidence;
            entity.Status = ticket.Status;

            await _unitOfWork.ConsultingTicketRepository.Update(entity);
        }
    }
}
