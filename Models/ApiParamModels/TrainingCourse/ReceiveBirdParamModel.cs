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
        public int Id { get; set; }
        public int ReceiveStaffId { get; set; }
        //public DateTime? ActualStartDate { get; set; }
        //public DateTime? ExpectedTrainingDoneDate { get; set; } //BE gen
        //public DateTime? DateReceivedBird { get; set; } //BE gen
        public string? ReceiveNote { get; set; }
        [FileImageValidator]
        public List<IFormFile>? ReceivePictures { get; set; }
        //public DateTime? LastestUpdate { get; set; } //BE gen
        //public int Status { get; set; } //BE gen

        public BirdTrainingCourseReceiveBird ToBirdTrainingCourseReceiveBird(string receivePicture)
        {
            return new BirdTrainingCourseReceiveBird
            {
                Id = Id,
                ReceiveStaffId= ReceiveStaffId,
                ReceiveNote = ReceiveNote,
                ReceivePicture = receivePicture
            };
        }
    }
}
