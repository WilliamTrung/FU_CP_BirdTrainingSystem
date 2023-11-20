using Microsoft.AspNetCore.Http;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using SP_Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.TrainingCourse
{
    public class TrainingCourseModParamModel
    {
        public int Id { get; set; }
        public int BirdSpeciesId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public List<IFormFile>? Pictures { get; set; }
        public decimal TotalPrice { get; set; }

        public TrainingCourseModifyModel ToTrainingCourseModel(string picture)
        {
            return new TrainingCourseModifyModel
            {
                Id = Id,
                BirdSpeciesId = BirdSpeciesId,
                Title = Title,
                Description = Description,
                Picture = picture,
                TotalPrice = TotalPrice
            };
        }
    }
}
