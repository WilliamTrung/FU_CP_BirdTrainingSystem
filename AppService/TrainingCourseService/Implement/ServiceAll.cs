using Models.Enum.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
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

        public async Task<IEnumerable<BirdSpeciesViewModel>> GetBirdSpecies()
        {
            return await _trainingCourse.All.GetBirdSpecies();
        }

        public async Task<BirdSpeciesViewModel> GetBirdSpeciesById(int birdSpeciesId)
        {
            return await _trainingCourse.All.GetBirdSpeciesById(birdSpeciesId);
        }

        public IEnumerable<Status> GetEnumBirdTrainingProgressStatuses()
        {
            return _trainingCourse.Staff.GetEnumBirdTrainingProgressStatuses();
        }

        public Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourses()
        {
            return _trainingCourse.All.GetTrainingCourses();
        }

        public Task<TrainingCourseViewModel> GetTrainingCoursesById(int courseId)
        {
            return _trainingCourse.All.GetTrainingCoursesById(courseId);
        }
    }
}
