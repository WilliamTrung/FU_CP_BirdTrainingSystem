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
        public int TrainingCourseSkillId { get; set; }
        public string BirdSkillName { get; set; } = null!;
        public string? BirdSkillPicture { get; set; }
        public int? TrainerId { get; set; }
        public string? TrainerName { get; set; }
        public string? Evidence { get; set; }
        public double TrainingProgression { get; set; } = 0;
        public int TotalTrainingSlot { get; set; }
        public Models.Enum.BirdTrainingProgress.Status Status { get; set; }
    }
}
