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
        public decimal? TotalPrice { get; set; }
        public decimal? DiscountedPrice { get; set; }
        //public DateTime? LastestUpdate { get; set; }
        //public int Status { get; set; }

        //public virtual BirdModel Bird { get; set; } = null!;
        //public virtual TrainingCourseModel TrainingCourse { get; set; } = null!;
    }
}
