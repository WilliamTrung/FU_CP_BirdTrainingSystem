using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ServiceModels.TrainingCourseModels.Bird;

namespace Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse
{
    //    [BirdTrainingCourseReturnBird]
    //+	Id:int 
    //+	BirdId:int 
    //+	StaffId:int
    //+	CustomerId:int
    //+	ActualDateReturn:date
    //+	ReturnNote:string
    //+	ReturnPicture:string
    //+	LastestUpdate:date
    //+	Status:int

    public class BirdTrainingCourseReturnBird
    {
        public int Id { get; set; }
        public int ReturnStaffId { get; set; }
        //public DateTime? ActualDateReturn { get; set; } //BE gen
        public string? ReturnNote { get; set; }
        public string? ReturnPicture { get; set; }
        //public DateTime? LastestUpdate { get; set; } //BE gen
        //public int Status { get; set; } //BE gen

        public virtual BirdModel Bird { get; set; } = null!;
        public virtual UserModel Staff { get; set; } = null!;
    }
}