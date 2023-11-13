using Microsoft.AspNetCore.Http;
using Models.ServiceModels.OnlineCourseModels.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.OnlineCourse
{
    public class OnlineCourseLessonAddParamModel
    {
        public int SectionId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Detail { get; set; }        
        public IFormFile? Video { get; set; }
        public OnlineCourseLessonAddModel ToOnlineCourseLessonAddModel(string? video = null)
        {
            return new OnlineCourseLessonAddModel
            {
                SectionId = SectionId,
                Title = Title,
                Description = Description,
                Detail = Detail,
                Video = video,
            };
        }
    }
}
