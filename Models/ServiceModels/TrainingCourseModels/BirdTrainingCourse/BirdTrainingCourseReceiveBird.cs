using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int BirdId { get; set; }
        public int StaffId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? DateReceivedBird { get; set; }
        public string? ReceiveNote { get; set; }
        public string? ReceivePicture { get; set; }
        public DateTime? LastestUpdate { get; set; }
        public int Status { get; set; }

        public virtual BirdModel Bird { get; set; } = null!;
        public virtual UserModel Staff { get; set; } = null!;
    }
}
