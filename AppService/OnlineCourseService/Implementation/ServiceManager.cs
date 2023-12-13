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

        public async Task AddLesson(OnlineCourseLessonAddModel model)
        {
            await _onlineCourse.Manager.AddLesson(model);
        }

        public async Task AddSection(OnlineCourseSectionAddModel model)
        {
            await _onlineCourse.Manager.AddSection(model);
        }

        public async Task ChangeCourseStatus(int courseId, Status status)
        {
            await _onlineCourse.Manager.ChangeCourseStatus(courseId, status);
        }

        public async Task<int> CreateOnlineCourse(OnlineCourseAddModel model)
        {
            var id = await _onlineCourse.Manager.CreateOnlineCourse(model);
            return id;
        }

        public async Task DeleteLesson(int lessonId)
        {
            await _onlineCourse.Manager.DeleteLesson(lessonId);
        }

        public async Task DeleteSection(int sectionId)
        {
            await _onlineCourse.Manager.DeleteSection(sectionId);
        }

        public async Task ModifyLesson(OnlineCourseLessonModifyModel model)
        {
            await _onlineCourse.Manager.ModifyLesson(model);
        }

        public async Task ModifyOnlineCourse(OnlineCourseModifyModel model)
        {
            await _onlineCourse.Manager.ModifyCourse(model);
        }

        public async Task ModifySection(OnlineCourseSectionModifyModel model)
        {
            await _onlineCourse.Manager.ModifySection(model);
        }
    }
}
