using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem
{
    //FE26[Customer] explore[Training Course] - on mobile app - specified price must be detailed for each[Training Course]
    //FE27[Customer] register[Bird] to[Training Course] - on mobile app - stricken with[Bird] speciality
    //FE28[Customer] view[Training Course Detail] - of the in-training[Bird] - to check progression
    public interface IFeatureCustomer
    {
        Task RegisterBird(BirdModel bird);
        Task UpdateBirdProfile(BirdModel bird);
        Task<IEnumerable<TrainingCourseModel>> GetTrainingCourse();
        Task<TrainingCourseModel> GetTrainingCourseById(int trainingCourseId);
        Task RegisterTrainingCourse(BirdTrainingCourseRegister birdTrainingCourseRegister);
    }
}
