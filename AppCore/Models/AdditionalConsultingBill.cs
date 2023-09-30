﻿namespace AppCore.Models
{
    public partial class AdditionalConsultingBill
    {
        public int Id { get; set; }
        public int ConsultingTicketId { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Evidence { get; set; }
        public int? Status { get; set; }

        public virtual ConsultingTicket ConsultingTicket { get; set; } = null!;
    }
}
