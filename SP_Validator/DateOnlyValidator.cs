using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Validator
{
    public class DateOnlyValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                // Check if the DateTime is DateOnly (time part is midnight)
                return dateTime.TimeOfDay == TimeSpan.Zero;
            }

            // Not a DateTime, so validation fails
            return false;
        }
    }
}
