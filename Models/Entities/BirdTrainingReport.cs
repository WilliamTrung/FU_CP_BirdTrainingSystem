using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class BirdTrainingReport
    {
        public int Id { get; set; }
        public int BirdTrainingProgressId { get; set; }
        public int TrainerSlotId { get; set; }
        public string? Comment { get; set; }
        public string? Evidence { get; set; }
        public int? Status { get; set; }

        public virtual BirdTrainingProgress BirdTrainingProgress { get; set; } = null!;
        public virtual TrainerSlot TrainerSlot { get; set; } = null!;
    }
}
