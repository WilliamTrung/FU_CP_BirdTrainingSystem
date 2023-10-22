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
    public class ServiceManager : ServiceAll, IServiceManager
    {
        public ServiceManager(ITrainingCourseFeature trainingCourse, ITimetableFeature timetable) : base(trainingCourse, timetable)
        {
        }

        public async Task ActiveTrainingCourse(int trainingCourseId)
        {
            await _trainingCourse.Manager.ActiveTrainingCourse(trainingCourseId);
        }

        public async Task AddSkill(TrainingCourseSkillModel trainingCourseSkill)
        {
            await _trainingCourse.Manager.AddSkill(trainingCourseSkill);
        }

        public async Task CreateCourse(TrainingCourseModel trainingCourse)
        {
            await _trainingCourse.Manager.CreateCourse(trainingCourse);
        }

        public async Task DisableTrainingCourse(int trainingCourseId)
        {
            await _trainingCourse.Manager.DisableTrainingCourse(trainingCourseId);
        }

        public async Task EditCourse(TrainingCourseModel trainingCourse)
        {
            await _trainingCourse.Manager.EditCourse(trainingCourse);
        }
    }
}
