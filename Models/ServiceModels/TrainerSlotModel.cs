using Models.ServiceModels.SlotModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels
{
    //[TrainerSlot]:
    //+ id : int
    //+ startTime : time
    //+ endTime : time
    //+ date : date
    //+ reason : string
    public class TrainerSlotModel : IClassSlot
    {
        public int Id { get; set; }
        public string Reason { get; set; } = null!;
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }
}
