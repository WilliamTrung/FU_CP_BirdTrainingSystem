using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress
{
    public partial class BirdTrainingProgressModel
    {
        public int Id { get; set; }
        public int BirdTrainingCourseId { get; set; }
        public int TrainingCourseSkillId { get; set; }
        public int TotalTrainingSlot { get; set; }
        public int? TrainerId { get; set; }
        public DateTime? StartTrainingDate { get; set; }
        public DateTime? TrainingDoneDate { get; set; }
        public string? Evidence { get; set; }
        public int Status { get; set; }

        public virtual BirdTrainingCourseModel BirdTrainingCourse { get; set; } = null!;
        public virtual TrainerModel Trainer { get; set; } = null!;
        public virtual TrainingCourseSkillModel TrainingCourseSkill { get; set; } = null!;
        public virtual ICollection<BirdTrainingReportModel> BirdTrainingReports { get; set; }
    }
}