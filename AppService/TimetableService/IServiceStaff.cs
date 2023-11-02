using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
using Models.ServiceModels.TimetableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.TimetableService
{
    public interface IServiceStaff : IServiceAll
    {
        Task<IEnumerable<TrainerModel>> GetFreeTrainerOnSelectedDate(DateTime date);
        Task<IEnumerable<TimetableModel>> GetTrainerSlotTimetableByTrainer(int trainerId, DateTime from, DateTime to);
    
    }
}
