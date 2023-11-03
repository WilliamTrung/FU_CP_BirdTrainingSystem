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

        public async Task SendConsultingTicket(ConsultingTicketCreateNewModel consultingTicket, int distance, decimal finalPrice, decimal discountedPrice, string address, string consultingType)
        {
            var customerAddress = await _unitOfWork.AddressRepository.GetFirst(x => x.CustomerId == consultingTicket.CustomerId
                                                                    && x.AddressDetail == address);
            Address newAddress = new Address();
            if (customerAddress == null && address != null)
            {
                newAddress.CustomerId = consultingTicket.CustomerId;
                newAddress.AddressDetail = address;
                await _unitOfWork.AddressRepository.Add(newAddress);
            }
            var type = await _unitOfWork.ConsultingTypeRepository.GetFirst(x => x.Name == consultingType);

            var entity = _mapper.Map<ConsultingTicket>(consultingTicket);
            entity.AddressId = newAddress.Id;
            entity.ConsultingTypeId = type.Id;
            entity.Distance = distance;
            entity.Price = finalPrice;
            entity.DiscountedPrice = discountedPrice;
            entity.Status = (int)Models.Enum.ConsultingTicket.Status.WaitingForApprove;

            await _unitOfWork.ConsultingTicketRepository.Add(entity);
            //Add new Consulting Ticket
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
    }
}
