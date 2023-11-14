using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels
{
    public class TransactionAddModel
    {
        public int CustomerId { get; set; }
        public string? Title { get; set; }
        public string? Detail { get; set; }
        public int? EntityTypeId { get; set; }
        public int? EntityId { get; set; }
        public decimal? TotalPayment { get; set; }
        public string? PaymentCode { get; set; }
        public int Status { get; set; }
    }
}
