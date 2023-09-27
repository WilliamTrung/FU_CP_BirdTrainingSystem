using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class Trainer
    {
        public Trainer()
        {
            Appointments = new HashSet<Appointment>();
            BirdTrainingProgresses = new HashSet<BirdTrainingProgress>();
            WorkshopClassDetails = new HashSet<WorkshopClassDetail>();
            Skills = new HashSet<Skill>();
            Weeks = new HashSet<Week>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string? TotalWorktime { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<BirdTrainingProgress> BirdTrainingProgresses { get; set; }
        public virtual ICollection<WorkshopClassDetail> WorkshopClassDetails { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Week> Weeks { get; set; }
    }
}
