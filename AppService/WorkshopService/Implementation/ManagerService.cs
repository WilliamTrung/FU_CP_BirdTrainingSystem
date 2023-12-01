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

        public async Task<int> CreateWorkshop(WorkshopAddModel workshop)
        {
            return await _workshop.Manager.CreateWorkshop(workshop);
        }

        public async Task<IEnumerable<WorkshopAdminModel>> GetAllWorkshops()
        {
            return await _workshop.Manager.GetWorkshops();
        }

        public async Task<IEnumerable<WorkshopDetailTemplateViewModel>> GetDetailTemplatesByWorkshopId(int workshopId)
        {
            return await _workshop.Manager.GetDetailTemplatesByWorkshopId(workshopId);
        }

        public async Task<IEnumerable<WorkshopStatusModel>> GetWorkshopStatuses()
        {
            return await _workshop.Manager.GetWorkshopStatuses();
        }

        public async Task ModifyWorkshop(WorkshopModifyModel workshop)
        {
            await _workshop.Manager.ModifyWorkshop(workshop);
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
