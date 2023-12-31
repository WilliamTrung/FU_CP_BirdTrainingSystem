﻿using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class BirdTrainingReport
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int BirdTrainingProgressId { get; set; }
        public int TrainerSlotId { get; set; }
        public string? Comment { get; set; }
        public string? Evidence { get; set; }
        public DateTime DateCreate { get; set; }
        public int? Status { get; set; }

        public virtual BirdTrainingProgress BirdTrainingProgress { get; set; } = null!;
        public virtual Trainer Trainer { get; set; } = null!;
        public virtual TrainerSlot TrainerSlot { get; set; } = null!;
    }
}
