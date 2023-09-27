using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class ConsultingTicket
    {
        public ConsultingTicket()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ConsultingTypeId { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public int? SlotStart { get; set; }
        public int? SlotEnd { get; set; }
        public string? ConsultingDetail { get; set; }
        public int? Distance { get; set; }
        public int? Status { get; set; }

        public virtual ConsultingType ConsultingType { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
