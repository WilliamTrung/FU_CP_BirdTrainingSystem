﻿using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class Trainer
    {
        public Trainer()
        {
            Appointments = new HashSet<Appointment>();
            BirdTrainingProgressDetails = new HashSet<BirdTrainingProgressDetail>();
            ConsultingTickets = new HashSet<ConsultingTicket>();
            TrainerWorkshops = new HashSet<TrainerWorkshop>();
            Skills = new HashSet<Skill>();
            Weeks = new HashSet<Week>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string? TotalWorktime { get; set; }
        public string? Picture { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<BirdTrainingProgressDetail> BirdTrainingProgressDetails { get; set; }
        public virtual ICollection<ConsultingTicket> ConsultingTickets { get; set; }
        public virtual ICollection<TrainerWorkshop> TrainerWorkshops { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Week> Weeks { get; set; }
    }
}
