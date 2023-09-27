using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public int ConsultingTicketId { get; set; }
        public int TrainerId { get; set; }
        public int AppointmentBillId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int? SlotStartId { get; set; }
        public string? GgMeetLink { get; set; }
        public int? Status { get; set; }

        public virtual AppointmentBill AppointmentBill { get; set; } = null!;
        public virtual ConsultingTicket ConsultingTicket { get; set; } = null!;
        public virtual Trainer Trainer { get; set; } = null!;
    }
}
