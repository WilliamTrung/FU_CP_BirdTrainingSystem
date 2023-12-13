using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Enum.Trainer;
using Models.ServiceModels;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace AdviceConsultingSubsystem.Implementation
{
    public class OtherFeature : IOtherFeature
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        public OtherFeature(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ConsultingTicketDetailViewModel> GetConsultingTicketById(int id)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == id);
            var model = _mapper.Map<ConsultingTicketDetailViewModel>(entity);
            return model;
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicket()
        {
            var entities = await _unitOfWork.ConsultingTicketRepository.Get();
            var models = new List<ConsultingTicketListViewModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<ConsultingTicketListViewModel>(entity);
                models.Add(model);
            }

            return models;
        }

        public async Task<IEnumerable<ConsultingPricePolicyServiceModel>> GetConsultingPricePolicy()
        {
            var entities = await _unitOfWork.ConsultingPricePolicyRepository.Get();
            var models = new List<ConsultingPricePolicyServiceModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<ConsultingPricePolicyServiceModel>(entity);
                models.Add(model);
            }

            return models;
        }

        public async Task<IEnumerable<DistancePriceServiceModel>> GetDistancePricePolicy()
        {
            var entities = await _unitOfWork.DistancePriceRepository.Get(x => x.Id != 0);
            var models = new List<DistancePriceServiceModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<DistancePriceServiceModel>(entity);
                models.Add(model);
            }

            return models;
        }

        public async Task<IEnumerable<ConsultingTypeServiceModel>> GetConsutlingType()
        {
            var entities = await _unitOfWork.ConsultingTypeRepository.Get();
            var models = new List<ConsultingTypeServiceModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<ConsultingTypeServiceModel>(entity);
                models.Add(model);
            }

            return models;
        }

        public async Task CheckOutDateTicket()
        {
            var entities = await _unitOfWork.ConsultingTicketRepository.Get();
            foreach (var entity in entities)
            {
                var date = DateTime.Now;
                if (entity.AppointmentDate < date && entity.Status == (int)Models.Enum.ConsultingTicket.Status.WaitingForApprove)
                {
                    entity.Status = (int)Models.Enum.ConsultingTicket.Status.Cancelled;

                    var trainerSlot = await _unitOfWork.TrainerSlotRepository.GetFirst(x => x.Date == entity.AppointmentDate &&
                    x.SlotId == entity.ActualSlotStart &&
                    x.TrainerId == entity.TrainerId);
                    if (trainerSlot != null && trainerSlot.EntityTypeId == (int)Models.Enum.EntityType.AdviceConsulting)
                    {
                        await _unitOfWork.TrainerSlotRepository.Delete(trainerSlot);
                    }
                }
                else if (entity.AppointmentDate < date && entity.Status == (int)Models.Enum.ConsultingTicket.Status.Approved)
                {
                    var customer = await _unitOfWork.CustomerRepository.GetFirst(x => x.Id == entity.CustomerId);
                    if (customer.Status != (int)Models.Enum.Customer.Status.Charged)
                    {
                        customer.Status = (int)Models.Enum.Customer.Status.Charged;
                        await _unitOfWork.CustomerRepository.Update(customer);
                    }
                }
            }
        }

        public async Task<int> GetTrainerIdByTicketId(int ticketId)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == ticketId);
            var trainerId = (int)entity.TrainerId;
            return trainerId;
        }

        public async Task<ConsultingTicket> GetConsultingTicketByIDForDoingFunction(int id)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == id);
            return entity;
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetFinishedConsultingTicket()
        {
            var entities = await _unitOfWork.ConsultingTicketRepository.Get(x => x.Status == (int)Models.Enum.ConsultingTicket.Status.Finished);
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
