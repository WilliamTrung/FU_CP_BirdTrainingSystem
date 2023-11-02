using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SP_Validator;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;

namespace Models.ApiParamModels.TrainingCourse
{
    public class TrainingCourseAddParamModel
    {
        public int BirdSpeciesId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        [FileImageValidator]
        public List<IFormFile>? Pictures { get; set; }
        public decimal TotalPrice { get; set; }

        public TrainingCourseAddModel ToTrainingCourseModel(string picture)
        {
            return new TrainingCourseAddModel
            {
                BirdSpeciesId= BirdSpeciesId,
                Title = Title,
                Description = Description,
                Picture= picture,
                TotalPrice= TotalPrice
            };
        }
    }
}
