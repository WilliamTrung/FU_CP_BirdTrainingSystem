using Models.ServiceModels.OnlineCourseModels.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.OnlineCourseService
{
    public interface IServiceManager : IServiceStaff
    {
        Task CreateOnlineCourse(OnlineCourseAddModel model);
        Task AddSection(OnlineCourseSectionAddModel model);
        Task AddLesson(OnlineCourseLessonAddModel model);
        Task ModifySection(OnlineCourseSectionModifyModel model);
        Task ModifyLesson(OnlineCourseLessonModifyModel model);
        Task DeleteSection(int sectionId);
        Task DeleteLesson(int lessonId);
        Task ChangeCourseStatus(int courseId, Models.Enum.OnlineCourse.Status status);
    }
}
