using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.CustomerRegister;
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

        public async Task<IEnumerable<RegisteredCustomerModel>> GetAttendeesInSlot(int trainerId, int classSlotId)
        {
            if(await _workshop.Trainer.CheckHostingClassSlot(trainerId, classSlotId))
            {
                return await _workshop.Staff.GetListRegistered(classSlotId);
            } else
            {
                throw new InvalidOperationException("This trainer is not authorized for this class slot!");
            }
        }

        public async Task<WorkshopClassDetailTrainerViewModel> GetTrainerSlotByEntityId(int? trainerId, int classSlotId)
        {
            if(trainerId != null)
            {
                var check = await _workshop.Trainer.CheckHostingClassSlot((int)trainerId, classSlotId);
                if (!check)
                {
                    throw new InvalidOperationException("This trainer is unauthorized for this slot!");
                }
            }            
            return await _workshop.Trainer.GetTrainerSlotByEntityId(classSlotId);
        }

        public async Task SubmitAttendance(int trainerId, int classSlotId, List<CheckAttendanceCredentials> customerCredentials)
        {
            if (await _workshop.Trainer.CheckHostingClassSlot(trainerId, classSlotId))
            {
                await _workshop.Staff.CheckAttendance(classSlotId, customerCredentials);
            }
            else
            {
                throw new InvalidOperationException("This trainer is not authorized for this class slot!");
            }
        }

        //public async Task ModifyWorkshopClassSlotDetail(int trainerId, WorkshopClassDetailModifyModel workshopClassDetail)
        //{
        //    var current_slot = await _workshop.Staff.GetWorkshopClassDetail(workshopClassDetail.Id);
        //    if(current_slot == null)
        //    {
        //        throw new KeyNotFoundException($"{nameof(workshopClassDetail)} is not found at id: {workshopClassDetail.Id}");
        //    }
        //    if(current_slot.Trainer.Id != trainerId) {
        //        throw new InvalidOperationException("This trainer is not authorized to modify!");
        //    }
        //    await _workshop.Trainer.ModifyWorkshopClassSlotDetail(workshopClassDetail);
        //}
    }
}
