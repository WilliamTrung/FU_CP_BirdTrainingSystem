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
        public int TrainerId { get; set; }
        public DateTime? ExpectedStartDate { get; set; } //BE gen
        public DateTime? ExpectedTrainingDoneDate { get; set; } //BE gen
        public DateTime? ExpectedDateReturn { get; set; } //BE gen
        public DateTime? LastestUpdate { get; set; } //BE gen
        public int Status { get; set; } //BE gen
    }
}
