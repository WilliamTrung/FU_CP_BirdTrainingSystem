using Models.Enum.Trainer;
using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
using SP_Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;

namespace AppService.TimetableService.Implementation
{
    public class ServiceAll : IServiceAll
    {
        internal readonly ITimetableFeature _timetable;
        public ServiceAll(ITimetableFeature timetable)
        {
            _timetable = timetable;
        }
        
        public async Task<IEnumerable<TrainerModel>> GetListTrainer()
        {
            return await _timetable.GetListTrainer();
        }

        public async Task<IEnumerable<SlotModel>> GetSlots()
        {
            return await _timetable.GetSlotData();
        }

        public async Task<TrainerSlotDetailModel> GetTrainerSlotDetail(int trainerSlotId)
        {
            var result = await _timetable.GetTrainerSlotDetail(trainerSlotId);
            return result;
        }
        public async Task<IEnumerable<SlotModel>> GetFreeSlotOnSelectedDateOfTrainer(DateTime date, int trainerId)
        {
            var result = await _timetable.GetTrainerFreeSlotOnDate(date.ToDateOnly(), trainerId);
            return result;
        }

        public async Task<IEnumerable<TrainerModel>> GetListFreeTrainerOnSlotAndDate(DateOnly date, int slotId)
        {
            var result = await _timetable.GetListFreeTrainerOnSlotAndDate(date, slotId);
            return result;
        }
    }
}
