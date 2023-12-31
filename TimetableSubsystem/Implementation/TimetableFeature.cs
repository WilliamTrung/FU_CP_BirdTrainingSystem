﻿using AppRepository.Repository.Implement;
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

        public async Task<IEnumerable<TrainerModel>> GetListFreeTrainerOnSlotAndDate(DateOnly date, int slotId)
        {
            var trainerFreeOnSLotAndDate = new List<TrainerModel>();
            var freeTrainerOnDate = await _unitOfWork.TrainerRepository.Get(x => !(x.TrainerSlots.Count(slot => slot.Date.Day == date.Day
                                                                                            && slot.Date.Month == date.Month
                                                                                            && slot.Date.Year == date.Year
                                                                                            && slot.Status == (int)Models.Enum.TrainerSlotStatus.Enabled)
                                                                                            == 8) 
                                                                                            && x.Id != 0
                                                                                            && x.User.RoleId == (int)Models.Enum.Role.Trainer
                                                                     , nameof(Trainer.TrainerSlots)
                                                                     , nameof(Trainer.TrainerSkills)
                                                                     , nameof(Trainer.User));
            var trainerModels = _mapper.Map<List<TrainerModel>>(freeTrainerOnDate);

            if (trainerModels != null)
            {
                foreach (var freeTrainer in trainerModels)
                {
                    var trainerFreeSlot = await GetTrainerFreeSlotOnDate(date, freeTrainer.Id);
                    if (trainerFreeSlot != null)
                    {
                        foreach (var slot in trainerFreeSlot)
                        {
                            if (slot.Id == slotId)
                            {
                                trainerFreeOnSLotAndDate.Add(freeTrainer);
                            }
                        }
                    }
                }
            }

            return trainerFreeOnSLotAndDate;
        }

        public async Task<IEnumerable<TrainerModel>> GetListTrainer()
        {
            var entities = await _unitOfWork.TrainerRepository.Get(c => c.User.RoleId == (int)Models.Enum.Role.Trainer, nameof(Trainer.User));
            var models = new List<TrainerModel>();
            foreach (var entity in entities) 
            {
                var model = _mapper.Map<TrainerModel>(entity);
                models.Add(model);
            }
            return models;
        }

        public async Task<IEnumerable<TrainerModel>> GetListConsultantTrainer()
        {
            var entities = await _unitOfWork.TrainerRepository.Get(x => x.ConsultantAble == true && x.User.RoleId == (int)Models.Enum.Role.Trainer, nameof(Trainer.User));
            var models = new List<TrainerModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<TrainerModel>(entity);
                models.Add(model);
            }
            return models;
        }

        public async Task<SlotModel> GetSlotBySlotId(int slotId)
        {
            var entity = await _unitOfWork.SlotRepository.GetFirst(x => x.Id == slotId);
            var model = _mapper.Map<SlotModel>(entity);
            return model;
        }

        public async Task<IEnumerable<SlotModel>> GetSlotData()
        {
            var entities = await _unitOfWork.SlotRepository.Get();
            var models = _mapper.Map<List<SlotModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainerFreeOnDate(DateTime date)
        {
            var trainers = await _unitOfWork.TrainerRepository.Get(c => !(c.TrainerSlots.Count(slot => slot.Date.Day == date.Day
                                                                                            && slot.Date.Month == date.Month
                                                                                            && slot.Date.Year == date.Year
                                                                                            && slot.Status == (int)Models.Enum.TrainerSlotStatus.Enabled)
                                                                                            == 8)
                                                                        && c.User.RoleId == (int)Models.Enum.Role.Trainer
                                                                     , nameof(Trainer.TrainerSlots)
                                                                     , nameof(Trainer.TrainerSkills)
                                                                     , nameof(Trainer.User));
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
            //var occuppiedSlots = _mapper.Map<List<SlotModel>>(trainerSlots);
            var slots = await GetSlotData();
            var freeSlots = slots.Where(c => !trainerSlots.Any(e => e.SlotId == c.Id));
            return freeSlots;
        }

        public async Task<IEnumerable<TrainerSlotModel>> GetTrainerOccupiedSlots(DateOnly from, DateOnly to, int trainerId)
        {
            var trainerSlots = await _unitOfWork.TrainerSlotRepository.Get(c => c.TrainerId == trainerId
                                                                            && c.Trainer.User.RoleId == (int)Models.Enum.Role.Trainer
                                                                             && c.Status != (int)Models.Enum.TrainerSlotStatus.Disabled
                                                                             , nameof(TrainerSlot.Slot)
                                                                             , nameof(TrainerSlot.Trainer)
                                                                             , $"{nameof(TrainerSlot.Trainer)}.{nameof(Trainer.User)}");
            trainerSlots = trainerSlots.Where(c => c.Date.Day >= from.Day
                                                && c.Date.Month >= from.Month
                                                && c.Date.Year >= from.Year
                                                && c.Date.Day <= to.Day
                                                && c.Date.Month <= to.Month
                                                && c.Date.Year <= to.Year);
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
            var trainerSlots = await _unitOfWork.TrainerSlotRepository.Get(c => c.TrainerId == trainerId
                                                                             && c.Status != (int)Models.Enum.TrainerSlotStatus.Disabled
                                                                             //&& c.Date.Day >= from.Day
                                                                             //&& c.Date.Month >= from.Month
                                                                             //&& c.Date.Year >= from.Year
                                                                             //&& c.Date.Day <= to.Day
                                                                             //&& c.Date.Month <= to.Month
                                                                             //&& c.Date.Year <= to.Year
                                                                            , nameof(TrainerSlot.Slot));
            //var tesst = _mapper.Map<TimetableModel>(trainerSlots.First());
            var slots = _mapper.Map<List<TimetableModel>>(trainerSlots);
            return slots;
        }

        public async Task<IEnumerable<SlotModel>> GetAvailableFinishTime(string actualSlotStart)
        {
            string[] parts = actualSlotStart.Split('-');
            string endTimeString = parts[1].Trim();
            TimeSpan endTime = TimeSpan.Parse(endTimeString);

            var entities = await _unitOfWork.SlotRepository.Get(x => x.EndTime >= endTime);
            var models = _mapper.Map<IEnumerable<SlotModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<SlotModel>> GetSlotRangeForConsultant(string actualSlotStart, int actualEndSlot)
        {
            var endSlot = await _unitOfWork.SlotRepository.GetFirst(x => x.Id == actualEndSlot);
            string[] startParts = actualSlotStart.Split('-');

            string startString = startParts[1].Trim();

            TimeSpan start = TimeSpan.Parse(startString);

            var entities = await _unitOfWork.SlotRepository.Get(x => x.EndTime >= start && x.EndTime <= endSlot.EndTime);
            var models = _mapper.Map<IEnumerable<SlotModel>>(entities);
            return models;
        }

        public async Task UpdateSlot(int minute)
        {
            var entities = await _unitOfWork.SlotRepository.Get();
            if (minute > 60 || minute < 30)
            {
                throw new Exception("Duration each slot must be long 30 ~ 60 minute");
            }
            foreach (var entity in entities)
            {
                TimeSpan startTime = (TimeSpan)entity.StartTime;
                entity.EndTime = startTime.Add(TimeSpan.FromMinutes(minute));
                await _unitOfWork.SlotRepository.Update(entity);
            }
        }
    }
}
