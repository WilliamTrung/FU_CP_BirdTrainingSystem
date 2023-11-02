using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
    public class PreBillingInformation
    {
        public string MembershipName { get; set; } = null!;
        public float DiscountPercent { get; set; }
        public decimal WorkshopPrice { get; set; }
    }
}
