using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SP_Validator;
using Microsoft.AspNetCore.Http;

namespace Models.ApiParamModels.TrainingCourse
{
    public class BirdParamModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BirdSpeciesId { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        [FileImageValidator]
        public List<IFormFile>? Pictures { get; set; }
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
        public int Status { get; set; }

        public BirdModel ToBirdModel(string? picture)
        {
            return new BirdModel
            {
                Id = Id,
                CustomerId= CustomerId,
                BirdSpeciesId= BirdSpeciesId,
                Name = Name,
                Color = Color,
                Picture = picture,
                Description= Description,
                IsDefault = IsDefault,
                Status = (int)Models.Enum.Bird.Status.Ready
            };
        }
    }
}
