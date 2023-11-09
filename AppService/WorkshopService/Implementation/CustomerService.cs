using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.Feedback;
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
            var preBillingInfo = await _workshop.Customer.GetPreBillingInformation(customerId, workshopClassId);
            var discounted = await _transaction.CalculateMemberShipDiscountedPrice(customerId, preBillingInfo.WorkshopPrice);
            var final = preBillingInfo.WorkshopPrice - discounted;
            var billingInfo = new BillingModel
            {
                DiscountedPrice = discounted,
                MembershipName = preBillingInfo.MembershipName,
                DiscountRate = preBillingInfo.DiscountPercent,
                TotalPrice = final,
                WorkshopPrice = preBillingInfo.WorkshopPrice,
            };
            return billingInfo;
        }

        public async Task PurchaseClass(int customerId, int workshopClassId)
        {
            //var customerRegistered = await _workshop.Customer.GetCustomerRegistrationInfo(customerId, workshopClassId);
            var billingInfo = await GetBillingInformation(customerId, workshopClassId);
            await _workshop.Customer.OnPurchaseClass(customerId, workshopClassId, billingInfo);
        }
        public async Task<IEnumerable<WorkshopClassViewModel>> GetWorkshopClassesByWorkshopId(int customerId, int workshopId)
        {
            var result = await _workshop.Customer.GetClassesByWorkshopId(customerId, workshopId);
            return result;
        }

        public async Task DoFeedback(int customerId, FeedbackWorkshopCustomerAddModel model)
        {
            //check if customer has register the class and done class
            var registered = await _workshop.Customer.GetRegisteredWorkshops(customerId);
            if(!registered.Any(e => e.Id == model.WorkshopId))
            {
                throw new InvalidOperationException("Customer has not registered to workshop class!");
            }
            var registered_classes = await _workshop.Customer.GetRegisteredWorkshopClass(customerId, model.WorkshopId);
            if(registered_classes != null && registered_classes.Count() > 0)
            {
                var classes = await _workshop.Staff.GetWorkshopClassAdminViewModels(model.WorkshopId);
                classes = classes.Where(e => registered_classes.Any(c => c.Id == e.Id));
                if(!classes.Any(e => e.Status == Models.Enum.Workshop.Class.Status.Completed)) {
                    throw new InvalidOperationException("This workshop class has not completed!");
                }
            }
            //do feedback
            await _workshop.Customer.DoFeedback(customerId, model);
        }

        public async Task<FeedbackWorkshopCustomerViewModel?> GetFeedback(int customerId, int workshopId)
        {
            return await _workshop.Customer.GetFeedback(customerId, workshopId);
        }
    }
}
