using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Validator
{
    public class PositiveNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success; // Null values are considered valid (you can adjust this based on your requirements)
            }

            bool isValid = false;

            if (value is int intValue)
            {
                isValid = intValue > 0;
            }
            else if (value is float floatValue)
            {
                isValid = floatValue > 0;
            }
            else if (value is double doubleValue)
            {
                isValid = doubleValue > 0;
            }
            else if (value is decimal decimalValue)
            {
                isValid = decimalValue > 0;
            }
            else
            {
                // You can add support for other numeric types if needed
                throw new InvalidOperationException("Unsupported numeric type");
            }

            return isValid ? ValidationResult.Success : new ValidationResult("Must be a positive number!");
        }
    }
}
