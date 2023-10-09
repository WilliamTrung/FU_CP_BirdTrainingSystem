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

        public async Task<IEnumerable<WorkshopClassViewModel>> GetRegisteredWorkshopClasses(int customerId)
        {
            var entities = await _unitOfWork.CustomerWorkshopClassRepository.Get(c => c.CustomerId == customerId, nameof(CustomerWorkshopClass.WorkshopClass));
            var models = new List<WorkshopClassViewModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<WorkshopClassViewModel>(entity.WorkshopClass);
                models.Add(model);
            }
            return models;
        }

        public async Task Register(int customerId, int workshopClassId)
        {
            //add new entity to CustomerWorkshopClass
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
            var customerWorkshopClass = new CustomerWorkshopClass()
            {
                CustomerId = customerId,
                WorkshopClassId = workshopClassId,
                Price = workshopPrice,
                DiscountedPrice = discountedPrice,
            };
        }
    }
}
