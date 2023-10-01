using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Validator
{
    public class ClassStartTimeValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime classStartTime)
            {
                DateTime currentDate = DateTime.Now;

                // Calculate the minimum allowed start time as one day or more from the current date.
                DateTime minimumAllowedStartTime = currentDate.AddDays(1);

                if (classStartTime.Date < minimumAllowedStartTime.Date)
                {
                    return new ValidationResult($"Class cannot start before {minimumAllowedStartTime.ToShortDateString()}");
                }
            }

            return ValidationResult.Success;
        }
    }
}
