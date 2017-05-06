using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DJLNET.Core.Extension
{
    /// <summary>Provides methods to manipulate strings. </summary>
    public static class StringExtensions
    {
        /// <summary>Trims a string from the start of the input string. </summary>
        /// <param name="input">The input string. </param>
        /// <param name="trimString">The string to trim. </param>
        /// <returns>The trimmed string. </returns>
        public static string TrimStart(this string input, string trimString)
        {
            var result = input;
            while (result.StartsWith(trimString))
            {
                result = result.Substring(trimString.Length);
            }
            return result;
        }

        /// <summary>Trims a string from the end of the input string. </summary>
        /// <param name="input">The input string. </param>
        /// <param name="trimString">The string to trim. </param>
        /// <returns>The trimmed string. </returns>
        public static string TrimEnd(this string input, string trimString)
        {
            var result = input;
            while (result.EndsWith(trimString))
            {
                result = result.Substring(0, result.Length - trimString.Length);
            }
            return result;
        }

        /// <summary>Trims a string from the start and end of the input string. </summary>
        /// <param name="input">The input string. </param>
        /// <param name="trimString">The string to trim. </param>
        /// <returns>The trimmed string. </returns>
        public static string Trim(this string input, string trimString)
        {
            return input.TrimStart(trimString).TrimEnd(trimString);
        }


        public static string FirstCharToUpper(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        /// <summary>
        /// 转全角(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        public static string ToSBC(this string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }
        /// <summary>
        /// 转半角(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        public static string ToDBC(this string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static string Format(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public static bool IsMatch(this string s, string pattern)
        {
            if (s == null) return false;
            else return Regex.IsMatch(s, pattern);
        }

        public static string Match(this string s, string pattern)
        {
            if (s == null) return string.Empty;
            return Regex.Match(s, pattern).Value;
        }

        public static bool IsInt(this string s)
        {
            int i;
            return int.TryParse(s, out i);
        }

        public static int ToInt(this string s)
        {
            return int.Parse(s);
        }

        public static string ToCamel(this string s)
        {
            if (s.IsNullOrEmpty()) return s;
            return s[0].ToString().ToLower() + s.Substring(1);
        }

        public static string ToPascal(this string s)
        {
            if (s.IsNullOrEmpty()) return s;
            return s[0].ToString().ToUpper() + s.Substring(1);
        }
    }
}
