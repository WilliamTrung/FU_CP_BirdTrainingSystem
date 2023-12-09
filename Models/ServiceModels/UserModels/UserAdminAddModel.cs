using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.UserModels
{
    public class UserAdminAddModel
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        [SP_Validator.PhoneValidator]
        public string PhoneNumber { get; set; } = null!;
        public string? Avatar { get; set; }
        public string Password { get; set; } = null!;
        public Models.Enum.AdministrativeRole Role { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? GgMeetLink { get; set; }
        public bool? Gender { get; set; }
        public bool? Consultantable { get; set; }
        public bool? IsFulltime { get; set; }
    }
}
