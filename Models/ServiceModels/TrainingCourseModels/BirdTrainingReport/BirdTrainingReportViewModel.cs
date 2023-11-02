using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.BirdTrainingReport
{
    public class BirdTrainingReportViewModel
    {
        public DateTime TrainingDate { get; set; }
        public Models.Enum.BirdTrainingReport.Status Status { get; set; }
    }
}
