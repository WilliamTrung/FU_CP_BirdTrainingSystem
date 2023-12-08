using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DashboardModels
{
    public class TransactionModel
    {
        public string PaymentCode { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public double Cost { get; set; }
        public Models.Enum.EntityType Type { get; set; }
    }
}
