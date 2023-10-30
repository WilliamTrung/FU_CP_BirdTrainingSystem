using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SP_Validator;

namespace Models.ApiParamModels.TrainingCourse
{
    public class TrainingCourseParamModel
    {
        public int Id { get; set; }
        public int BirdSpeciesId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        [FileImageValidator]
        public List<IFormFile>? Pictures { get; set; }
        public int TotalSlot { get; set; }
        public decimal TotalPrice { get; set; }

        public TrainingCourseModel ToTrainingCourseModel(string picture)
        {
            return new TrainingCourseModel
            {
                Id= Id,
                BirdSpeciesId= BirdSpeciesId,
                Title = Title,
                Description = Description,
                Picture= picture,
                TotalPrice= TotalPrice,
                TotalSlot= TotalSlot
            };
        }
    }
}
