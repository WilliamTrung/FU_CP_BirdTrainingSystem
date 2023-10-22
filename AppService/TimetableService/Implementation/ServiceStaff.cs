using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
using Models.ServiceModels.TimetableModels;
using SP_Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;

namespace AppService.TimetableService.Implementation
{
    public class ServiceStaff : ServiceAll, IServiceStaff
    {
        public ServiceStaff(ITimetableFeature timetable) : base(timetable)
        {
        }

        public async Task<IEnumerable<SlotModel>> GetFreeSlotOnSelectedDateOfTrainer(int trainerId, DateTime date)
        {
            var result = await _timetable.GetTrainerFreeSlotOnDate(date.ToDateOnly(), trainerId);
            return result;
        }

        public async Task<IEnumerable<TrainerModel>> GetFreeTrainerOnSelectedDate(DateTime date)
        {
            var result = await _timetable.GetTrainerFreeOnDate(date);
            return result;
        }

        public async Task<IEnumerable<TimetableModel>> GetTrainerSlotTimetableByTrainer(int trainerId, DateTime from, DateTime to)
        {
            var result = await _timetable.GetTrainerTimetable(from.ToDateOnly(), to.ToDateOnly(), trainerId);
            return result;
        }
    }
}
