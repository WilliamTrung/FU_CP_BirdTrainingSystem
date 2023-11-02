using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
using Models.ServiceModels.TimetableModels;
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
        Task<bool> CheckTrainerFree(int trainerId, DateTime date, int slotId);
        Task<IEnumerable<TimetableModel>> GetTrainerTimetable(DateOnly from, DateOnly to, int trainerId);
        Task<IEnumerable<TrainerModel>> GetListTrainer(int category);
    }
}