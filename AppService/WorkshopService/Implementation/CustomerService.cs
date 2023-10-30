using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;
using TransactionSubsystem;
using WorkshopSubsystem;

namespace AppService.WorkshopService.Implementation
{
    public class CustomerService : AllService, IServiceCustomer
    {
        private readonly IFeatureTransaction _transaction;
        public CustomerService(IWorkshopFeature workshop, ITimetableFeature timetable, IFeatureTransaction transaction) : base(workshop, timetable)
        {
            _transaction = transaction;
        }

        public async Task<IEnumerable<WorkshopClassViewModel>> GetRegisteredClass(int customerId, int workshopId)
        {
            return await _workshop.Customer.GetRegisteredWorkshopClass(customerId, workshopId);
        }

        public async Task Register(int customerId, int workshopClassId)
        {
            if(await _workshop.All.SetWorkshopClassFull(workshopClassId))
            {
                throw new InvalidOperationException("This workshop class is full!");
            } else
            {
                await _workshop.Customer.Register(customerId, workshopClassId);
            }            
        }
        public async Task<IEnumerable<WorkshopModel>> GetRegisteredWorkshopss(int customerId)
        {
            return await _workshop.Customer.GetRegisteredWorkshops(customerId);
        }
        public async Task<BillingModel> GetBillingInformation(int customerId, int workshopClassId)
        {
            var customerRegistered = await _workshop.Customer.GetCustomerRegistrationInfo(customerId, workshopClassId);
            if(customerRegistered == null)
            {
                throw new InvalidOperationException("Has not registered this class!");
            }
            var discounted = await _transaction.CalculateMemberShipDiscountedPrice(customerId, customerRegistered.WorkshopClass.Workshop.Price);
            var final = customerRegistered.WorkshopClass.Workshop.Price - discounted;
            var billingInfo = new BillingModel
            {
                DiscountedPrice = discounted,
                MembershipName = customerRegistered.Customer.MembershipRank.Name,
                RefundRate = (decimal)customerRegistered.Customer.MembershipRank.Discount,
                TotalPrice = final,
                WorkshopPrice = customerRegistered.WorkshopClass.Workshop.Price,
            };
            return billingInfo;
        }

        public async Task PurchaseClass(int customerId, int workshopClassId)
        {
            //var customerRegistered = await _workshop.Customer.GetCustomerRegistrationInfo(customerId, workshopClassId);
            var billingInfo = await GetBillingInformation(customerId, workshopClassId);
            await _workshop.Customer.OnPurchaseClass(customerId, workshopClassId, billingInfo);
        }
    }
}
