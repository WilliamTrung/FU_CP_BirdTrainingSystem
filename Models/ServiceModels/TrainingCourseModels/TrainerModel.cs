using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;

namespace Models.ServiceModels.TrainingCourseModels
{
    public class TrainerModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public List<TrainerSkill.TrainerSkillModel> TrainerSkillModels { get; set; } = null!;
    }
}
