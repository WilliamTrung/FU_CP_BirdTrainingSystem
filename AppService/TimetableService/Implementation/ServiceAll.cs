using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
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
        
        public async Task<IEnumerable<TrainerModel>> GetListTrainer(Models.Enum.Trainer.Category category)
        {
            return await _timetable.GetListTrainer((int)category);
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
    }
}
