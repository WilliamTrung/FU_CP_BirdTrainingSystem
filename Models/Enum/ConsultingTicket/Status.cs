using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enum.ConsultingTicket
{
    public enum Status
    {
        Cancelled = 0,
        WaitingForApprove = 1,
        Approved = 2,
        Finished = 3
    }
}
