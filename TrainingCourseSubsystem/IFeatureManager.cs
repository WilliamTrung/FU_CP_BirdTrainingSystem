using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem
{
    public interface IFeatureManager : IFeatureAll
    {
        //FE37	[Manager] manage [Training Course] - view, create, edit, archive [Training Course]
        //Can create new training course
        //Can edit training course
        //Can archive training course
        Task CreateCourse(TrainingCourseAddModel trainingCourse);
        Task EditCourse(TrainingCourseModifyModel trainingCourse);
        Task ActiveTrainingCourse(int trainingCourseId);
        Task DisableTrainingCourse(int trainingCourseId);
        Task AddSkillToCourse(AddTrainingSkillModel trainingCourseSkill);
        Task UpdateSkill(AddTrainingSkillModel trainingSkillModel);
        Task CreateBirdSpecies(BirdSpeciesAddModel birdSpecies);
        Task EditBirdSpecies(BirdSpeciesViewModel birdSpecies);
    }
}