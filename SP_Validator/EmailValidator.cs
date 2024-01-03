using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SP_Validator
{
    public class EmailValidator : ValidationAttribute
    {
        private const string Pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                // Handle null values according to your requirements

                return ValidationResult.Success;

            }
            else
            {

                string email = value.ToString();

                // Create a Regex object with the pattern
                Regex regex = new Regex(Pattern);

                // Check if the phone number matches the pattern

                if (regex.IsMatch(email))
                {
                    return ValidationResult.Success;
                }

                // Phone number is not valid, return an error message
                return new ValidationResult(ErrorMessage);
            }


        }
    }
}
