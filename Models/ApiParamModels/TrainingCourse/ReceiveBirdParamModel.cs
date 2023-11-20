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
    public class ReceiveBirdParamModel
    {
        public int BirdTrainingCourseId { get; set; }
        public string? ReceiveNote { get; set; }
        //[FileImageValidator]
        public List<IFormFile>? ReceivePictures { get; set; }

        public BirdTrainingCourseReceiveBird ToBirdTrainingCourseReceiveBird(string receivePicture)
        {
            return new BirdTrainingCourseReceiveBird
            {
                Id = BirdTrainingCourseId,
                //ReceiveStaffId= ReceiveStaffId,
                ReceiveNote = ReceiveNote,
                ReceivePicture = receivePicture
            };
        }
    }
}
