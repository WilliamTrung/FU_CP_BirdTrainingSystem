using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
//    [WorkshopClassAdd]:
//+ workshopId : int
//+ startTime : date
    public class WorkshopClassAddModel
    {
        public int WorkshopId { get; set; }
        [SP_Validator.ClassStartTimeValidator]
        public DateTime StartTime { get; set; }
    }
}
