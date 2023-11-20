using Microsoft.AspNetCore.Http;
using Models.ServiceModels.TrainingCourseModels.Bird;
using SP_Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.TrainingCourse
{
    public class BirdModifyParamModel
    {
        public int Id { get; set; }
        //public int BirdSpeciesId { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public IFormFile? Picture { get; set; }
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }

        public BirdModifyModel ToBirdModifyModel(string? picture)
        {
            return new BirdModifyModel
            {
                Id= Id,
                //BirdSpeciesId = BirdSpeciesId,
                Name = Name,
                Color = Color,
                Picture = picture,
                Description = Description,
                IsDefault = IsDefault
            };
        }
    }
}
