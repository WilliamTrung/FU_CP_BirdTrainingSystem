using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableSubsystem
{

    public interface ITimetableFeature
    {
        Task<IEnumerable<SlotModel>> GetSlotData();
        Task<IEnumerable<TrainerModel>> GetTrainerFreeOnDate(DateTime date);
        Task<IEnumerable<SlotModel>> GetTrainerFreeSlotOnDate(DateOnly date, int trainerId);
        Task<IEnumerable<TrainerSlotModel>> GetTrainerOccupiedSlots(DateOnly from, DateOnly to, int trainerId);
        Task<TrainerSlotDetailModel> GetTrainerSlotDetail(int trainerSlotId); 
    }
}