using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TimetableModels
{
    public class AbsentDateRangeModel : AbsentModel
    {
        //Manager log Trainer nghỉ
        //+ chọn ngày:
        //- nhiều ngày: *from - *to 
        //- Nếu có lịch bận trong duration --> báo lỗi
        public DateOnly From { get; set; }
        public DateOnly To { get; set; }
    }
}
