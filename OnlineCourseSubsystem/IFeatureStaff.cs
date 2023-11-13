using Models.ServiceModels.OnlineCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseSubsystem
{
    public interface IFeatureStaff : IFeatureAll
    {
        Task<IEnumerable<OnlineCourseLessonViewModel>> GetLessonsBySection(int sectionId);
        Task<IEnumerable<OnlineCourseSectionViewModel>> GetSectionsByCourseId(int courseId);
        Task<OnlineCourseLessonViewModel> GetLessonByLessonId(int lessonId);
        Task<OnlineCourseSectionViewModel> GetSectionById(int sectionId);
    }
}
