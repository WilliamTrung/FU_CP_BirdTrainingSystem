using Microsoft.EntityFrameworkCore;
using SP_Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Context
{
    public static class AddCustomFunction
    {
        public static void AddMinimalCompareString(this ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(() => CustomStringFunctions.CompareStringsIgnoreCaseAndWhitespace(default, default));
        }
    }
}
