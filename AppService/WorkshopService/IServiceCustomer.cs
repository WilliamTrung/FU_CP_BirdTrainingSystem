using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.Feedback;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.WorkshopService
{
    public interface IServiceCustomer : IServiceAll
    {
        Task Register(int customerId, int workshopClassId);
        Task<IEnumerable<WorkshopClassViewModel>> GetRegisteredClass(int customerId, int workshopId);
        Task<IEnumerable<WorkshopClassViewModel>> GetRegisteredClass(int customerId);
        Task<IEnumerable<WorkshopModel>> GetRegisteredWorkshopss(int customerId);
        Task<BillingModel> GetBillingInformation(int customerId, int workshopClassId);
        Task PurchaseClass(int customerId, int workshopClassId, string paymentCode);
        Task<IEnumerable<WorkshopClassViewModel>> GetWorkshopClassesByWorkshopId(int customerId, int workshopId);
        Task DoFeedback(int customerId, FeedbackWorkshopCustomerAddModel model);
        Task<FeedbackWorkshopCustomerViewModel?> GetFeedback(int customerId, int workshopId);
    }
}
