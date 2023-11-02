using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.Bird;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.TrainingCourseService
{
    public interface IServiceManager : IServiceAll
    {
        Task CreateCourse(TrainingCourseModel trainingCourse);
        Task EditCourse(TrainingCourseModel trainingCourse);
        Task DisableTrainingCourse(int trainingCourseId);
        Task AddSkill(TrainingCourseSkillModel trainingCourseSkill);
        Task ActiveTrainingCourse(int trainingCourseId);
        Task CreateBirdSpecies(BirdSpeciesAddModel birdSpecies);
        Task EditBirdSpecies(BirdSpeciesModel birdSpecies);
    }
}
