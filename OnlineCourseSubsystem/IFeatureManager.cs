using Models.ServiceModels.OnlineCourseModels.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseSubsystem
{
    public interface IFeatureManager
    {
        Task<int> CreateOnlineCourse(OnlineCourseAddModel model);
        Task AddSection(OnlineCourseSectionAddModel model);
        Task AddLesson(OnlineCourseLessonAddModel model);
        Task ModifySection(OnlineCourseSectionModifyModel model);
        Task ModifyLesson(OnlineCourseLessonModifyModel model);
        Task DeleteSection(int sectionId);
        Task DeleteLesson(int lessonId);
        Task ChangeCourseStatus(int courseId, Models.Enum.OnlineCourse.Status status);
        
    }
}
