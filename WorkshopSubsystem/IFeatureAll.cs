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
    public interface IFeatureAll
    {        
        Task<IEnumerable<WorkshopModel>> GetWorkshopGeneralInformation();
        Task<bool> SetWorkshopClassFull(int workshopClassId);
        Task<RegistrationAmountModel> GetRegistrationAmount(int workshopClassId);
        Task SetClassCloseRegistrationOnFull(int workshopClassId);
        Task SetWorkshopClassOngoing();
        Task SetWorkshopClassComplete();
        Task SetWorkshopClassExceedRegistration();
        Task SetWorkshopClassOpenRegistration();
        Task<Models.Enum.Workshop.Class.Status> GetClassStatus(int workshopClassDetailId);
        Task<IEnumerable<WorkshopClassViewModel>> GetClassesByWorkshopId(int workshopId);
        Task<WorkshopClassDetailViewModel> GetWorkshopClassDetail(int workshopClassDetailId);
        Task<IEnumerable<WorkshopClassDetailViewModel>> GetWorkshopClassDetailOnWorkshopClass(int workshopClassId);
        Task<IEnumerable<WorkshopRefundPolicyModel>> GetRefundPolicies();
        Task<WorkshopClassViewModel> GetWorkshopClass(int workshopClassId);

        Task<List<FeedbackWorkshopCustomerViewModel>> GetFeedbacks(int workshopId);
        Task<float> GetRating(int workshopId);
    }
}
