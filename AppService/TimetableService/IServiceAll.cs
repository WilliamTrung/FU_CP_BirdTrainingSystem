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
        Task<IEnumerable<TrainerModel>> GetListTrainer(Models.Enum.Trainer.Category category);
        Task<IEnumerable<SlotModel>> GetFreeSlotOnSelectedDateOfTrainer(DateTime date, int trainerId);
        Task<IEnumerable<TrainerModel>> GetListFreeTrainerOnSlotAndDate(DateOnly date, int slotId, Models.Enum.Trainer.Category category);
    }
}
