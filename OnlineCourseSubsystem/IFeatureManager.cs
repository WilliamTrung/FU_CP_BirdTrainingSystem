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
        Task CreateOnlineCourse(OnlineCourseAddModel model);
        Task AddSection(int courseId, OnlineCourseSectionAddModel model);
        Task AddLesson(int sectionId, OnlineCourseLessonAddModel model);
        Task ModifySection(int sectionId, OnlineCourseSectionModifyModel model);
        Task ModifyLesson(int lessonId, OnlineCourseLessonModifyModel model);
        Task DeleteSection(int sectionId);
        Task DeleteLesson(int lessonId);
        Task ChangeCourseStatus(int courseId, Models.Enum.OnlineCourse.Status status);
        
    }
}
