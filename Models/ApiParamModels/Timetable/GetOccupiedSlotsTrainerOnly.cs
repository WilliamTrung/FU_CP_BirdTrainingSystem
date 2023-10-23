using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.Timetable
{
    public class GetOccupiedSlotsTrainerOnly
    {
        public DateOnly From { get; set; }
        public DateOnly To { get; set; }
    }
}
