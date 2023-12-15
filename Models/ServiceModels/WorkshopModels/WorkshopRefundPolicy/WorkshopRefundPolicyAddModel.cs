using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopRefundPolicy
{
    public class WorkshopRefundPolicyAddModel
    {
        [SP_Validator.PositiveNumber]
        public int TotalDayBeforeStart { get; set; }
        [SP_Validator.PositiveNumber]
        public float? RefundRate { get; set; }
    }
}
