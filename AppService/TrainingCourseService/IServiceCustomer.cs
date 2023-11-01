using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using Models.ServiceModels.TrainingCourseModels.Bird;

namespace AppService.TrainingCourseService
{
    public interface IServiceCustomer : IServiceAll
    {
        Task RegisterBird(BirdAddModel bird);
        Task UpdateBirdProfile(BirdModifyModel bird);
        Task<IEnumerable<BirdViewModel>> GetBirdByCustomerId(int customerId);
        Task<IEnumerable<TrainingCourseModel>> GetTrainingCourse();
        Task<IEnumerable<TrainingCourseModel>> GetTrainingCourseBySpeciesId(int birdSpeciesId);
        Task<TrainingCourseModel> GetTrainingCourseById(int trainingCourseId);
        Task RegisterTrainingCourse(BirdTrainingCourseRegister birdTrainingCourseRegister);
        Task<IEnumerable<BirdTrainingCourseViewModel>> ViewRegisteredTrainingCourse(int birdId, int customerId);
        Task<IEnumerable<BirdTrainingProgressViewModel>> ViewBirdTrainingCourseProgress(int birdTrainingCourseId);
        Task<IEnumerable<BirdTrainingReportViewModel>> ViewBirdTrainingCourseReport(int birdTrainingProgressId);
    }
}