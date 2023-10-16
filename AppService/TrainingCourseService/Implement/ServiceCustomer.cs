using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCourseSubsystem;

namespace AppService.TrainingCourseService.Implement
{
    public class ServiceCustomer : IServiceCustomer
    {
        IFeatureCustomer _featureCustomer;
        public ServiceCustomer(IFeatureCustomer featureCustomer)
        {
            _featureCustomer = featureCustomer;
        }
        public async Task<IEnumerable<BirdModel>> GetBirdByCustomerId(int customerId)
        {
            return await _featureCustomer.GetBirdByCustomerId(customerId);
        }

        public async Task<IEnumerable<TrainingCourseModel>> GetTrainingCourse()
        {
            return await _featureCustomer.GetTrainingCourse();
        }

        public async Task<TrainingCourseModel> GetTrainingCourseById(int trainingCourseId)
        {
            return await _featureCustomer.GetTrainingCourseById(trainingCourseId);
        }

        public async Task<IEnumerable<TrainingCourseModel>> GetTrainingCourseBySpeciesId(int birdSpeciesId)
        {
            return await _featureCustomer.GetTrainingCourseBySpeciesId(birdSpeciesId);
        }

        public async Task RegisterBird(BirdModel bird)
        {
            await _featureCustomer.RegisterBird(bird);
        }

        public async Task RegisterTrainingCourse(BirdTrainingCourseRegister birdTrainingCourseRegister)
        {
            await _featureCustomer.RegisterTrainingCourse(birdTrainingCourseRegister);
        }

        public async Task UpdateBirdProfile(BirdModel bird)
        {
            await UpdateBirdProfile(bird);
        }
    }
}
