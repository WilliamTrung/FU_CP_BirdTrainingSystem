using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enum.ConsultingTicket
{
    public enum Status
    {
        Canceled = 0,
        WaitingForAssign = 1,
        WaitingForApprove = 2,
        Confirmed = 3,
        Complete = 4,
        Unpaid = 5
    }
}
