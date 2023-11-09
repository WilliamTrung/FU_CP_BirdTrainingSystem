using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enum.BirdTrainingProgress
{
    public enum Status
    {
        WaitingForTimetable = 0,
        WaitingForAssign = 1,
        Assigned = 2,
        Training = 3,
        NotPass = 4,
        Pass = 5,
        Cancel = 6,
    }
}
