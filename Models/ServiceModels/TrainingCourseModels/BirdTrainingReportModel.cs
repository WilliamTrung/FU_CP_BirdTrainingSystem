using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels
{
    public partial class BirdTrainingReportModel
    {
        public int Id { get; set; }
        public int BirdTrainingCourseId { get; set; }
        public int TrainerId { get; set; }
        public string? Comment { get; set; }
        public float? Progress { get; set; }
        public DateTime DateCreate { get; set; }

        public virtual BirdTrainingCourseModel BirdTrainingCourse { get; set; } = null!;
        public virtual Trainer Trainer { get; set; } = null!;
    }
}
