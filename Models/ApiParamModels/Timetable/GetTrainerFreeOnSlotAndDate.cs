using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.Timetable
{
    public class GetTrainerFreeOnSlotAndDate
    {
        public DateOnly date { get; set; }
        public int slotId { get; set; }
    }
}
