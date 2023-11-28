using Models.ServiceModels.SlotModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
//[Workshop class]:
//+ id : int
//+ workshopId : int
//+ startTime : date
//+ registerEndDate : date
//+ classSlots : List[WorkshopClassDetail]
    public class WorkshopClassViewModel
    {
        public int Id { get; set; }
        public int WorkshopId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime RegisterEndDate { get; set; }
        public Models.Enum.Workshop.Transaction.Status? Status { get; set; }
        public List<WorkshopClassDetailViewModel> ClassSlots { get; set; } = null!;
        public Models.Enum.Workshop.Class.Status? ClassStatus { get; set; }
        public RegistrationAmountModel? Registered { get; set; }
        public WorkshopClassViewModel AddPaidStatus()
        {
            this.Status = Models.Enum.Workshop.Transaction.Status.Paid;
            return this;
        }
    }
}
