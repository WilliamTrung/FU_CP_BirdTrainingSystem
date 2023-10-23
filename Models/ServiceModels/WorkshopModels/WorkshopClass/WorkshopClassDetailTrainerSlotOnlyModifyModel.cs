using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
//[WorkshopClassDetailTrainerSlotModify]:
//+ id : int
//+ slotId : int
//+ date : date
    public class WorkshopClassDetailTrainerSlotOnlyModifyModel
    {
        public int Id {  get; set; }    
        public int SlotId { get; set; }
        //[SP_Validator.DateOnlyValidator]
        public DateOnly Date { get; set; }  
    }
}
