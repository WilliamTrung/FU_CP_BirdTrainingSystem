using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SP_Validator;
using Microsoft.AspNetCore.Http;
using Models.ServiceModels.TrainingCourseModels.Bird;

namespace Models.ApiParamModels.TrainingCourse
{
    public class BirdAddParamModel
    {
        public int CustomerId { get; set; }
        public int BirdSpeciesId { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        [FileImageValidator]
        public List<IFormFile>? Pictures { get; set; }
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }

        public BirdAddModel ToBirdAddModel(string? picture)
        {
            return new BirdAddModel
            {
                CustomerId= CustomerId,
                BirdSpeciesId= BirdSpeciesId,
                Name = Name,
                Color = Color,
                Picture = picture,
                Description= Description,
                IsDefault = IsDefault
            };
        }
    }
}
