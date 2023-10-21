using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enum.Workshop.Transaction
{
    public enum Status
    {
        Unpaid = 0,
        Paid = 1,
        DemandRefund = 2,
        Refunded = 3,
    }
}
