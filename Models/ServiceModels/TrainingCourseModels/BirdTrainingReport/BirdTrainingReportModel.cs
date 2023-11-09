using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.TrainerSlot;
using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels.BirdTrainingReport
{
    public partial class BirdTrainingReportModel
    {
        public int Id { get; set; }
        public int BirdTrainingProgressId { get; set; }
        public int TrainerSlotId { get; set; }
        public string? Comment { get; set; }
        public string? Evidence { get; set; }
        public int? Status { get; set; }

        public virtual BirdTrainingProgressModel BirdTrainingProgress { get; set; } = null!;
        public virtual TrainerSlotModel TrainerSlot { get; set; } = null!;
    }
}
