using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;
using TrainingCourseSubsystem;

namespace AppService.TrainingCourseService.Implement
{
    public class ServiceCustomer : ServiceAll, IServiceCustomer
    {
        public ServiceCustomer(ITrainingCourseFeature trainingCourse, ITimetableFeature timetable) : base(trainingCourse, timetable)
        {
        }

        public async Task<IEnumerable<BirdViewModel>> GetBirdByCustomerId(int customerId)
        {
            return await _trainingCourse.Customer.GetBirdByCustomerId(customerId);
        }

        public async Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourse()
        {
            return await _trainingCourse.Customer.GetTrainingCourse();
        }

        public async Task<TrainingCourseViewModel> GetTrainingCourseById(int trainingCourseId)
        {
            return await _trainingCourse.Customer.GetTrainingCourseById(trainingCourseId);
        }

        public async Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourseBySpeciesId(int birdSpeciesId)
        {
            return await _trainingCourse.Customer.GetTrainingCourseBySpeciesId(birdSpeciesId);
        }

        public async Task RegisterBird(BirdAddModel bird)
        {
            await _trainingCourse.Customer.RegisterBird(bird);
        }

        public async Task RegisterTrainingCourse(BirdTrainingCourseRegister birdTrainingCourseRegister)
        {
            await _trainingCourse.Customer.RegisterTrainingCourse(birdTrainingCourseRegister);
        }

        public async Task UpdateBirdProfile(BirdModifyModel bird)
        {
            await _trainingCourse.Customer.UpdateBirdProfile(bird);
        }

        public async Task<IEnumerable<BirdTrainingProgressViewModel>> ViewBirdTrainingCourseProgress(int birdTrainingCourseId)
        {
            return await _trainingCourse.Customer.ViewBirdTrainingCourseProgress(birdTrainingCourseId);
        }

        public async Task<IEnumerable<BirdTrainingReportViewModel>> ViewBirdTrainingCourseReport(int birdTrainingProgressId)
        {
            return await _trainingCourse.Customer.ViewBirdTrainingCourseReport(birdTrainingProgressId);
        }

        public async Task<IEnumerable<BirdTrainingCourseViewModel>> ViewRegisteredTrainingCourse(int birdId, int customerId)
        {
            return await _trainingCourse.Customer.ViewRegisteredTrainingCourse(birdId: birdId, customerId: customerId);
        }
    }
}