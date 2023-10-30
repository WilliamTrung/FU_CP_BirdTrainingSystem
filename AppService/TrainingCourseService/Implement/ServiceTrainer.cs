using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;
using TrainingCourseSubsystem;

namespace AppService.TrainingCourseService.Implement
{
    public class ServiceTrainer : ServiceAll, IServiceTrainer
    {
        public ServiceTrainer(ITrainingCourseFeature trainingCourse, ITimetableFeature timetable) : base(trainingCourse, timetable)
        {
        }

        public async Task<IEnumerable<BirdTrainingProgressModel>> GetBirdTrainingProgressByTrainerId(int trainerId)
        {
            return await _trainingCourse.Trainer.GetBirdTrainingProgressByTrainerId(trainerId);
        }

        public async Task<TimetableReportView> GetTimetableReportView(int birdTrainingReportId)
        {
            return await _trainingCourse.Trainer.GetTimetableReportView(birdTrainingReportId);
        }

        public async Task MarkTrainingSkillDone(MarkSkillDone markDone)
        {
            await _trainingCourse.Trainer.MarkTrainingSkillDone(markDone);
        }
    }
}
