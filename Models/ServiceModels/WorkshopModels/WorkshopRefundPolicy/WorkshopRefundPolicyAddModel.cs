using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopRefundPolicy
{
    public class WorkshopRefundPolicyAddModel
    {
        public int TotalDayBeforeStart { get; set; }
        public float? RefundRate { get; set; }
    }
}
