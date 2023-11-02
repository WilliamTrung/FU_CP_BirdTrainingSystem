using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.TrainingCourse
{
    public class AddTrainingSkillModel
    {
        public int BirdSkillId { get; set; }
        public int TrainingCourseId { get; set; }
        public int TotalSlot { get; set; }
    }
}
