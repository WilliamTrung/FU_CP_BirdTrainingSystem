using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels
{
    public class ModifyTrainerSlot
    {
        public int SlotId { get; set; }
        [SP_Validator.DateOnlyValidator]
        public DateTime Date { get; set; }
    }
}
