using Models.ServiceModels.WorkshopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;
using WorkshopSubsystem;

namespace AppService.WorkshopService.Implementation
{
    public class ManagerService : StaffService, IServiceManager
    {
        public ManagerService(IWorkshopFeature workshop, ITimetableFeature timetable) : base(workshop, timetable)
        {
        }

        public Task CreateWorkshop(WorkshopAddModel workshop)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkshopStatusModel>> GetWorkshopStatuses()
        {
            throw new NotImplementedException();
        }

        public Task ModifyWorkshopStatus(WorkshopStatusModifyModel workshop)
        {
            throw new NotImplementedException();
        }
    }
}
