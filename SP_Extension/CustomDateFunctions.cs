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
        [DbFunction("date_cmp_equally")]
        public static bool IsEqualToDate(this DateTime date1, DateTime date2)
        {
            int result = date1.Date.CompareTo(date2.Date);
            return result == 0;
        }
        //-- Define a custom function that compares two dates
        //CREATE OR REPLACE FUNCTION date_cmp_equally(date1 date, date2 date)
        //RETURNS boolean AS $$
        //BEGIN
        //  RETURN date1 = date2;
        //END;
        //$$ LANGUAGE plpgsql;
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
