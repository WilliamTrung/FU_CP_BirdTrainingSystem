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
    public class ServiceTrainer : ServiceAll, IServiceTrainer
    {
        public ServiceTrainer(ITimetableFeature timetable) : base(timetable)
        {
        }

        public async Task<IEnumerable<TrainerSlotModel>> GetTrainerSlotDetail(int trainerId, DateTime from, DateTime to)
        {
            var result = await _timetable.GetTrainerOccupiedSlots(from.ToDateOnly(), to.ToDateOnly(), trainerId);
            return result;
        }

        public async Task<IEnumerable<TimetableModel>> GetTrainerTimetable(int trainerId, DateTime from, DateTime to)
        {
            var result = await _timetable.GetTrainerTimetable(from.ToDateOnly(), to.ToDateOnly(), trainerId);
            return result;
        }
    }
}
