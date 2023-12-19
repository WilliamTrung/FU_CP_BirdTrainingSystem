using Models.Enum.Timetable;
using Models.ServiceModels.TimetableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.Timetable
{
    public class AbsentInDayParamModel
    {
        public DateOnly SelectedDate { get; set; }
        public AbsentOption Option { get; set; }
        public int TrainerId { get; set; }
        public string? Reason { get; set; }
        public AbsentInDayModel ToAbsentInDayModel()
        {
            return new AbsentInDayModel() { Reason = Reason, TrainerId = TrainerId, SelectedDate = SelectedDate, Option = Option };
        }
    }
}
