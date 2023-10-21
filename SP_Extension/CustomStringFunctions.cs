
using Microsoft.EntityFrameworkCore;

namespace SP_Extension
{
    public static class CustomStringFunctions
    {
        [DbFunction("STR_CMP_IGNORE_CASE_WS")]
        public static bool CompareStringsIgnoreCaseAndWhitespace(string str1, string str2)
        {
            if (str1 == null || str2 == null)
                return str1 == str2;

            // Remove whitespace and convert both strings to lowercase
            var cleanedStr1 = new string(str1.Where(c => !Char.IsWhiteSpace(c)).ToArray()).ToLower();
            var cleanedStr2 = new string(str2.Where(c => !Char.IsWhiteSpace(c)).ToArray()).ToLower();

            return cleanedStr1 == cleanedStr2;
        }
    }
}