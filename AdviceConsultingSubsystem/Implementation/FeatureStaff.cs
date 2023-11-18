using AppRepository.Repository.Implement;
using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdviceConsultingSubsystem.Implementation
{
    public class FeatureStaff : IFeatureStaff
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        public FeatureStaff(IUnitOfWork unitOfWork, IMapper mapper)
        { 
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicket()
        //{
        //    var entities = await _unitOfWork.ConsultingTicketRepository.Get();
        //    var models = new List<ConsultingTicketListViewModel>();
        //    foreach (var entity in entities) 
        //    {
        //        var model = _mapper.Map<ConsultingTicketListViewModel>(entity);
        //        models.Add(model);
        //    }

        //    return models;
        //}

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicketsByCustomerID(int customerID)
        {
            var entities = await _unitOfWork.ConsultingTicketRepository.Get(x => x.CustomerId == customerID);
            var models = new List<ConsultingTicketListViewModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<ConsultingTicketListViewModel>(entity);
                models.Add(model);
            }

            return models;
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListHandledConsultingTicket()
        {
            var entities = await _unitOfWork.ConsultingTicketRepository.Get(x => x.Status == (int)Models.Enum.ConsultingTicket.Status.Approved || x.Status == (int)Models.Enum.ConsultingTicket.Status.Canceled);
            var models = new List<ConsultingTicketListViewModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<ConsultingTicketListViewModel>(entity);
                models.Add(model);
            }

            return models;
        }

        public async Task<ConsultingTicketDetailViewModel> GetConsultingTicketByID(int id)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.Get(x => x.Id == id);
            var model = _mapper.Map<ConsultingTicketDetailViewModel>(entity);
            return model;
        }

        public async Task AssignTrainer(int trainerId, int ticketId)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id.Equals(ticketId));
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {ticketId}");
            }

            entity.TrainerId = trainerId;
            entity.Status = (int)Models.Enum.ConsultingTicket.Status.Approved;
            await _unitOfWork.ConsultingTicketRepository.Update(entity);
        }

        public async Task ApproveConsultingTicket(int ticketId)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id.Equals(ticketId));
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {ticketId}");
            }

            entity.Status = (int)Models.Enum.ConsultingTicket.Status.Approved;
            await _unitOfWork.ConsultingTicketRepository.Update(entity);
        }

        public async Task CancelConsultingTicket(int ticketId)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id.Equals(ticketId));
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {ticketId}");
            }

            var trainerSlot = await _unitOfWork.TrainerSlotRepository.GetFirst(x => x.Date == entity.AppointmentDate
                                                                            && x.SlotId == entity.ActualSlotStart
                                                                            && x.TrainerId == entity.TrainerId);
            if (trainerSlot != null && trainerSlot.EntityTypeId == (int)Models.Enum.EntityType.AdviceConsulting)
            {
                //trainerSlot.Status = (int)Models.Enum.TrainerSlotStatus.Disabled;
                await _unitOfWork.TrainerSlotRepository.Delete(trainerSlot);
            }

            entity.Status = (int)Models.Enum.ConsultingTicket.Status.Canceled;
            await _unitOfWork.ConsultingTicketRepository.Update(entity);
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListNotAssignedConsultingTicket()
        {
            var entities = await _unitOfWork.ConsultingTicketRepository.Get(x => x.TrainerId == 0 && x.Status == (int)Models.Enum.ConsultingTicket.Status.WaitingForApprove);
            var models = new List<ConsultingTicketListViewModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<ConsultingTicketListViewModel>(entity);
                models.Add(model);
            }

            return models;
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListAssignedConsultingTicket()
        {
            var entities = await _unitOfWork.ConsultingTicketRepository.Get(x => x.TrainerId != null && x.Status == (int)Models.Enum.ConsultingTicket.Status.WaitingForApprove);
            var models = new List<ConsultingTicketListViewModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<ConsultingTicketListViewModel>(entity);
                models.Add(model);
            }

            return models;
        }
    }
}
