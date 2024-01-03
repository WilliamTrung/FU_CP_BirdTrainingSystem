using SP_Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.AuthModels
{
    public class RegisterRequestModel
    {
        public string Name { get; set; } = null!;
        [EmailValidator(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        [PhoneValidator(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; } = null!;

    }
}
