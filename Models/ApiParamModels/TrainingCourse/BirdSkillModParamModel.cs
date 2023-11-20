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
    public class BirdSkillModParamModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public IFormFile? Pictures { get; set; }

        public BirdSkillModModel ToBirdSkillModModel(string picture)
        {
            return new BirdSkillModModel()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Picture = picture
            };
        }
    }
}
