using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
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
        Task<IEnumerable<BirdTrainingProgressModel>> GetBirdTrainingProgressByTrainerId(int trainerId);
        Task MarkTrainingSkillDone(MarkSkillDone markDone);
        Task<TimetableReportView> GetTimetableReportView(int birdTrainingReportId);
    }
}
