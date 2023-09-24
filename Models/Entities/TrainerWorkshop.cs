using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class TrainerWorkshop
    {
        public int TrainerId { get; set; }
        public int WorkshopId { get; set; }
        public DateTime JoinDate { get; set; }

        public virtual Trainer Trainer { get; set; } = null!;
        public virtual Workshop Workshop { get; set; } = null!;
    }
}
