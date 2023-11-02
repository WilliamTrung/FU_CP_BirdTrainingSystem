using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.TrainerSkill
{
    public class TrainerSkillViewModel
    {
        public int TrainerId { get; set; }
        public string TrainerName { get; set; } = null!;
        public int SkillId { get; set; }
        public string SkillName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
