using Models.ServiceModels.SlotModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
    public class ClassSlotModifedModel : ClassSlot
    {
        // change detail (optional)
        public string? Detail { get; set; }
        // change trainer --> change trainerId
        public int? TrainerId { get; set; } 

    }    
}
