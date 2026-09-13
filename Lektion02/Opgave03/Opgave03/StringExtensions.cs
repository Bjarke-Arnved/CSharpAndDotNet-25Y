using System;
using System.Collections.Generic;
using System.Text;

namespace Opgave03
{
    public static class StringExtensions
    {
        public static string ToLeetSpeak(this string str)
        {
            str.ToLower();
            StringBuilder leetStringBuilder = new(str);
                leetStringBuilder.Replace('a', '4');
                leetStringBuilder.Replace('e', '3');
                leetStringBuilder.Replace('i', '1');
                leetStringBuilder.Replace('l', '1');
                leetStringBuilder.Replace('o', '0');
                leetStringBuilder.Replace('s', '5');
                leetStringBuilder.Replace('t', '7');
            return leetStringBuilder.ToString();
        }
    }
}
