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
        public string? ReceiveNote { get; set; }
        public string? ReceivePicture { get; set; }
    }
}