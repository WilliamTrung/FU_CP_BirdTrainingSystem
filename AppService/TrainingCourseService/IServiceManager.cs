using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.TrainingCourseService
{
    public interface IServiceManager : IServiceAll
    {
        Task CreateCourse(TrainingCourseAddModel trainingCourse);
        Task EditCourse(TrainingCourseModifyModel trainingCourse);
        Task DisableTrainingCourse(int trainingCourseId);
        Task AddSkill(AddTrainingSkillModel trainingCourseSkill);
        Task ActiveTrainingCourse(int trainingCourseId);
        Task CreateBirdSpecies(BirdSpeciesAddModel birdSpecies);
        Task EditBirdSpecies(BirdSpeciesViewModel birdSpecies);
    }
}
