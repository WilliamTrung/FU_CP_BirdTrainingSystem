using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enum.ConsultingTicket
{
    public enum Status
    {
        WaitForApprove = 0,
        Scheduled = 1,
        IsHappening = 2,
        NotPaidFull = 3,
        PaidFull = 4
    }
}
