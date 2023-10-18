﻿using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
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
        Task<IEnumerable<SlotModel>> GetFreeSlotOnSelectedDateOfTrainer(int trainerId, DateTime date);
        Task<IEnumerable<TrainerSlotModel>> GetTrainerSlotTimetableByTrainer(int trainerId, DateTime from, DateTime to);
    }
}
