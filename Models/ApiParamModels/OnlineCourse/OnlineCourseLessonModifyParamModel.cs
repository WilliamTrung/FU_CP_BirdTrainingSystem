using Microsoft.AspNetCore.Http;
using Models.ServiceModels.OnlineCourseModels.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.OnlineCourse
{
    public class OnlineCourseLessonModifyParamModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public IFormFile? Video { get; set; }
        public OnlineCourseLessonModifyModel ToOnlineCourseLessonModifyModel(string? video = null)
        {
            return new OnlineCourseLessonModifyModel
            {
                Id = Id,
                Title = Title,
                Description = Description,
                Detail = Detail,
                Video = video
            };
        }
    }
}
