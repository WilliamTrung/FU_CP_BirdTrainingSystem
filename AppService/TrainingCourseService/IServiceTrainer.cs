﻿using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.TrainingCourseService
{
    public interface IServiceTrainer : IServiceAll
    {
        Task<IEnumerable<BirdTrainingProgressViewModel>> GetBirdTrainingProgressByTrainerId(int trainerId);
        Task MarkTrainingSkillDone(MarkSkillDone markDone);
        Task<int> MarkTrainingSlotDone(int birdTrainingReportId);
        Task<TimetableReportView> GetTimetableReportView(int trainerSlotId);
    }
}
