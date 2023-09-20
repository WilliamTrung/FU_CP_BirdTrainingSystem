using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public int ConsultingTicketId { get; set; }
        public int TrainerId { get; set; }
        public int AppointmentBillId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int? SlotStart { get; set; }
        public int? SlotEnd { get; set; }
        public string? Status { get; set; }

        public virtual AppointmentBill AppointmentBill { get; set; } = null!;
        public virtual ConsultingTicket ConsultingTicket { get; set; } = null!;
        public virtual Trainer Trainer { get; set; } = null!;
    }
}
