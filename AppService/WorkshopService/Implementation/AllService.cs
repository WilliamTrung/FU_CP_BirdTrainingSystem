using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.Feedback;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;
using WorkshopSubsystem;

namespace AppService.WorkshopService.Implementation
{
    public class AllService : IServiceAll
    {
        internal readonly IWorkshopFeature _workshop;
        internal readonly ITimetableFeature _timetable;
        public AllService(IWorkshopFeature workshop, ITimetableFeature timetable)
        {
            _timetable = timetable;
            _workshop = workshop;
        }
        public async Task<IEnumerable<WorkshopRefundPolicyModel>> GetRefundPolicies()
        {
            return await _workshop.All.GetRefundPolicies();
        }

        public async Task<WorkshopClassDetailViewModel> GetWorkshopClassDetailById(int workshopClassDetailId)
        {
            return await _workshop.All.GetWorkshopClassDetail(workshopClassDetailId);
        }

        public async Task<IEnumerable<WorkshopClassDetailViewModel>> GetWorkshopClassDetailByWorkshopClassId(int workshopClassId)
        {
            return await _workshop.All.GetWorkshopClassDetailOnWorkshopClass(workshopClassId);
        }

        public async Task<IEnumerable<WorkshopClassViewModel>> GetWorkshopClassesByWorkshopId(int workshopId)
        {
            return await _workshop.All.GetClassesByWorkshopId(workshopId);
        }

        public async Task<IEnumerable<WorkshopModel>> GetWorkshopsGeneralInformation()
        {
            return await _workshop.All.GetWorkshopGeneralInformation();
        }
        public async Task<RegistrationAmountModel> GetRegistrationAmount(int workshopClassId)
        {
            return await _workshop.All.GetRegistrationAmount(workshopClassId);
        }

        public async Task<WorkshopClassViewModel> GetWorkshopClass(int workshopClassId)
        {
            return await _workshop.All.GetWorkshopClass(workshopClassId);
        }

        public async Task<float> GetRating(int workshopId)
        {
            return await _workshop.All.GetRating(workshopId);
        }
        public async Task<List<FeedbackWorkshopCustomerViewModel>> GetFeedbacks(int workshopId)
        {
            return await _workshop.All.GetFeedbacks(workshopId);
        }
    }
}
