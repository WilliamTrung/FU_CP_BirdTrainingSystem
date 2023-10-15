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
    public class TrainerService : AllService, IServiceTrainer
    {
        public TrainerService(IWorkshopFeature workshop, ITimetableFeature timetable) : base(workshop, timetable)
        {
        }

        public Task<IEnumerable<WorkshopClassDetailViewModel>> GetAssignedWorkshopClassDetails(int trainerId, int workshopClassId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkshopClassAdminViewModel>> GetAssignedWorkshopClasses(int trainerId, int workshopId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkshopModel>> GetAssignedWorkshops(int trainerId)
        {
            throw new NotImplementedException();
        }

        public Task ModifyWorkshopClassSlotDetail(WorkshopClassDetailModifyModel workshopClass)
        {
            throw new NotImplementedException();
        }
    }
}
