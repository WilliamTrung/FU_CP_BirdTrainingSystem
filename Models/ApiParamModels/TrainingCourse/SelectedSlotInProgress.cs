using Models.ServiceModels.TrainingCourseModels.TrainerSlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.TrainingCourse
{
    public class SelectedSlotInProgress
    {
        public int ProgressId { get; set; }
        public IEnumerable<TrainerSlotParam> TrainerSlotParams { get; set; } = null!;
    }
}
