using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
    public class BillingModel
    {        
        public int WorkshopClassId { get; set; }
        public string WorkshopTitle { get; set; } = null!;
        public decimal WorkshopPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public float DiscountRate { get; set; }
        public string MembershipName { get; set; } = null!;
    }
}
