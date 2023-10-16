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

        public async Task<IEnumerable<WorkshopClassDetailViewModel>> GetAssignedWorkshopClassDetails(int trainerId, int workshopClassId)
        {
            var result = await _workshop.Trainer.GetAssignedWorkshopClassDetails(trainerId, workshopClassId);
            return result;
        }

        public async Task<IEnumerable<WorkshopClassAdminViewModel>> GetAssignedWorkshopClasses(int trainerId, int workshopId)
        {
            var result = await _workshop.Trainer.GetAssignedWorkshopClasses(trainerId, workshopId);
            return result;  
        }

        public async Task<IEnumerable<WorkshopModel>> GetAssignedWorkshops(int trainerId)
        {
            var result = await _workshop.Trainer.GetAssignedWorkshops(trainerId);
            return result;
        }

        public async Task ModifyWorkshopClassSlotDetail(int trainerId, WorkshopClassDetailModifyModel workshopClassDetail)
        {
            var current_slot = await _workshop.Staff.GetWorkshopClassDetail(workshopClassDetail.Id);
            if(current_slot == null)
            {
                throw new KeyNotFoundException($"{nameof(workshopClassDetail)} is not found at id: {workshopClassDetail.Id}");
            }
            if(current_slot.Trainer.Id != trainerId) {
                throw new InvalidOperationException("This trainer is not authorized to modify!");
            }
            await _workshop.Trainer.ModifyWorkshopClassSlotDetail(workshopClassDetail);
        }
    }
}
