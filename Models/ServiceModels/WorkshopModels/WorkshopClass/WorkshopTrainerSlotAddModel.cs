using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
    public class WorkshopTrainerSlotAddModel
    {
        public int TrainerId { get; set; }
        public int SlotId { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; private set; }
        public int EntityId { get; private set; }
        public Models.Enum.EntityType EntityTypeId { get; private set; }
        public Models.Enum.TrainerSlotStatus Status { get; private set; }

        public WorkshopTrainerSlotAddModel(int workshopClassId)
        {
            EntityId = workshopClassId;
            EntityTypeId = Models.Enum.EntityType.WorkshopClass;
            Reason = "Host workshop class";
            Status = Models.Enum.TrainerSlotStatus.Enabled;
        }
    }
}
