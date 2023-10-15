using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
using Models.ServiceModels.WorkshopModels;
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
        public async Task<IEnumerable<SlotModel>> GetSlotData()
        {
            var entities = await _unitOfWork.SlotRepository.Get();
            var models = _mapper.Map<List<SlotModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainerFreeOnDate(DateTime date)
        {
            var trainers = await _unitOfWork.TrainerRepository.Get(c => !c.TrainerSlots.Any(slot => CustomDateFunctions.IsEqualToDate(slot.Date,date)), nameof(Trainer.TrainerSlots));
            //var trainerSlots = await _unitOfWork.TrainerSlotRepository.Get(c => CustomDateFunctions.IsEqualToDate(c.Date, date));
            var trainerModels = _mapper.Map<List<TrainerModel>>(trainers);
            return trainerModels;
        }

        public async Task<IEnumerable<SlotModel>> GetTrainerFreeSlotOnDate(DateOnly date, int trainerId)
        {
            var trainerSlots = await _unitOfWork.TrainerSlotRepository.Get(c => CustomDateFunctions.IsEqualToDate(c.Date, date.ToDateTime(new TimeOnly(0,0,0))) && c.TrainerId == trainerId, nameof(TrainerSlot.Slot));
            var ocuppiedSlots = _mapper.Map<List<SlotModel>>(trainerSlots);
            var slots = await GetSlotData();
            var freeSlots = slots.Except(ocuppiedSlots);
            return freeSlots;
        }

        public async Task<IEnumerable<TrainerSlotModel>> GetTrainerOccupiedSlots(DateOnly from, DateOnly to, int trainerId)
        {
            var trainerSlots = await _unitOfWork.TrainerSlotRepository.Get(c => CustomDateFunctions.CompareDate(c.Date, from.ToDateTime(new TimeOnly(0, 0, 0))) >= 0 
                                                                             && CustomDateFunctions.CompareDate(c.Date, to.ToDateTime(new TimeOnly(0, 0, 0))) <= 0
                                                                             && c.TrainerId == trainerId, nameof(TrainerSlot.Slot));
            var slots = _mapper.Map<List<TrainerSlotModel>>(trainerSlots);
            return slots;
        }

        public async Task<TrainerSlotDetailModel> GetTrainerSlotDetail(int trainerSlotId)
        {
            var trainerSlot = await _unitOfWork.TrainerSlotRepository.GetFirst(c => c.Id == trainerSlotId, nameof(TrainerSlot.Slot));
            var model = _mapper.Map<TrainerSlotDetailModel>(trainerSlot);
            return model;
        }
    }
}
