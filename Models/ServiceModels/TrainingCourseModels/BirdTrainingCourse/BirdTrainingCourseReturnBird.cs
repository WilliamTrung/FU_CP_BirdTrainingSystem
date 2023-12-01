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
        public int TrainingPricePolicyId { get; set; }
        public decimal ActualPrice { get; set; }
        public string? ReturnNote { get; set; }
        public string? ReturnPicture { get; set; }
    }
}