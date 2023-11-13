using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
    public class CheckAttendanceCredentials
    {
        public string? Email { get; set; }
        [SP_Validator.PhoneValidator]
        public string? PhoneNumber { get; set; }
    }
}
