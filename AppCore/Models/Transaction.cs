using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? Title { get; set; }
        public string? Detail { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? EntityTypeId { get; set; }
        public int? EntityId { get; set; }
        public decimal? TotalPayment { get; set; }
        public string? PaymentCode { get; set; }
        public int Status { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}
