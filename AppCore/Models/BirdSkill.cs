﻿using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class BirdSkill
    {
        public BirdSkill()
        {
            AcquirableSkills = new HashSet<AcquirableSkill>();
            BirdCertificateSkills = new HashSet<BirdCertificateSkill>();
            TrainableSkills = new HashSet<TrainableSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual TrainingCourseSkill? TrainingCourseSkill { get; set; }
        public virtual ICollection<AcquirableSkill> AcquirableSkills { get; set; }
        public virtual ICollection<BirdCertificateSkill> BirdCertificateSkills { get; set; }
        public virtual ICollection<TrainableSkill> TrainableSkills { get; set; }
    }
}
