using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;

namespace Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse
{
    public class BirdTrainingCourseRegister
    {
        //        [BirdTrainingCourseRegister]
        //+	BirdId:int 
        //+	TrainingCourseId:int 
        //+	CustomerId:int
        //+	Status:int

        public int BirdId { get; set; }
        public int TrainingCourseId { get; set; }
        public int CustomerId { get; set; }
        [SP_Validator.PositiveNumber]
        public decimal? TotalPrice { get; set; }
        //public decimal? DiscountedPrice { get; set; }
    }
}
