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

        public async Task CreateWorkshopClass(WorkshopClassAddModel workshopClass)
        {
            await _workshop.Staff.CreateWorkshopClass(workshopClass);
        }

        public async Task<IEnumerable<WorkshopClassAdminViewModel>> GetWorkshopClassAdminViewModels(int workshopId)
        {
            return await _workshop.Staff.GetWorkshopClassAdminViewModels(workshopId);
        }

        public async Task<IEnumerable<WorkshopClassDetailViewModel>> GetWorkshopClassDetailViewModels(int workshopClassId)
        {
            return await _workshop.Staff.GetWorkshopClassDetailViewModels(workshopClassId);
        }

        public async Task ModifyWorkshopClassDetailSlotOnly(WorkshopClassDetailTrainerSlotOnlyModifyModel workshopClassDetail)
        {
            //start validating
            var slots = await _timetable.GetSlotData();
            var changedSlot = slots.First(c => c.Id == workshopClassDetail.SlotId);
            var current_slot = await _workshop.Staff.GetWorkshopClassDetail(workshopClassDetail.Id);

            
            List<Task> validatedTasks = new List<Task>();
            //Modified date and modified slot must be free from current trainer timetable
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var trainerCheck = await _timetable.CheckTrainerFree(current_slot.Trainer.Id, workshopClassDetail.Date, workshopClassDetail.SlotId);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (!trainerCheck)
            {
                throw new InvalidOperationException("Trainer is not available for selected time!");
            }
            //Workshop class slot modification must be done 3 days before the execution day            
            Task compareExecutionDate = CompareCurrentDate(current_slot);
            validatedTasks.Add(compareExecutionDate);
            //changed date must be before the following slot
            var following_slot = await _workshop.Staff.GetFollowingWorkshopClassDetail(workshopClassDetail.Id);
            //if null --> there is no following slot left for the workshop
            //if null --> current slot is the last slot of the workshop
            if (following_slot != null)
            {                
                Task compareFollowingSlot = CompareFollowingSlotDetail(following_slot, workshopClassDetail.Date, changedSlot.StartTime);
                validatedTasks.Add(compareFollowingSlot);
            }            
            //changed date must be before the previous slot
            var previous_slot = await _workshop.Staff.GetPreviousWorkshopClassDetail(workshopClassDetail.Id);
            //if null --> there is no previous slot for the workshop
            //if null --> current slot is the first slot of the workshop
            if(previous_slot != null)
            {
                Task comparePreviousSlot = ComparePreviousSlotDetail(previous_slot, workshopClassDetail.Date, changedSlot.StartTime);
                validatedTasks.Add(comparePreviousSlot);
            }
            await Task.WhenAll(validatedTasks);
            //end validating
            await _workshop.Staff.ModifyWorkshopClassDetailSlotOnly(workshopClassDetail);
        }

        public async Task ModifyWorkshopClassDetailTrainerSlot(WorkshopClassDetailTrainerSlotModifyModel workshopClassDetail)
        {
            //start validating
            var slots = await _timetable.GetSlotData();
            var changedSlot = slots.First(c => c.Id == workshopClassDetail.SlotId);
            var current_slot = await _workshop.Staff.GetWorkshopClassDetail(workshopClassDetail.Id);


            List<Task> validatedTasks = new List<Task>();
            //Modified date and modified slot must be free from current trainer timetable
            var trainerCheck = await _timetable.CheckTrainerFree(workshopClassDetail.TrainerId, workshopClassDetail.Date, workshopClassDetail.SlotId);
            if (!trainerCheck)
            {
                throw new InvalidOperationException("Trainer is not available for selected time!");
            }
            //Workshop class slot modification must be done 3 days before the execution day            
            Task compareExecutionDate = CompareCurrentDate(current_slot);
            validatedTasks.Add(compareExecutionDate);
            //changed date must be before the following slot
            var following_slot = await _workshop.Staff.GetFollowingWorkshopClassDetail(workshopClassDetail.Id);
            //if null --> there is no following slot left for the workshop
            //if null --> current slot is the last slot of the workshop
            if (following_slot != null)
            {
                Task compareFollowingSlot = CompareFollowingSlotDetail(following_slot, workshopClassDetail.Date, changedSlot.StartTime);
                validatedTasks.Add(compareFollowingSlot);
            }
            //changed date must be before the previous slot
            var previous_slot = await _workshop.Staff.GetPreviousWorkshopClassDetail(workshopClassDetail.Id);
            //if null --> there is no previous slot for the workshop
            //if null --> current slot is the first slot of the workshop
            if (previous_slot != null)
            {
                Task comparePreviousSlot = ComparePreviousSlotDetail(previous_slot, workshopClassDetail.Date, changedSlot.StartTime);
                validatedTasks.Add(comparePreviousSlot);
            }
            await Task.WhenAll(validatedTasks);
            //end validating
            await _workshop.Staff.ModifyWorkshopClassDetailTrainerSlot(workshopClassDetail);
        }

        private Task CompareCurrentDate(WorkshopClassDetailViewModel slotDetail)
        {
            if (slotDetail.Date < DateTime.Now.AddDays(Models.ConfigModels.BR_WorkshopConstant.DeadlineDateModifySlotDetail).Date)
            {
                throw new InvalidOperationException("This slot will be hosted within 3 days from today!");
            }
            return Task.CompletedTask;
        }
        private Task ComparePreviousSlotDetail(WorkshopClassDetailViewModel previousSlotDetail, DateTime modifiedDate, TimeSpan modifiedSlotStartTime) { 
            if(previousSlotDetail.Date >  modifiedDate)
            {
                throw new InvalidOperationException("Modified date is sooner than previous slot detail!");
            }
            if(previousSlotDetail.Date == modifiedDate.Date && previousSlotDetail.StartTime >= modifiedSlotStartTime)
            {
                throw new InvalidOperationException("Modified slot is sooner than or equal to previous slot detail!");
            }
            return Task.CompletedTask;
        }
        private Task CompareFollowingSlotDetail(WorkshopClassDetailViewModel followingSlotDetail, DateTime modifiedDate, TimeSpan modifiedSlotStartTime)
        {
            if (followingSlotDetail.Date < modifiedDate)
            {
                throw new InvalidOperationException("Modified date is sooner than following slot detail!");
            }
            if (followingSlotDetail.Date == modifiedDate.Date && followingSlotDetail.StartTime <= modifiedSlotStartTime)
            {
                throw new InvalidOperationException("Modified slot is later than or equal to following slot detail!");
            }
            return Task.CompletedTask;
        }
    }
}
