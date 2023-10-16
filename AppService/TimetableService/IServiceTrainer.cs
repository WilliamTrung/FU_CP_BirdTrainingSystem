using Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.TimetableService
{
    public interface IServiceTrainer : IServiceAll
    {
        Task<IEnumerable<TrainerSlotModel>> GetTrainerSlotDetail(DateTime from, DateTime to);
    }
}
