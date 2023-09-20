using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class Week
    {
        public Week()
        {
            Days = new HashSet<Day>();
            Trainers = new HashSet<Trainer>();
        }

        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Day> Days { get; set; }

        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
