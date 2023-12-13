using Microsoft.AspNetCore.Http;
using Models.ServiceModels.OnlineCourseModels.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.OnlineCourse
{
    public class OnlineCourseModifyParamModel
    {
        public int Id { get; set; }
        public string? Title { get; set; } = null!;
        public string? ShortDescription { get; set; } = null!;
        public IFormFile? Picture { get; set; } = null!;
        public decimal? Price { get; set; }

        public OnlineCourseModifyModel ToOnlineCourseModifyModel(string? picture)
        {
            return new OnlineCourseModifyModel
            {
                Picture = picture,
                Price = Price,
                Title = Title,
                ShortDescription = ShortDescription
            };
        }
    }
}
