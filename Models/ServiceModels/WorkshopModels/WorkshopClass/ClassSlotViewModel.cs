using Models.ServiceModels.SlotModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
    public class ClassSlotViewModel : ClassSlot
    {
        public TrainerModel? Trainer { get; set; }
        public string? Detail { get; set; }


    }
}
