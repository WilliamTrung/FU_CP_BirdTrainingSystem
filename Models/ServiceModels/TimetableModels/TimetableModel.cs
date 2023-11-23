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
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; } = null!;
        public int TypeId { get; set; } 
        public Models.Enum.EntityType TypeName { get; set; }
    }
}
