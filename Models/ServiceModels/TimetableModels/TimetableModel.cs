using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TimetableModels
{
//[TimetableSlot]:
//+ id : int
//+ slotId : int
//+ date : date
//+ reason : string
//+ type : int
    public class TimetableModel
    {
        public int Id { get; set; }
        public int SlotId { get; set; }
        public DateOnly Date { get; set; }
        public string Reason { get; set; } = null!;
        public int Type { get; set; } 
    }
}
