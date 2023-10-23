using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
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
    public class ServiceStaff : ServiceAll, IServiceStaff
    {
        public ServiceStaff(ITrainingCourseFeature trainingCourse, ITimetableFeature timetable) : base(trainingCourse, timetable)
        {
        }

        public async Task<IEnumerable<BirdTrainingCourseModel>> GetBirdTrainingCourse()
        {
            return await _trainingCourse.Staff.GetBirdTrainingCourse();
        }

        public async Task<IEnumerable<TrainingCourseSkillModel>> GetTrainingCourseSkill(int trainingCourseId)
        {
            return await _trainingCourse.Staff.GetTrainingCourseSkill(trainingCourseId);
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainerByBirdSkillId(int birdSkillId)
        {
            return await _trainingCourse.Staff.GetTrainerByBirdSkillId(birdSkillId);
        }

        public async Task AssignTrainer(AssignTrainerToCourse assignTrainer)
        {
            await _trainingCourse.Staff.AssignTrainer(assignTrainer);
        }

        public async Task InitStartTime(BirdTrainingCourseStartTime birdTrainingCourse)
        {
            await _trainingCourse.Staff.InitStartTime(birdTrainingCourse);
        }

        public async Task ReceiveBird(BirdTrainingCourseReceiveBird birdTrainingCourse)
        {
            await _trainingCourse.Staff.ReceiveBird(birdTrainingCourse);
        }

        public async Task ReturnBird(BirdTrainingCourseReturnBird birdTrainingCourse)
        {
            await _trainingCourse.Staff.ReturnBird(birdTrainingCourse);
        }

        public async Task<IEnumerable<BirdTrainingCourseModel>> GetBirdTrainingCourseByBirdId(int birdId)
        {
            return await _trainingCourse.Staff.GetBirdTrainingCourseByBirdId(birdId);
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainer()
        {
            return await _trainingCourse.Staff.GetTrainer();
        }

        public async Task<TrainerModel> GetTrainerById(int trainerId)
        {
            return await _trainingCourse.Staff.GetTrainerById(trainerId);
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainerByTrainerSkillId(int trainerSkillId)
        {
            return await _trainingCourse.Staff.GetTrainerByTrainerSkillId(trainerSkillId);
        }

        public async Task GenerateTrainerTimetable(InitReportTrainerSlot report)
        {
            await _trainingCourse.Staff.GenerateTrainerTimetable(report);
        }
    }
}
