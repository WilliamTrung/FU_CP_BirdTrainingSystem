using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TimetableModels
{
    public class AbsentModel
    {
        public int TrainerId { get; set; }
        public string? Reason { get; set; }
        public EntityType EntityTypeId { get; } = EntityType.AbsentRequest;
        public TrainerSlotStatus Status { get; } = TrainerSlotStatus.Enabled;
    }
}
