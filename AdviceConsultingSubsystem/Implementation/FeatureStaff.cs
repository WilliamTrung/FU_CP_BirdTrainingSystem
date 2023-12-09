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
            var entities = await _unitOfWork.ConsultingTicketRepository.Get(x => x.Status == (int)Models.Enum.ConsultingTicket.Status.Approved || x.Status == (int)Models.Enum.ConsultingTicket.Status.Cancelled);
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

        public async Task AssignTrainer(int trainerId, int ticketId, int distance, decimal finalPrice, decimal discountedPrice)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id.Equals(ticketId));
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {ticketId}");
            }

            if (entity.OnlineOrOffline == false)
            {
                entity.Distance = distance;
            }

            var distancePricePolicy = new DistancePrice();
            if (distance != 0)
            {
                distancePricePolicy = await _unitOfWork.DistancePriceRepository.GetFirst(x => x.From < distance && x.To > distance);
            }
            else
            {
                distancePricePolicy = await _unitOfWork.DistancePriceRepository.GetFirst(x => x.PricePerKm == 0);
            }

            entity.Price = finalPrice;
            entity.DiscountedPrice = discountedPrice;
            entity.DistancePriceId = distancePricePolicy.Id;
            entity.TrainerId = trainerId;
            entity.Status = (int)Models.Enum.ConsultingTicket.Status.Approved;
            await _unitOfWork.ConsultingTicketRepository.Update(entity);

            var trainerSlot = new AdviceConsultingTrainerSlotServiceModel((int)entity.TrainerId, entity.ActualSlotStart, DateOnly.FromDateTime((DateTime)entity.AppointmentDate), entity.Id);
            var slotEntity = _mapper.Map<TrainerSlot>(trainerSlot);
            await _unitOfWork.TrainerSlotRepository.Add(slotEntity);
        }

        public async Task ApproveConsultingTicket(int ticketId, int distance, decimal finalPrice, decimal discountedPrice)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id.Equals(ticketId));
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {ticketId}");
            }

            if (entity.OnlineOrOffline == false)
            {
                entity.Distance = distance;
            }

            var distancePricePolicy = new DistancePrice();
            if (distance != 0)
            {
                distancePricePolicy = await _unitOfWork.DistancePriceRepository.GetFirst(x => x.From < distance && x.To > distance);
            }
            else
            {
                distancePricePolicy = await _unitOfWork.DistancePriceRepository.GetFirst(x => x.PricePerKm == 0);
            }

            entity.Price = finalPrice;
            entity.DiscountedPrice = discountedPrice;
            entity.DistancePriceId = distancePricePolicy.Id;

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

            entity.Status = (int)Models.Enum.ConsultingTicket.Status.Cancelled;
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
            var entities = await _unitOfWork.ConsultingTicketRepository.Get(x => x.TrainerId != 0 && x.Status == (int)Models.Enum.ConsultingTicket.Status.WaitingForApprove);
            var models = new List<ConsultingTicketListViewModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<ConsultingTicketListViewModel>(entity);
                models.Add(model);
            }

            return models;
        }

        public async Task CreateNewConsultingPricePolicy(ConsultingPricePolicyCreateNewServiceModel pricePolicy)
        {
            var entity = _mapper.Map<ConsultingPricePolicy>(pricePolicy);
            await _unitOfWork.ConsultingPricePolicyRepository.Add(entity);
        }

        public async Task UpdateConsultantPricePolicy(ConsultingPricePolicyUpdateServiceModel pricePolicy)
        {
            var entity = await _unitOfWork.ConsultingPricePolicyRepository.GetFirst(x => x.Id == pricePolicy.Id);
            entity.Price = (decimal)pricePolicy.Price;
            await _unitOfWork.ConsultingPricePolicyRepository.Update(entity);
        }

        public async Task DeleteConsultingPricePolicy(int policyId)
        {
            var entity = await _unitOfWork.ConsultingPricePolicyRepository.GetFirst(x => x.Id == policyId);
            await _unitOfWork.ConsultingPricePolicyRepository.Delete(entity);
        }

        public async Task CreateNewDistancePricePolicy(DistancePricePolicyCreateNewServiceModel distancePricePolicy)
        {
            var entity = _mapper.Map<DistancePrice>(distancePricePolicy);
            await _unitOfWork.DistancePriceRepository.Add(entity);
        }

        public async Task UpdateDistancePricePolicy(DistancePricePolicyUpdateServiceModel distancePricePolicy)
        {
            var entity = await _unitOfWork.DistancePriceRepository.GetFirst(x => x.Id == distancePricePolicy.Id);
            entity.PricePerKm = distancePricePolicy.PricePerKm;
            await _unitOfWork.DistancePriceRepository.Update(entity);

        }

        public async Task DeleteDistancePricePolicy(int distancePricePolicyId)
        {
            var entity = await _unitOfWork.DistancePriceRepository.GetFirst(x => x.Id == distancePricePolicyId);
            await _unitOfWork.DistancePriceRepository.Update(entity);
        }

        public async Task CreateConsultingType(ConsultingTypeCreateNewServiceModel consultingType)
        {
            var entity = _mapper.Map<ConsultingType>(consultingType);
            await _unitOfWork.ConsultingTypeRepository.Add(entity);
        }

        public async Task UpdateConsultingType(ConsultingTypeServiceModel consultingType)
        {
            var entity = await _unitOfWork.ConsultingTypeRepository.GetFirst(x => x.Id == consultingType.Id);
            entity.Name = consultingType.Name;
            await _unitOfWork.ConsultingTypeRepository.Update(entity);
        }

        public async Task DeleteConsultingType(int consultingTypeId)
        {
            var entity = await _unitOfWork.ConsultingTypeRepository.GetFirst(x => x.Id == consultingTypeId);
            await _unitOfWork.ConsultingTypeRepository.Delete(entity);
        }
    }
}
