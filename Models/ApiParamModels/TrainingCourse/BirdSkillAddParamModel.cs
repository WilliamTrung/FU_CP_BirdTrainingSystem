using Microsoft.AspNetCore.Http;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using SP_Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.TrainingCourse
{
    public class BirdSkillAddParamModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public IFormFile? Picture { get; set; }

        public BirdSkillAddModel ToBirdSkillAddModel(string picture)
        {
            return new BirdSkillAddModel()
            {
                Name = Name,
                Description = Description,
                Picture = picture
            };
        }
    }
}
