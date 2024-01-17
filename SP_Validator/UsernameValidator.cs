using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SP_Validator
{
    public class UsernameValidator : ValidationAttribute
    {
        //^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$
        //private const string Pattern = @"^[a-zA-Z0-9_]{3,20}$";
        private const string Pattern = @"^(?=[a-zA-Z0-9._]{3,20}$)(?!.*[_.]{2})[^_.].*[^_.]$";
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                // Handle null values according to your requirements

                return ValidationResult.Success;

            }
            else
            {

                string name = value.ToString();

                // Create a Regex object with the pattern
                Regex regex = new Regex(Pattern);

                // Check if the phone number matches the pattern

                if (regex.IsMatch(name))
                {
                    return ValidationResult.Success;
                }

                // Phone number is not valid, return an error message
                return new ValidationResult(ErrorMessage);
            }


        }
    }
}
