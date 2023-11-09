using Models.ServiceModels.SlotModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.TrainerSlot
{
    public class TrainerSlotModel
    {
        public int Id { get; set; }
        public int? TrainerId { get; set; }
        public int SlotId { get; set; }
        public DateTime Date { get; set; }
        public string? Reason { get; set; }
        public int EntityTypeId { get; set; }
        public int? EntityId { get; set; }
        public int Status { get; set; } = (int)Enum.TrainerSlotStatus.Enabled;

        public virtual SlotModel Slot { get; set; } = null!;
        public virtual TrainerModel Trainer { get; set; } = null!;
        public virtual ICollection<BirdTrainingReportModel> BirdTrainingReports { get; set; }
    }
}