using Models.ServiceModels.SlotModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
//[WorkshopClassDetail]:
//+ id : int
//+ detail : string
//+ date : date
//+ startTime : time
//+ endTime : time
//+ trainerModel : [Trainer]
//[Trainer]:
//+ id : int
//+ name : string
//+ email : string
//+ avatar : string

    public class WorkshopClassDetailViewModel : IClassSlot
    {
        public int Id { get; set; }
        public string Detail { get; set; } = null!;
        public TimeSpan? StartTime { get  ; set  ; }
        public TimeSpan? EndTime { get  ; set  ; }
        public DateTime? Date { get  ; set  ; }
        public TrainerWorkshopModel? Trainer { get; set; }
    }
}
