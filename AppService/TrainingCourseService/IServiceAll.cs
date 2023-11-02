using Models.ServiceModels.TrainingCourseModels.Bird;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.TrainingCourseService
{
    public interface IServiceAll
    {
        Task<IEnumerable<BirdSpeciesModel>> GetBirdSpecies();
        Task<BirdSpeciesModel> GetBirdSpeciesById(int birdSpeciesId);
        IEnumerable<Models.Enum.BirdTrainingProgress.Status> GetEnumBirdTrainingProgressStatuses();
    }
}
