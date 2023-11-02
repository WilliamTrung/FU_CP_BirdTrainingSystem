using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;

namespace AppService.TrainingCourseService
{
    public interface IServiceCustomer : IServiceAll
    {
        Task RegisterBird(BirdAddModel bird);
        Task UpdateBirdProfile(BirdModifyModel bird);
        Task<IEnumerable<BirdViewModel>> GetBirdByCustomerId(int customerId);
        Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourse();
        Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourseBySpeciesId(int birdSpeciesId);
        Task<TrainingCourseViewModel> GetTrainingCourseById(int trainingCourseId);
        Task RegisterTrainingCourse(BirdTrainingCourseRegister birdTrainingCourseRegister);
        Task<IEnumerable<BirdTrainingCourseViewModel>> ViewRegisteredTrainingCourse(int birdId, int customerId);
        Task<IEnumerable<BirdTrainingProgressViewModel>> ViewBirdTrainingCourseProgress(int birdTrainingCourseId);
        Task<IEnumerable<BirdTrainingReportViewModel>> ViewBirdTrainingCourseReport(int birdTrainingProgressId);
    }
}