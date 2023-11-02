using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress
{
    public class BirdTrainingProgressViewModel
    {
        public int Id { get; set; }
        public int BirdTrainingCourseId { get; set; }
        public string SkillName { get; set; }
        public int? TrainerId { get; set; }
        public string? TrainerName { get; set; }
        public string? Evidence { get; set; }
        public Models.Enum.BirdTrainingProgress.Status Status { get; set; }
    }
}
