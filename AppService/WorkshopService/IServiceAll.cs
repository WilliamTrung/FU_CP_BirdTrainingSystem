using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.Feedback;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using Models.ServiceModels.WorkshopModels.WorkshopRefundPolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.WorkshopService
{
    public interface IServiceAll
    {
        Task<IEnumerable<WorkshopModel>> GetWorkshopsGeneralInformation();
        Task<IEnumerable<WorkshopClassViewModel>> GetWorkshopClassesByWorkshopId(int workshopId);
        Task<IEnumerable<WorkshopClassDetailViewModel>> GetWorkshopClassDetailByWorkshopClassId(int workshopClassId);
        Task<WorkshopClassDetailViewModel> GetWorkshopClassDetailById(int workshopClassDetailId);
        Task<IEnumerable<WorkshopRefundPolicyViewModModel>> GetRefundPolicies();
        Task<RegistrationAmountModel> GetRegistrationAmount(int workshopClassId);
        Task<WorkshopClassViewModel> GetWorkshopClass(int workshopClassId);
        Task<float> GetRating(int workshopId);
        Task<List<FeedbackWorkshopCustomerViewModel>> GetFeedbacks(int workshopId);
    }
}