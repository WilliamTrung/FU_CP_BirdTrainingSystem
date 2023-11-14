using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.BirdSkill
{
    public class AcquirableAddModBirdSkill
    {
        public int BirdSpeciesId { get; set; }
        public int BirdSkillId { get; set; }
        public string? Condition { get; set; }
    }
}
