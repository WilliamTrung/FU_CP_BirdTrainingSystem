using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels
{
//[SlotDetail]:
//+ id : int
//+ trainerId : int
//+ startTime : time
//+ endTime : time
//+ date : date
//+ reason : string
//+ entityTypeId : int
//+ entityId : int
    public class TrainerSlotDetailModel : SlotModels.IClassSlot
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Reason { get; set; } = null!;
        public int EntityTypeId { get; set; }
        public int EntityId { get; set; }
    }
}
