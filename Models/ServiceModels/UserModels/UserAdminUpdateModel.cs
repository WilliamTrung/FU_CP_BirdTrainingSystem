using Microsoft.AspNetCore.Http;
using Models.Enum;
using SP_Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.UserModels
{
    public class UserAdminUpdateModel
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        [UsernameValidator(ErrorMessage = "Invalid username\nUsernames can only contain letters, numbers, and underscores, and must be between 3-20 characters")]
        public string? Name { get; set; }
        //public string? Email { get; set; }
        [SP_Validator.PhoneValidator]
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public bool? Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool? IsFullTime { get; set; }
        public bool? Consultantable { get; set; }
        public string? GgMeetLink { get; set; }
    }
}
