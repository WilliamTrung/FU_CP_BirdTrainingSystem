using ApplicationService.MailSettings;
using Google.Api.Gax;
using Models.Entities;
using Models.ServiceModels;
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
        private readonly IMailService _mailService;
        public CustomerService(IWorkshopFeature workshop, ITimetableFeature timetable, IFeatureTransaction transaction, IMailService mailService) : base(workshop, timetable)
        {
            _transaction = transaction;
            _mailService = mailService;
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
                WorkshopClassId = workshopClassId,
                DiscountedPrice = discounted,
                MembershipName = preBillingInfo.MembershipName,
                DiscountRate = preBillingInfo.DiscountPercent,
                TotalPrice = final,
                WorkshopPrice = preBillingInfo.WorkshopPrice,
                WorkshopTitle = preBillingInfo.WorkshopTitle
            };
            return billingInfo;
        }

        public async Task PurchaseClass(int customerId, int workshopClassId, string paymentCode)
        {
            string customerEmail = string.Empty;
            MailContent mailContent = new MailContent();
            try
            {
                //var customerRegistered = await _workshop.Customer.GetCustomerRegistrationInfo(customerId, workshopClassId);
                if (await _workshop.All.SetWorkshopClassFull(workshopClassId))
                {
                    throw new InvalidOperationException("This workshop class is full!");
                }
                var billingInfo = await GetBillingInformation(customerId, workshopClassId);
                var customerRegistered = await _workshop.Customer.OnPurchaseClass(customerId, workshopClassId, billingInfo);
                customerEmail = customerRegistered.Customer.User.Email;
                //add transaction information
                string formattedDateTime = DateTime.UtcNow.AddHours(7).ToString("ddMMMyyyyhhmm");
                var transactionAddModel = new TransactionAddModel()
                {
                    CustomerId = customerId,
                    EntityId = workshopClassId,
                    EntityTypeId = (int)Models.Enum.EntityType.WorkshopClass,
                    PaymentCode = paymentCode,
                    Detail = $"{paymentCode}:{customerRegistered.CustomerId}:{customerRegistered.Customer.User.Email}-buy workshop class {customerRegistered.WorkshopClassId}:{customerRegistered.WorkshopClass.Workshop.Title}-at:{formattedDateTime}",
                    Status = (int)Models.Enum.Transaction.Status.Paid,
                    Title = "Workshop class enrolled",
                    TotalPayment = billingInfo.TotalPrice,
                };
                Transaction transaction = await _transaction.AddTransaction(transactionAddModel);
                mailContent.Subject = "Payment information for workshop purchasing";
                mailContent.HtmlMessage = $"<h3>You have purchased for workshop: </h3><p>{customerRegistered.WorkshopClass.Workshop.Title}</p><br/>" +
                        $"<h3>Your payment code: </h3>{transaction.PaymentCode.Split("_secret")[0]}<br/>" +
                        $"<h3>Original cost: </h3>{billingInfo.WorkshopPrice} VND<br/>" +
                        $"<h3>Discounted: </h3>{billingInfo.DiscountedPrice} VND<br/>" +
                        $"<h3>Actual Cost: </h3>{transaction.TotalPayment} VND<br/>" +
                        $"<h3>At {transaction.PaymentDate}</h3><br/><h2>Please save this information for service convenience!</h2>";
                await _workshop.Staff.GenerateWorkshopAttendance(customerId, workshopClassId);
            } catch (Exception ex)
            {
                var customer = await _workshop.Customer.GetCustomerById(customerId);
                mailContent.Subject = "Payment error for workshop purchasing";
                mailContent.HtmlMessage = $"<h3>You have encountered an error on purchasing workshop</h3>" +
                        $"<h3>Your payment code: </h3>{paymentCode.Split("_secret")[0]}<br/>" +
                        $"<h3>Content: </h3>{ex.Message}<br/>" +
                        $"<h3>Contact to our hotline for a refund!</h3><br/><h2>Please save this information for service convenience!</h2>";
                customerEmail = customer.User.Email;
                throw;
            } finally
            {
                await _mailService.SendEmailAsync(customerEmail, mailContent);
            }
        }
        public async Task<IEnumerable<WorkshopClassViewModel>> GetWorkshopClassesByWorkshopId(int customerId, int workshopId)
        {
            var result = await _workshop.Customer.GetClassesByWorkshopId(customerId, workshopId);
            foreach (var workshopClass in result)
            {
                foreach (var classSlot in workshopClass.ClassSlots)
                {
                    classSlot.Status = await _workshop.Customer.CheckAttend(customerId, classSlot.Id);
                }
            }
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

        public async Task<IEnumerable<WorkshopClassViewModel>> GetRegisteredClass(int customerId)
        {
            var result = await _workshop.Customer.GetRegisteredWorkshopClass(customerId);
            var sorted = new List<WorkshopClassViewModel>();
            var groupOngoing = result.Where(c => c.ClassStatus == Models.Enum.Workshop.Class.Status.OnGoing);
            sorted.AddRange(groupOngoing);
            var groupClosed = result.Where(c => c.ClassStatus == Models.Enum.Workshop.Class.Status.ClosedRegistration);
            sorted.AddRange(groupClosed);
            var groupOpen = result.Where(c => c.ClassStatus == Models.Enum.Workshop.Class.Status.OpenRegistration);
            sorted.AddRange(groupOpen);
            var groupComplete = result.Where(c => c.ClassStatus == Models.Enum.Workshop.Class.Status.Completed);
            sorted.AddRange(groupComplete);
            var groupCancel = result.Where(c => c.ClassStatus == Models.Enum.Workshop.Class.Status.Cancelled);
            sorted.AddRange(groupCancel);
            return sorted;
        }
    }
}
