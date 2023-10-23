using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
using Models.ServiceModels.TimetableModels;
using SP_Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableSubsystem.Implementation
{
    public class TimetableFeature : ITimetableFeature
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TimetableFeature(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CheckTrainerFree(int trainerId, DateTime date, int slotId)
        {
            var freeTrainers = await this.GetTrainerFreeOnDate(date);
            if (freeTrainers == null || !freeTrainers.Any())
            {
                return false;
            }
            if(!freeTrainers.Any(c => c.Id == trainerId)) { 
                return false;
            }
            DateOnly dateOnly = new DateOnly(date.Year, date.Month, date.Day);
            var freeSlots = await this.GetTrainerFreeSlotOnDate(dateOnly, trainerId);
            if(freeSlots == null || !freeSlots.Any())
            {
                return false;
            }
            if (!freeSlots.Any(c => c.Id == slotId))
            {
                return false;
            }            
            return true;
        }

        public async Task<IEnumerable<SlotModel>> GetSlotData()
        {
            var entities = await _unitOfWork.SlotRepository.Get();
            var models = _mapper.Map<List<SlotModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainerFreeOnDate(DateTime date)
        {
            var trainers = await _unitOfWork.TrainerRepository.Get(c => !c.TrainerSlots.Any(slot => slot.Date.Day == date.Day
                                                                                            && slot.Date.Month == date.Month
                                                                                            && slot.Date.Year == date.Year)
                                                                     , nameof(Trainer.TrainerSlots));
            //var trainerSlots = await _unitOfWork.TrainerSlotRepository.Get(c => CustomDateFunctions.IsEqualToDate(c.Date, date));
            var trainerModels = _mapper.Map<List<TrainerModel>>(trainers);
            return trainerModels;
        }

        public async Task<IEnumerable<SlotModel>> GetTrainerFreeSlotOnDate(DateOnly date, int trainerId)
        {
            var trainerSlots = await _unitOfWork.TrainerSlotRepository.Get(c => c.Date.Day == date.Day
                                                                                && c.Date.Month == date.Month
                                                                                && c.Date.Year == date.Year
                                                                             && c.TrainerId == trainerId
                                                                             && c.Status != (int)Models.Enum.TrainerSlotStatus.Disabled
                                                                             , nameof(TrainerSlot.Slot));            
            var occuppiedSlots = _mapper.Map<List<SlotModel>>(trainerSlots);
            var slots = await GetSlotData();
            var freeSlots = slots.Where(c => !occuppiedSlots.Any(e => e.Id == c.Id));
            return freeSlots;
        }

        public async Task<IEnumerable<TrainerSlotModel>> GetTrainerOccupiedSlots(DateOnly from, DateOnly to, int trainerId)
        {
            var trainerSlots = await _unitOfWork.TrainerSlotRepository.Get(c => CustomDateFunctions.CompareDate(c.Date, from.ToDateTime(new TimeOnly(0, 0, 0))) >= 0 
                                                                             && CustomDateFunctions.CompareDate(c.Date, to.ToDateTime(new TimeOnly(0, 0, 0))) <= 0
                                                                             && c.TrainerId == trainerId
                                                                             && c.Status != (int)Models.Enum.TrainerSlotStatus.Disabled
                                                                             , nameof(TrainerSlot.Slot));
            var slots = _mapper.Map<List<TrainerSlotModel>>(trainerSlots);
            return slots;
        }

        public async Task<TrainerSlotDetailModel> GetTrainerSlotDetail(int trainerSlotId)
        {
            var trainerSlot = await _unitOfWork.TrainerSlotRepository.GetFirst(c => c.Id == trainerSlotId 
                                                                                 && c.Status != (int) Models.Enum.TrainerSlotStatus.Disabled
                                                                                 , nameof(TrainerSlot.Slot));
            var model = _mapper.Map<TrainerSlotDetailModel>(trainerSlot);
            return model;
        }

        public async Task<IEnumerable<TimetableModel>> GetTrainerTimetable(DateOnly from, DateOnly to, int trainerId)
        {
            var trainerSlots = await _unitOfWork.TrainerSlotRepository.Get(c => CustomDateFunctions.CompareDate(c.Date, from.ToDateTime(new TimeOnly(0, 0, 0))) >= 0
                                                                             && CustomDateFunctions.CompareDate(c.Date, to.ToDateTime(new TimeOnly(0, 0, 0))) <= 0
                                                                             && c.TrainerId == trainerId
                                                                             && c.Status != (int)Models.Enum.TrainerSlotStatus.Disabled);
            var slots = _mapper.Map<List<TimetableModel>>(trainerSlots);
            return slots;
        }
    }
}
