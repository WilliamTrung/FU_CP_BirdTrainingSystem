using Models.ServiceModels;
using Models.ServiceModels.TimetableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppService.TimetableService
{
    public interface IServiceTrainer : IServiceAll
    {
        //Task<IEnumerable<TrainerSlotModel>> GetTrainerSlotDetail(int trainerId, DateTime from, DateTime to);
        Task<IEnumerable<TimetableModel>> GetTrainerTimetable(int trainerId, DateTime from, DateTime to);        
    }
}
