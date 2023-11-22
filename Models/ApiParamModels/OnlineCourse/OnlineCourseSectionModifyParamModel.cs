using Microsoft.AspNetCore.Http;
using Models.ServiceModels.OnlineCourseModels.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.OnlineCourse
{
    public class OnlineCourseSectionModifyParamModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<IFormFile>? ResourceFiles { get; set; }

        public OnlineCourseSectionModifyModel ToOnlineCourseLessonModifyModel(string? files = null)
        {
            return new OnlineCourseSectionModifyModel
            {
                Id = Id,
                Title = Title,
                Description = Description,
                ResourceFiles = files
            };
        }
    }
}
