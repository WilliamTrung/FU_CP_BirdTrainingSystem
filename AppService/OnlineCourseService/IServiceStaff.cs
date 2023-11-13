using Models.ServiceModels.OnlineCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.OnlineCourseService
{
    public interface IServiceStaff : IServiceAll
    {
        Task<IEnumerable<OnlineCourseLessonViewModel>> GetLessonsBySection(int sectionId);
        Task<IEnumerable<OnlineCourseSectionViewModel>> GetSectionsByCourse(int courseId);
        Task<OnlineCourseLessonViewModel> GetLessonById(int id);
        Task<OnlineCourseSectionViewModel> GetSectionById(int sectionId);
    }
}
