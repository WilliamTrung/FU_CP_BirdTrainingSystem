using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem.Implementation
{
    public class FeatureCustomer : FeatureAll, IFeatureCustomer
    {
        public FeatureCustomer(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<WorkshopClassViewModel>> GetRegisteredWorkshopClass(int customerId, int workshopId)
        {
            var entities = await _unitOfWork.CustomerWorkshopClassRepository.Get(c => c.CustomerId == customerId && workshopId == c.WorkshopClass.WorkshopId
                                                                                , nameof(CustomerWorkshopClass.WorkshopClass)
                                                                                , $"{nameof(CustomerWorkshopClass.WorkshopClass)}.{nameof(WorkshopClass.WorkshopClassDetails)}");
            var models = new List<WorkshopClassViewModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<WorkshopClassViewModel>(entity.WorkshopClass);
                models.Add(model);
            }
            return models;
        }
        public async Task<IEnumerable<WorkshopModel>> GetRegisteredWorkshops(int customerId)
        {
            var entities = await _unitOfWork.CustomerWorkshopClassRepository.Get(c => c.CustomerId == customerId, nameof(CustomerWorkshopClass.WorkshopClass));            
            var workshops = await _unitOfWork.WorkshopRepository.Get();
            workshops = workshops.Where(c => entities.Any(e => e.WorkshopClass.WorkshopId == c.Id));
            var models = _mapper.Map<List<WorkshopModel>>(workshops);
            return models;

        }
        public async Task Register(int customerId, int workshopClassId)
        {
            //add new entity to CustomerWorkshopClass
            var customerRegistered = await _unitOfWork.CustomerWorkshopClassRepository.GetFirst(c => c.WorkshopClassId == workshopClassId && c.CustomerId == customerId);
            if(customerRegistered != null && customerRegistered.Status == (int)Models.Enum.Workshop.Transaction.Status.Paid)
            {
                throw new InvalidOperationException($"{customerRegistered.Customer.User.Email} has paid for this workshop class!");
            }
            var workshopClass = await _unitOfWork.WorkshopClassRepository.GetFirst(c => c.Id == workshopClassId, nameof(WorkshopClass.Workshop));
            if(workshopClass == null)
            {
                throw new KeyNotFoundException($"{nameof(workshopClass)} at {workshopClassId}");
            }
            var customer = await _unitOfWork.CustomerRepository.GetFirst(c => c.Id == customerId, nameof(Customer.MembershipRank));
            if(customer == null)
            {
                throw new KeyNotFoundException($"{nameof(customer)} at {customerId}");
            }
            
            var workshopPrice = workshopClass.Workshop.Price;
            var discount = customer.MembershipRank.Discount.HasValue?customer.MembershipRank.Discount.Value:0;
            var discountedPrice = workshopPrice - workshopPrice * (decimal)discount;

            
            if(customerRegistered == null)
            {
                var customerWorkshopClass = new CustomerWorkshopClass()
                {
                    CustomerId = customerId,
                    WorkshopClassId = workshopClassId,
                    Price = workshopPrice,
                    DiscountedPrice = discountedPrice,
                    Status = (int)Models.Enum.Workshop.Transaction.Status.Unpaid
                };
                await _unitOfWork.CustomerWorkshopClassRepository.Add(customerWorkshopClass);
            } else
            {
                customerRegistered.Status = (int)Models.Enum.Workshop.Transaction.Status.Unpaid;
                customerRegistered.Price = workshopPrice;
                customerRegistered.DiscountedPrice = discountedPrice;
                await _unitOfWork.CustomerWorkshopClassRepository.Update(customerRegistered);
            }            
        }
    }
}
