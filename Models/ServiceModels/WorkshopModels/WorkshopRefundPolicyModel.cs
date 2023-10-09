using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels
{
//[WorkshopRefundPolicy] :
//+ id : int
//+ totalDayBeforeStart : int
//+ refundRate
    public class WorkshopRefundPolicyModel
    {
        public int Id { get; set; }
        public int TotalDayBeforeStart { get; set; }
        public float RefundRate { get; set; }
    }
}
