using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
    public class BillingModel
    {        
        public decimal WorkshopPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal RefundRate { get; set; }
        public string MembershipName { get; set; } = null!;
    }
}
