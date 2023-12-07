using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.OnlineCourse
{
    public class PaymentModel
    {
        public int CourseId { get; set; }
        public string PaymentCode { get; set; } = null!;
    }
}
