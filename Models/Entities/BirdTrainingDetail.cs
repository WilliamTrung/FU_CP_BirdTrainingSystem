using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class BirdTrainingDetail
    {
        public int Id { get; set; }
        public int? BirdTrainingProgressId { get; set; }
        public float? Progress { get; set; }
        public string? Comment { get; set; }
        public int? SlotId { get; set; }

        public virtual BirdTrainingProgress? BirdTrainingProgress { get; set; }
    }
}
