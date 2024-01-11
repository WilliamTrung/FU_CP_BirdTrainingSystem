using Microsoft.Win32;
using Models.Entities;
using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.Feedback;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem
{
    public interface IFeatureCustomer : IFeatureAll
    {

        //Register workshop class
        //param: 
        //"customerId : int
        //WorkshopClassId : int
        Task Register(int customerId, int workshopClassId);
        Task<IEnumerable<WorkshopClassViewModel>> GetClassesByWorkshopId(int customerId, int workshopId);
        Task<IEnumerable<WorkshopClassViewModel>> GetRegisteredWorkshopClass(int customerId, int workshopId);
        Task<IEnumerable<WorkshopClassViewModel>> GetRegisteredWorkshopClass(int customerId);
        Task<IEnumerable<WorkshopModel>> GetRegisteredWorkshops(int customerId);
        Task<CustomerWorkshopClass> OnPurchaseClass(int customerId, int workshopClassId, BillingModel billingModel);
        Task<CustomerWorkshopClass?> GetCustomerRegistrationInfo(int customerId, int workshopClassId);
        Task<PreBillingInformation> GetPreBillingInformation(int customerId, int workshopClassId);
        Task DoFeedback(int customerId, FeedbackWorkshopCustomerAddModel model);
        Task<FeedbackWorkshopCustomerViewModel?> GetFeedback(int customerId, int workshopId);
        Task<Models.Enum.Workshop.Class.Customer.Status?> CheckAttend(int customerId, int classSlotId);
        Task<Customer> GetCustomerById (int customerId);
    }
}
