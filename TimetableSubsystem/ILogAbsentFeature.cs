using Models.ServiceModels.TimetableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TimetableSubsystem
{
    public interface ILogAbsentFeature
    {
        //Manager log Trainer nghỉ
        //+ chọn ngày:
        //- 1 ngày: * cả ngày
        //               * nửa buổi
        //- nhiều ngày: *from - *to 
        //- Nếu có lịch bận trong duration --> báo lỗi
        Task LogAbsentInDay(AbsentInDayModel absentLog);
        Task LogAbsentDateRange(AbsentDateRangeModel absentLog);
    }
}
