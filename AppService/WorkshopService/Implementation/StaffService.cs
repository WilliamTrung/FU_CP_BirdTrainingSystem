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
    public class StaffService : AllService, IServiceStaff
    {
        public StaffService(IWorkshopFeature workshop, ITimetableFeature timetable) : base(workshop, timetable)
        {
        }

        public Task CreateWorkshopClass(WorkshopClassAddModel workshopClass)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkshopClassAdminViewModel>> GetWorkshopClassAdminViewModels(int workshopId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkshopClassDetailViewModel>> GetWorkshopClassDetailViewModels(int workshopClassId)
        {
            throw new NotImplementedException();
        }

        public Task ModifyWorkshopClassDetailSlotOnly(WorkshopClassDetailTrainerSlotOnlyModifyModel workshopClass)
        {
            throw new NotImplementedException();
        }

        public Task ModifyWorkshopClassDetailTrainerSlot(WorkshopClassDetailTrainerSlotModifyModel workshopClass)
        {
            throw new NotImplementedException();
        }
    }
}
