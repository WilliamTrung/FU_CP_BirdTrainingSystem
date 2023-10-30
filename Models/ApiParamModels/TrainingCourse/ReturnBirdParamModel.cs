using Microsoft.AspNetCore.Http;
using Models.ServiceModels.TrainingCourseModels;
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
        public int Id { get; set; }
        public int ReturnStaffId { get; set; }
        //public DateTime? ActualDateReturn { get; set; } //BE gen
        public string? ReturnNote { get; set; }
        [FileImageValidator]
        public List<IFormFile>? ReturnPictures { get; set; }
        //public DateTime? LastestUpdate { get; set; } //BE gen
        //public int Status { get; set; } //BE gen

        public virtual BirdModel Bird { get; set; } = null!;
        public virtual UserModel Staff { get; set; } = null!;
        public BirdTrainingCourseReturnBird ToBirdTrainingCourseReturnBird(string returnPicture)
        {
            return new BirdTrainingCourseReturnBird
            {
                Id = Id,
                ReturnStaffId = ReturnStaffId,
                ReturnNote = ReturnNote,
                ReturnPicture = returnPicture
            };
        }
    }
}
