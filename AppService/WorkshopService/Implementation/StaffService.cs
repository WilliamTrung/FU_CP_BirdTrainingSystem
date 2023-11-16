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
            //check duplicate trainer to this slot
            if (current_slot.StartTime == slots.First(s => s.Id == workshopClassDetail.SlotId).StartTime
                && current_slot.Date == workshopClassDetail.Date.ToDateTime(new TimeOnly()))
            {
                throw new InvalidOperationException("No change detected!");
            }
            List<Task> validatedTasks = new List<Task>();
            //Modified date and modified slot must be free from current trainer timetable
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var trainerCheck = await _timetable.CheckTrainerFree(current_slot.Trainer.Id, workshopClassDetail.Date.ToDateTime(new TimeOnly(0, 0, 0)), workshopClassDetail.SlotId);
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
                Task compareFollowingSlot = CompareFollowingSlotDetail(following_slot, workshopClassDetail.Date.ToDateTime(new TimeOnly(0, 0, 0)), changedSlot.StartTime.Value);
                validatedTasks.Add(compareFollowingSlot);
            }            
            //changed date must be before the previous slot
            var previous_slot = await _workshop.Staff.GetPreviousWorkshopClassDetail(workshopClassDetail.Id);
            //if null --> there is no previous slot for the workshop
            //if null --> current slot is the first slot of the workshop
            if(previous_slot != null)
            {
                Task comparePreviousSlot = ComparePreviousSlotDetail(previous_slot, workshopClassDetail.Date.ToDateTime(new TimeOnly(0, 0, 0)), changedSlot.StartTime.Value);
                validatedTasks.Add(comparePreviousSlot);
            }
            await Task.WhenAll(validatedTasks);
            //end validating
            await _workshop.Staff.ModifyWorkshopClassDetailSlotOnly(workshopClassDetail);

            var checkSlot = await _workshop.Staff.CheckSlotFulfill(current_slot.Id);
            if (checkSlot)
            {
                await _workshop.Staff.SetOpenRegistrationForClass(current_slot.Id);
            }
        }

        public async Task ModifyWorkshopClassDetailTrainerSlot(WorkshopClassDetailTrainerSlotModifyModel workshopClassDetail)
        {
            
            if(!await _workshop.Staff.CheckPassEndRegistrationDay(workshopClassDetail.Id, workshopClassDetail.Date))
            {
                throw new InvalidOperationException("Assigned slot must start after registration end date!");
            }
            //start validating
            var slots = await _timetable.GetSlotData();
            var changedSlot = slots.First(c => c.Id == workshopClassDetail.SlotId);
            var current_slot = await _workshop.Staff.GetWorkshopClassDetail(workshopClassDetail.Id);
            //check duplicate trainer to this slot
            if(current_slot.StartTime == slots.First(s => s.Id == workshopClassDetail.SlotId).StartTime
                && current_slot.Trainer.Id == workshopClassDetail.TrainerId
                && current_slot.Date == workshopClassDetail.Date.ToDateTime(new TimeOnly()))   
            {
                throw new InvalidOperationException("No change detected!");
            }
            List<Task> validatedTasks = new List<Task>();
            //Modified date and modified slot must be free from current trainer timetable
            var trainerCheck = await _timetable.CheckTrainerFree(workshopClassDetail.TrainerId, workshopClassDetail.Date.ToDateTime(new TimeOnly(0, 0, 0)), workshopClassDetail.SlotId);
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
                Task compareFollowingSlot = CompareFollowingSlotDetail(following_slot, workshopClassDetail.Date.ToDateTime(new TimeOnly(0, 0, 0)), changedSlot.StartTime.Value);
                validatedTasks.Add(compareFollowingSlot);
            }
            //changed date must be before the previous slot
            var previous_slot = await _workshop.Staff.GetPreviousWorkshopClassDetail(workshopClassDetail.Id);
            //if null --> there is no previous slot for the workshop
            //if null --> current slot is the first slot of the workshop
            if (previous_slot != null)
            {
                Task comparePreviousSlot = ComparePreviousSlotDetail(previous_slot, workshopClassDetail.Date.ToDateTime(new TimeOnly(0, 0, 0)), changedSlot.StartTime.Value);
                validatedTasks.Add(comparePreviousSlot);
            }
            await Task.WhenAll(validatedTasks);
            //end validating
            await _workshop.Staff.ModifyWorkshopClassDetailTrainerSlot(workshopClassDetail);

            var checkSlot = await _workshop.Staff.CheckSlotFulfill(current_slot.Id);
            if (checkSlot)
            {
                await _workshop.Staff.SetOpenRegistrationForClass(current_slot.Id);
            }
        }

        private Task CompareCurrentDate(WorkshopClassDetailViewModel slotDetail)
        {
            if (slotDetail.Date == null)
            {
                //not yet assigned
                return Task.CompletedTask;
            }
            if (slotDetail.Date < DateTime.Now.AddDays(Models.ConfigModels.BR_WorkshopConstant.DeadlineDateModifySlotDetail).Date)
            {
                throw new InvalidOperationException("This slot will be hosted within 3 days from today!");
            }
            return Task.CompletedTask;
        }
        private Task ComparePreviousSlotDetail(WorkshopClassDetailViewModel previousSlotDetail, DateTime modifiedDate, TimeSpan modifiedSlotStartTime) { 
            if(previousSlotDetail.Date == null) {
                //not yet assigned
                return Task.CompletedTask;
            }
            if (previousSlotDetail.Date >  modifiedDate)
            {
                throw new InvalidOperationException("Modified date is sooner than previous slot detail!");
            }
            if(previousSlotDetail.Date == modifiedDate.Date && previousSlotDetail.StartTime >= modifiedSlotStartTime)
            {
                throw new InvalidOperationException("Modified slot is sooner than previous slot detail!");
            }
            return Task.CompletedTask;
        }
        private Task CompareFollowingSlotDetail(WorkshopClassDetailViewModel followingSlotDetail, DateTime modifiedDate, TimeSpan modifiedSlotStartTime)
        {
            if (followingSlotDetail.Date == null)
            {
                //not yet assigned
                return Task.CompletedTask;
            }
            if (followingSlotDetail.Date < modifiedDate)
            {
                throw new InvalidOperationException("Modified date is later than following slot detail!");
            }
            if (followingSlotDetail.Date == modifiedDate.Date && followingSlotDetail.StartTime <= modifiedSlotStartTime)
            {
                throw new InvalidOperationException("Modified slot is later than following slot detail!");
            }
            return Task.CompletedTask;
        }
        public async Task CancelWorkshopClass(int workshopClassId)
        {
            await _workshop.Staff.CancelWorkshopClass(workshopClassId);
        }
        public async Task CompleteWorkshopClass(int workshopClassId)
        {
            await _workshop.Staff.CompleteWorkshopClass(workshopClassId);
        }
        public async Task<IEnumerable<RegisteredCustomerModel>> GetAttendeesInSlot(int classSlotId)
        {
            var result = await _workshop.Staff.GetListRegistered(classSlotId);
            return result;
        }
        public async Task SubmitAttendance(int classSlotId, List<CheckAttendanceCredentials> customerCredentials)
        {
            await _workshop.Staff.CheckAttendance(classSlotId, customerCredentials);
        }

        public async Task<WorkshopClassAdminViewModel> GetClassAdminViewById(int classId)
        {
            var result = await _workshop.Staff.GetClassAdminViewById(classId);
            return result;
        }

        public async Task SetWorkshopClassOngoing(int workshopClassId)
        {
            await _workshop.Staff.SetClassOngoing(workshopClassId);
        }

        public async Task CloseRegistrationWorkshopClass(int workshopClassId)
        {
            await _workshop.Staff.SetClosedRegistrationForClass(workshopClassId);
        }
    }
}
