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
        public ServiceTrainer(ITrainingCourseFeature trainingCourse, ITimetableFeature timetable, IMailService mail) : base(trainingCourse, timetable, mail)
        {
        }

        public async Task<IEnumerable<BirdTrainingProgressViewModel>> GetBirdTrainingProgressByTrainerId(int trainerId)
        {
            return await _trainingCourse.Trainer.GetBirdTrainingProgressByTrainerId(trainerId);
        }

        public async Task<TimetableReportView> GetTimetableReportView(int trainerSlotId)
        {
            return await _trainingCourse.Trainer.GetTimetableReportView(trainerSlotId);
        }

        public async Task MarkTrainingSkillDone(MarkSkillDone markDone)
        {
            var course = await _trainingCourse.Trainer.MarkTrainingSkillDone(markDone);
            if (course != null)
            {
                if(course.Status == Models.Enum.BirdTrainingCourse.Status.TrainingDone)
                {
                    await SendNotiReceiveBirdFromCenter(course);
                }
            }
            else
            {
                throw new KeyNotFoundException("BirdTrainingCourse not found");
            }
        }

        public async Task<int> MarkTrainingSlotDone(int birdTrainingReportId)
        {
            var rs = await _trainingCourse.Trainer.MarkTrainingSlotDone(birdTrainingReportId);
            return rs;
        }
    }
}
