using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse
{
//    [BirdTrainingCourseStartTime]
//+	BirdId:int 
//+	TrainingCourseId:int 
//+	StaffId:int
//+	ExpectedStartDate:date
//+	ExpectedDateReturn:date
//+	LastestUpdate:date

    public class BirdTrainingCourseStartTime
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public DateTime? ExpectedStartDate { get; set; }
        public DateTime? ExpectedTrainingDoneDate { get; set; }
        public DateTime? ExpectedDateReturn { get; set; }
        public DateTime? LastestUpdate { get; set; }
        public int Status { get; set; }
    }
}
