using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;
using TrainingCourseSubsystem;

namespace AppService.TrainingCourseService.Implement
{
    public class ServiceAll
    {
        internal readonly ITrainingCourseFeature _trainingCourse;
        internal readonly ITimetableFeature _timetable;
        public ServiceAll(ITrainingCourseFeature trainingCourse, ITimetableFeature timetable)
        {
            _timetable = timetable;
            _trainingCourse = trainingCourse;
        }
    }
}
