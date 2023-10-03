using Models.ServiceModels.SlotModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
    public class WorkshopClassDetailModifedModel : ClassSlot
    {
        // change detail (optional)
        public string? Detail { get; set; }
        //if want to change trainer --> specified new DaySlot
        

    }    
}
