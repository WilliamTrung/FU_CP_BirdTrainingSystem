using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.TrainingCourseService
{
    public interface IServiceCustomer
    {
        Task RegisterBird(BirdModel bird);
        Task UpdateBirdProfile(BirdModel bird);
        Task<IEnumerable<BirdModel>> GetBirdByCustomerId(int customerId);
        Task<IEnumerable<TrainingCourseModel>> GetTrainingCourse();
        Task<IEnumerable<TrainingCourseModel>> GetTrainingCourseBySpeciesId(int birdSpeciesId);
        Task<TrainingCourseModel> GetTrainingCourseById(int trainingCourseId);
        Task RegisterTrainingCourse(BirdTrainingCourseRegister birdTrainingCourseRegister);
    }
}