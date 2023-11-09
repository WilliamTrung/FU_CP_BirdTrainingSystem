using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.BirdTrainingReport
{
    public class ReportModifyModel
    {
        public int ReportId { get; set; }
        public int SlotId { get; set; }
        public int TrainerId { get; set; }
        [SP_Validator.DateOnlyValidator]
        public DateTime Date { get; set; }

    }
}
