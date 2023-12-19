using Models.Enum.Timetable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TimetableModels
{
    //Manager log Trainer nghỉ
    //+ chọn ngày:
    //- 1 ngày: * cả ngày
    //               * nửa buổi
    public class AbsentInDayModel : AbsentModel
    {
        public DateOnly SelectedDate { get; set; }
        public AbsentOption Option { get; set; }
    }
}
