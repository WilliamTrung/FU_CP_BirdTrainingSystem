using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.TrainerSkill
{
    public class TrainableViewSkillModel
    {
        public int BirdSkillId { get; set; }
        public string BirdSkillName { get; set; } = null!;
        public int SkillId { get; set; }
        public string SkillName { get; set; } = null!;
        public string? ShortDescription { get; set; }
    }
}
