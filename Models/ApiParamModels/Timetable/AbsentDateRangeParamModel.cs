using Models.ServiceModels.TimetableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.Timetable
{
    public class AbsentDateRangeParamModel
    {
        public DateOnly From { get; set; }
        public DateOnly To { get; set; }
        public int TrainerId { get; set; }
        public string? Reason { get; set; }
        public AbsentDateRangeModel ToAbsentDateRangeModel()
        {
            return new AbsentDateRangeModel { From = From, To = To, TrainerId = TrainerId, Reason = Reason };
        }
    }
}
