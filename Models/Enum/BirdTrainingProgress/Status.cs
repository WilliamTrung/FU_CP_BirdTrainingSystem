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
        NotPass = 3,
        Pass = 4,
        Cancel = 5
    }
}
