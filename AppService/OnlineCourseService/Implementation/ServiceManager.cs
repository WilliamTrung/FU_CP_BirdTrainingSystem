using Models.Enum.OnlineCourse;
using Models.ServiceModels.OnlineCourseModels.Operation;
using OnlineCourseSubsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.OnlineCourseService.Implementation
{
    public class ServiceManager : ServiceStaff, IServiceManager
    {
        public ServiceManager(IOnlineCourseFeature onlineCourse) : base(onlineCourse)
        {
        }

        public async Task AddLesson(int sectionId, OnlineCourseLessonAddModel model)
        {
            await _onlineCourse.Manager.AddLesson(sectionId, model);
        }

        public async Task AddSection(int courseId, OnlineCourseSectionAddModel model)
        {
            await _onlineCourse.Manager.AddSection(courseId, model);
        }

        public async Task ChangeCourseStatus(int courseId, Status status)
        {
            await _onlineCourse.Manager.ChangeCourseStatus(courseId, status);
        }

        public async Task CreateOnlineCourse(OnlineCourseAddModel model)
        {
            await _onlineCourse.Manager.CreateOnlineCourse(model);
        }

        public async Task DeleteLesson(int lessonId)
        {
            await _onlineCourse.Manager.DeleteLesson(lessonId);
        }

        public async Task DeleteSection(int sectionId)
        {
            await _onlineCourse.Manager.DeleteSection(sectionId);
        }

        public async Task ModifyLesson(int lessonId, OnlineCourseLessonModifyModel model)
        {
            await _onlineCourse.Manager.ModifyLesson(lessonId, model);
        }

        public async Task ModifySection(int sectionId, OnlineCourseSectionModifyModel model)
        {
            await _onlineCourse.Manager.ModifySection(sectionId, model);
        }
    }
}
