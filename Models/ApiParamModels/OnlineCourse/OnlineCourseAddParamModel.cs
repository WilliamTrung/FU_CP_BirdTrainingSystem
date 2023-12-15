using Microsoft.AspNetCore.Http;
using Models.ServiceModels.OnlineCourseModels.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.OnlineCourse
{
    public class OnlineCourseAddParamModel
    {
        public string Title { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;        
        public IFormFile Picture { get; set; } = null!;
        [SP_Validator.PositiveNumber]
        public decimal Price { get; set; }

        public OnlineCourseAddModel ToOnlineCourseAddModel(string picture)
        {
            return new OnlineCourseAddModel
            {
                Picture = picture,
                Price = Price,
                Title = Title,
                ShortDescription = ShortDescription                
            };
        }
    }
}
