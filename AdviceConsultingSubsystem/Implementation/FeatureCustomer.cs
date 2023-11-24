using AppRepository.Repository.Implement;
using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionSubsystem;

namespace AdviceConsultingSubsystem.Implementation
{
    public class FeatureCustomer : IFeatureCustomer
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        public FeatureCustomer(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task SendConsultingTicket(ConsultingTicketCreateNewModel consultingTicket, int distance, decimal finalPrice, decimal discountedPrice)
        {   
            var pricePolicy = await _unitOfWork.ConsultingPricePolicyRepository.GetFirst(x => x.OnlineOrOffline == consultingTicket.OnlineOrOffline);

            var distancePricePolicy = new DistancePrice(); 
            if (distance != 0)
            {
                distancePricePolicy = await _unitOfWork.DistancePriceRepository.GetFirst(x => x.From < distance && x.To > distance);
            }
            else
            {
                distancePricePolicy = await _unitOfWork.DistancePriceRepository.GetFirst(x => x.PricePerKm == 0);
            }

            var address = await _unitOfWork.AddressRepository.GetFirst(x => x.CustomerId == consultingTicket.CustomerId && x.AddressDetail == consultingTicket.AddressDetail);
            if (address == null)
            {
                var newAddress = new Address()
                {
                    CustomerId = consultingTicket.CustomerId,
                    AddressDetail = consultingTicket.AddressDetail
                };
                await _unitOfWork.AddressRepository.Add(newAddress);

                address = newAddress;
            }
            
            var entity = _mapper.Map<ConsultingTicket>(consultingTicket);
            entity.AddressId = address.Id;
            entity.ConsultingTypeId = consultingTicket.ConsultingTypeId;
            entity.Distance = distance;
            entity.Price = finalPrice;
            entity.DiscountedPrice = discountedPrice;
            entity.Status = (int)Models.Enum.ConsultingTicket.Status.WaitingForApprove;
            entity.ConsultingPricePolicyId = pricePolicy.Id;
            entity.DistancePriceId = distancePricePolicy.Id;

            await _unitOfWork.ConsultingTicketRepository.Add(entity);
            //Add new Consulting Ticket

            //Cập nhật trainerSlot
            if (consultingTicket.TrainerId != 0)
            {
                var trainerSlot = new AdviceConsultingTrainerSlotServiceModel(
                    (int)entity.TrainerId, entity.ActualSlotStart, DateOnly.FromDateTime((DateTime)entity.AppointmentDate), entity.Id);
                var slotEntity = _mapper.Map<TrainerSlot>(trainerSlot);
                await _unitOfWork.TrainerSlotRepository.Add(slotEntity);
            }
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicketByCustomerID(int customerId)
        {
            var entites = await _unitOfWork.ConsultingTicketRepository.Get(x => x.CustomerId == customerId);
            var models = new List<ConsultingTicketListViewModel>();
            foreach (var entity in entites)
            {
                var model = _mapper.Map<ConsultingTicketListViewModel>(entity);
                models.Add(model);
            }
            return models;
        }

        public async Task<ConsultingTicketDetailViewModel> GetConsultingTicketByID(int customerId)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == customerId);
            var model = _mapper.Map<ConsultingTicketDetailViewModel>(entity);
            return model;
        }

        public async Task<bool> ValidateBeforeUsingSendConsultingTicket(int customerId)
        {
            var customer = await _unitOfWork.CustomerRepository.GetFirst(x => x.Id == customerId);
            if (customer.Status == (int)Models.Enum.Customer.Status.Charged)
            {
                return false;
            }
            return true;
        }

        public async Task<AddressServiceModel> GetListAddress(int customerId)
        {
            var entity = await _unitOfWork.AddressRepository.Get(x => x.CustomerId == customerId);
            var model = _mapper.Map<AddressServiceModel>(entity);
            return model;
        }

        public async Task<bool> CreateNewAddress(CreateNewAddressServiceModel address)
        {
            var check = await _unitOfWork.AddressRepository.GetFirst(x => x.CustomerId == address.CustomerId && x.AddressDetail == address.AddressDetail);
            if (check != null)
            {
                return false;
            }
            var entity = _mapper.Map<Address>(address);
            await _unitOfWork.AddressRepository.Add(entity);

            return true;
        }
    }
}
