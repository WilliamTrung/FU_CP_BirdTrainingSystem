﻿namespace Models.Entities
{
    public partial class BirdSpecies
    {
        public BirdSpecies()
        {
            AcquirableSkills = new HashSet<AcquirableSkill>();
            Birds = new HashSet<Bird>();
            TrainingCourses = new HashSet<TrainingCourse>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ShortDetail { get; set; }

        public virtual ICollection<AcquirableSkill> AcquirableSkills { get; set; }
        public virtual ICollection<Bird> Birds { get; set; }
        public virtual ICollection<TrainingCourse> TrainingCourses { get; set; }
    }
}
