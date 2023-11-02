using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ServiceModels.TrainingCourseModels.Bird;

namespace Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse
{
    //[BirdTrainingCourseReceiveBird]
    //+	Id:int 
    //+	BirdId:int 
    //+	StaffId:int
    //+	CustomerId:int
    //+	ActualStartDate:date
    //+	DateReceivedBird:date
    //+	ReceiveNote: string
    //+	ReceivePicture: string
    //+	LastestUpdate:date
    //+	Status:int

    public class BirdTrainingCourseReceiveBird
    {
        public int Id { get; set; }
        public int ReceiveStaffId { get; set; }
        //public DateTime? ActualStartDate { get; set; }
        //public DateTime? ExpectedTrainingDoneDate { get; set; } //BE gen
        //public DateTime? DateReceivedBird { get; set; } //BE gen
        public string? ReceiveNote { get; set; }
        public string? ReceivePicture { get; set; }
        //public DateTime? LastestUpdate { get; set; } //BE gen
        //public int Status { get; set; } //BE gen

        public virtual BirdModel Bird { get; set; } = null!;
        public virtual UserModel Staff { get; set; } = null!;
    }
}