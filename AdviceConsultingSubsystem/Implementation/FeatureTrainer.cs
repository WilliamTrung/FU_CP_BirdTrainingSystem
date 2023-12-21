using AppRepository.Repository;
using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TransactionSubsystem;

namespace AdviceConsultingSubsystem.Implementation
{
    public class FeatureTrainer : IFeatureTrainer
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        internal readonly IFeatureTransaction _transaction;
        public FeatureTrainer(IUnitOfWork unitOfWork, IMapper mapper, IFeatureTransaction transaction)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _transaction = transaction;
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

        public async Task FinishAppointment(int ticketId)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == ticketId, nameof(Customer.User));
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {ticketId}");
            }
            entity.Status = (int)Models.Enum.ConsultingTicket.Status.Finished;

            await _unitOfWork.ConsultingTicketRepository.Update(entity);

            string paymentCode = "offline";
            string formattedDateTime = DateTime.UtcNow.AddHours(7).ToString("ddMMMyyyyhhmm");
            var transactionModel = new TransactionAddModel()
            {
                CustomerId = entity.CustomerId,
                EntityId = entity.Id,
                EntityTypeId = (int)Models.Enum.EntityType.AdviceConsulting,
                PaymentCode = paymentCode,
                Detail = $"{paymentCode}:{entity.CustomerId}:{entity.Customer.User.Email}-" +
                $"Finish Consulting Appointmnet {entity.Id}",
                Status = (int)Models.Enum.Transaction.Status.Paid,
                Title = "Finish Consulting Appointment",
                TotalPayment = entity.Price,
            };

            await _transaction.AddTransaction(transactionModel);
        }

        public async Task UpdateEvidence(ConsultingTicketTrainerFinishModel ticket, decimal finalPrice, decimal discountedPrice)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == ticket.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {ticket.Id}");
            }

            entity.ActualEndSlot = ticket.ActualEndSlot;    
            entity.Evidence = ticket.Evidence;
            entity.Price = finalPrice;
            entity.DiscountedPrice = discountedPrice;
            await _unitOfWork.ConsultingTicketRepository.Update(entity);
        }
    }
}
