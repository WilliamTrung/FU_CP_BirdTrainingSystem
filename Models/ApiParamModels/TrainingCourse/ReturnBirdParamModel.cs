using Microsoft.AspNetCore.Http;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using SP_Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.TrainingCourse
{
    public class ReturnBirdParamModel
    {
        public int BirdTrainingCourseId { get; set; }
        public string? ReturnNote { get; set; }
        public int TrainingPricePolicyId { get; set; }
        public decimal ActualPrice { get; set; }
        //[FileImageValidator]
        public List<IFormFile>? ReturnPictures { get; set; }
        public BirdTrainingCourseReturnBird ToBirdTrainingCourseReturnBird(string returnPicture)
        {
            return new BirdTrainingCourseReturnBird
            {
                Id = BirdTrainingCourseId,
                TrainingPricePolicyId = TrainingPricePolicyId,
                //ReturnStaffId = ReturnStaffId,
                ReturnNote = ReturnNote,
                ReturnPicture = returnPicture
            };
        }
    }
}
