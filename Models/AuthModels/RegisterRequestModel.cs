﻿using SP_Validator;
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
        [UsernameValidator(ErrorMessage = "Invalid username\nUsernames can only contain letters, numbers, and underscores, and must be between 3-20 characters")]
        public string Name { get; set; } = null!;
        [EmailValidator(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        [PhoneValidator(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; } = null!;

    }
}
