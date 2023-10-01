using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels
{
    public class WorkshopRefundPolicy
    {
        public int TotalDayBeforeStart { get; set; }
        public float RefundRate { get; set; }
    }
}
