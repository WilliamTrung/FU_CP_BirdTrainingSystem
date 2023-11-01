using Models.ServiceModels.TrainingCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem
{
    public interface IFeatureAll
    {
        Task<IEnumerable<BirdSpeciesModel>> GetBirdSpecies();
        Task<BirdSpeciesModel> GetBirdSpeciesById(int birdSpeciesId);
    }
}
