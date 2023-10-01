using SP_Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
    public class ClassAddModel
    {
        public int WorkshopId { get; set; }
        // choose start time then Add workshop register end date for output RegisterEndDate entity
        [ClassStartTimeValidator]
        public DateTime StartTime { get; set; }
    }
}
