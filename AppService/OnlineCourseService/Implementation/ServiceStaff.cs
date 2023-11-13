using Models.ServiceModels.OnlineCourseModels;
using OnlineCourseSubsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.OnlineCourseService.Implementation
{
    public class ServiceStaff : ServiceAll, IServiceStaff
    {
        public ServiceStaff(IOnlineCourseFeature onlineCourse) : base(onlineCourse)
        {
        }

        public async Task<OnlineCourseLessonViewModel> GetLessonById(int id)
        {
            var result = await _onlineCourse.Staff.GetLessonByLessonId(id);
            return result;
        }

        public async Task<IEnumerable<OnlineCourseLessonViewModel>> GetLessonsBySection(int sectionId)
        {
            var result = await _onlineCourse.Staff.GetLessonsBySection(sectionId);
            return result;
        }

        public async Task<OnlineCourseSectionViewModel> GetSectionById(int sectionId)
        {
            var result = await _onlineCourse.Staff.GetSectionById(sectionId);
            return result;
        }

        public async Task<IEnumerable<OnlineCourseSectionViewModel>> GetSectionsByCourse(int courseId)
        {
            var result = await _onlineCourse.Staff.GetSectionsByCourseId(courseId);
            return result;
        }
    }
}
