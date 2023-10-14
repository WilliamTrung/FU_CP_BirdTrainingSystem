using Models.ServiceModels.WorkshopModels;
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
        public Task<WorkshopRefundPolicyModel> GetRefundPolicy()
        {
            throw new NotImplementedException();
        }

        public Task<WorkshopClassDetailViewModel> GetWorkshopClassDetailById(int workshopClassDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkshopClassDetailViewModel>> GetWorkshopClassDetailByWorkshopClassId(int workshopClassId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkshopClassViewModel>> GetWorkshopClassesByWorkshopId(int workshopId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkshopModel>> GetWorkshopsGeneralInformation()
        {
            throw new NotImplementedException();
        }
    }
}
