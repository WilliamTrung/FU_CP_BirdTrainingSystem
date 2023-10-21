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

        public async Task CreateWorkshop(WorkshopAddModel workshop)
        {
            await _workshop.Manager.CreateWorkshop(workshop);
        }

        public async Task<IEnumerable<WorkshopStatusModel>> GetWorkshopStatuses()
        {
            return await _workshop.Manager.GetWorkshopStatuses();
        }

        public async Task ModifyWorkshopDetailTemplate(WorkshopDetailTemplateModiyModel workshopDetail)
        {
            await _workshop.Manager.ModifyWorkshopDetailTemplate(workshopDetail);
        }

        public async Task ModifyWorkshopStatus(WorkshopStatusModifyModel workshop)
        {
            await _workshop.Manager.ModifyWorkshopStatus(workshop);
        }
    }
}
