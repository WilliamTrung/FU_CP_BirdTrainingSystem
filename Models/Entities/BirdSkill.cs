using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class BirdSkill
    {
        public BirdSkill()
        {
            AcquirableSkills = new HashSet<AcquirableSkill>();
            BirdCertificateSkills = new HashSet<BirdCertificateSkill>();
            TrainableSkills = new HashSet<TrainableSkill>();
            BirdSkillReceiveds = new HashSet<BirdSkillReceived>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Picture { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<TrainingCourseSkill>? TrainingCourseSkills { get; set; }
        public virtual ICollection<AcquirableSkill> AcquirableSkills { get; set; }
        public virtual ICollection<BirdCertificateSkill> BirdCertificateSkills { get; set; }
        public virtual ICollection<TrainableSkill> TrainableSkills { get; set; }
        public virtual ICollection<BirdSkillReceived> BirdSkillReceiveds { get; set; }
    }
}
