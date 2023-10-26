using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels
{
    public class AdviceConsultingTrainerSlotServiceModel
    {
        public int TrainerId { get; private set; }
        public int SlotId { get; private set; }
        public DateTime Date { get; private set; }
        public int EntityTypeId { get; } = (int)Models.Enum.EntityType.AdviceConsulting;
        public int EntityId { get; private set; }
        public int Status { get; } = (int)Models.Enum.TrainerSlotStatus.Enabled;
        public AdviceConsultingTrainerSlotServiceModel(int trainerId, int slotId, DateTime date, int ticketId)
        {
            TrainerId = trainerId;
            SlotId = slotId;
            Date = date;
            EntityId = ticketId;
        }
    }
}
