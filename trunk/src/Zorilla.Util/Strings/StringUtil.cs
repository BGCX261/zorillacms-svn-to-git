using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zorilla.Util.Strings
{
    public static class StringUtil
    {
        /// <summary>
        /// Extension method for strings which uses the string.IsNullOrEmpty method
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static int IndexOfLastChar(this string s)
        {
            return s.Length - 1;
        }

        public static char LastChar(this string s)
        {
            return s[s.IndexOfLastChar()];
        }

        public static string RemoveLastChar(this string s)
        {
            if (s.IsNullOrEmpty()) return s;
            return s.Remove(s.IndexOfLastChar());
        }

        public static char FirstChar(this string s)
        {
            return s[0];
        }

        public static string RemoveFirstChar(this string s)
        {
            return s.Substring(1, s.Length - 1);
        }
    }
}