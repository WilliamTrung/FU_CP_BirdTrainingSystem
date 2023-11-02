using Models.Enum.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;
using TrainingCourseSubsystem;

namespace AppService.TrainingCourseService.Implement
{
    public class ServiceAll : IServiceAll
    {
        internal readonly ITrainingCourseFeature _trainingCourse;
        internal readonly ITimetableFeature _timetable;
        public ServiceAll(ITrainingCourseFeature trainingCourse, ITimetableFeature timetable)
        {
            _timetable = timetable;
            _trainingCourse = trainingCourse;
        }

        public async Task<IEnumerable<BirdSpeciesModel>> GetBirdSpecies()
        {
            return await _trainingCourse.All.GetBirdSpecies();
        }

        public async Task<BirdSpeciesModel> GetBirdSpeciesById(int birdSpeciesId)
        {
            return await _trainingCourse.All.GetBirdSpeciesById(birdSpeciesId);
        }

        public IEnumerable<Status> GetEnumBirdTrainingProgressStatuses()
        {
            return _trainingCourse.Staff.GetEnumBirdTrainingProgressStatuses();
        }
    }
}
