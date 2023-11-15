using Microsoft.AspNetCore.Http;
using Models.ServiceModels.OnlineCourseModels.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.OnlineCourse
{
    public class OnlineCourseSectionAddParamModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<IFormFile>? ResourceFiles { get; set; }
        public OnlineCourseSectionAddModel ToOnlineCourseLessonModifyModel(string? files = null)
        {
            return new OnlineCourseSectionAddModel
            {
                CourseId = CourseId,
                Title = Title,
                Description = Description,
                ResourceFiles = files
            };
        }
    }
}
