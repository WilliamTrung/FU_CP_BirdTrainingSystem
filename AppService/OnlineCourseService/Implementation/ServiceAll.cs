using Models.ServiceModels.OnlineCourseModels;
using OnlineCourseSubsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.OnlineCourseService.Implementation
{
    public class ServiceAll : IServiceAll
    {
        internal readonly IOnlineCourseFeature _onlineCourse;
        public ServiceAll(IOnlineCourseFeature onlineCourse)
        {
            _onlineCourse = onlineCourse;
        }

        public async Task<OnlineCourseModel> GetCourseById(int id)
        {
            var result = await _onlineCourse.All.GetCourseById(id);
            return result;
        }

        public async Task<IEnumerable<OnlineCourseModel>> GetCourses()
        {
            var result = await _onlineCourse.All.GetCourses();
            return result;
        }
    }
}
