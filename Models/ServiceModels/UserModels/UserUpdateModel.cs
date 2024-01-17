using Models.Enum;
using SP_Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.UserModels
{
    public class UserUpdateModel
    {        
        public int Id { get; set; }
        public Role Role { get; set; }
        [UsernameValidator(ErrorMessage = "Invalid username\nUsernames can only include letters, numbers, spaces between words, underscores, and must be between 3 and 20 characters")]
        public string? Name { get; set; }
        [EmailValidator(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        [SP_Validator.PhoneValidator]
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; } 
    }
}
