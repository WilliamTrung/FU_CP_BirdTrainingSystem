using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enum.ConsultingTicket
{
    public enum Status
    {
        UnAssigned = 0,
        Denied = 1,
        IsAssginedAndIsNotPaid = 2,
        IsAssginedAndIsPaid = 3,
        IsHappening = 4,
        IsFinished = 5,
    }
}
