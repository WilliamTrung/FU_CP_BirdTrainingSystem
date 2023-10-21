using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Extension
{
    public static class CustomDateFunctions
    {        
        [DbFunction("DATE_CMP_EQUALLY")]
        public static bool IsEqualToDate(this DateTime date1, DateTime date2)
        {
            int result = date1.Date.CompareTo(date2.Date);
            return result == 0;
        }
        [DbFunction("DATE_CMP")]
        public static int CompareDate(this DateTime date1, DateTime date2)
        {
            int result = date1.Date.CompareTo(date2.Date);
            return result;
        }
        public static DateOnly ToDateOnly(this DateTime date) { 
            return new DateOnly(year: date.Year, month: date.Month, day: date.Day);
        }
    }
}
