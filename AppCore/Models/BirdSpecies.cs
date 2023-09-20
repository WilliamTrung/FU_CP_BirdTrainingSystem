using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class BirdSpecies
    {
        public BirdSpecies()
        {
            Birds = new HashSet<Bird>();
            TrainingCourses = new HashSet<TrainingCourse>();
            BirdSkills = new HashSet<BirdSkill>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ShortDetailing { get; set; }

        public virtual ICollection<Bird> Birds { get; set; }
        public virtual ICollection<TrainingCourse> TrainingCourses { get; set; }

        public virtual ICollection<BirdSkill> BirdSkills { get; set; }
    }
}
