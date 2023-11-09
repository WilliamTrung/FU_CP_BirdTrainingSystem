using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.TrainerSlot
{
    public class TrainerSlotAddModel
    {
        public int SlotId { get; set; }
        public DateTime Date { get; set; }
        public string? Reason { get; set; }
        public int EntityTypeId { get; set; }
        public int? EntityId { get; set; }
    }
}
