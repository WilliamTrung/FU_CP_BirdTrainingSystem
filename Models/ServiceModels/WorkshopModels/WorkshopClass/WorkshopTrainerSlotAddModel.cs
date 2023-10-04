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
        public string Reason = "Host workshop class";
        public int EntityId { get; private set; }
        public int EntityTypeId { get; private set; }

        public WorkshopTrainerSlotAddModel(int workshopClassId)
        {
            EntityId = workshopClassId;
            EntityTypeId = (int)Models.Enum.EntityType.WorkshopClass;
        }
    }
}
