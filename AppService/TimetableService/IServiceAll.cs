using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.TimetableService
{
    public interface IServiceAll
    {
        Task<IEnumerable<SlotModel>> GetSlots();    
        Task<TrainerSlotDetailModel> GetTrainerSlotDetail(int trainerSlotId);
    }
}
