using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enum.BirdTrainingProgress
{
    public enum Status
    {
        WaitingForAssign = 0,
        Assigned = 1,
        Training = 2,
        Complete = 3,
        Cancel = 4
    }
}
