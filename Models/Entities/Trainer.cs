using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class Trainer
    {
        public Trainer()
        {
            BirdTrainingProgresses = new HashSet<BirdTrainingProgress>();
            ConsultingTickets = new HashSet<ConsultingTicket>();
            TrainerSkills = new HashSet<TrainerSkill>();
            TrainerSlots = new HashSet<TrainerSlot>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool? Gender { get; set; }
        public bool IsFullTime { get; set; }
        public string? GgMeetLink { get; set; }
        public bool ConsultantAble { get; set; }
        public int Status { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<BirdTrainingProgress> BirdTrainingProgresses { get; set; }
        public virtual ICollection<ConsultingTicket> ConsultingTickets { get; set; }
        public virtual ICollection<TrainerSkill> TrainerSkills { get; set; }
        public virtual ICollection<TrainerSlot> TrainerSlots { get; set; }
    }
}
