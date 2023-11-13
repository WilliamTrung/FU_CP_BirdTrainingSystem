using Models.ServiceModels.OnlineCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.OnlineCourseService
{
    public interface IServiceAll
    {
        Task<IEnumerable<OnlineCourseModel>> GetCourses();
        Task<OnlineCourseModel> GetCourseById(int id);
    }
}
