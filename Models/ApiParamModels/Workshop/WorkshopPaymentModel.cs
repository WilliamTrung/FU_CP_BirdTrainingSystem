using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.Workshop
{
    public class WorkshopPaymentModel
    {
        public int WorkshopClassId { get; set; }
        public string PaymentCode { get; set; } = null!;
    }
}
