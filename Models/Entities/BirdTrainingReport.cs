using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class BirdTrainingReport
    {
        public int Id { get; set; }
        public int BirdTrainingCourseId { get; set; }
        public int TrainerId { get; set; }
        public string? Comment { get; set; }
        public float? Progress { get; set; }
        public DateTime DateCreate { get; set; }

        public virtual BirdTrainingCourse BirdTrainingCourse { get; set; } = null!;
        public virtual Trainer Trainer { get; set; } = null!;
    }
}
