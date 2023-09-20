using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class TrainingCourseBirdSkill
    {
        public TrainingCourseBirdSkill()
        {
            BirdTrainingProgressDetails = new HashSet<BirdTrainingProgressDetail>();
        }

        public int TrainingCourseId { get; set; }
        public int BirdSkillId { get; set; }
        public decimal? Price { get; set; }

        public virtual BirdSkill BirdSkill { get; set; } = null!;
        public virtual TrainingCourse TrainingCourse { get; set; } = null!;
        public virtual ICollection<BirdTrainingProgressDetail> BirdTrainingProgressDetails { get; set; }
    }
}
