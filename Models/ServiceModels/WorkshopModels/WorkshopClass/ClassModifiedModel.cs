using SP_Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
    public class ClassModifiedModel
    {
        public int Id { get; set; }
        [ClassStartTimeValidator]
        public DateTime StartTime { get; set; } // change start time
                                                // --> must only be changed
                                                // if registration day is not exceed from execution day
        
    }
}
