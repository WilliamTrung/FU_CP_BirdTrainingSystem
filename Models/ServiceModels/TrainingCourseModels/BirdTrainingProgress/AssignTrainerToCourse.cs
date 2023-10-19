using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress
{
    public class AssignTrainerToCourse
    {
        public int Id { get; set; }
        public int BirdTrainingCourseId { get; set; }
        public int TrainingCourseSkillId { get; set; }
        public int TrainerId { get; set; }
    }
}