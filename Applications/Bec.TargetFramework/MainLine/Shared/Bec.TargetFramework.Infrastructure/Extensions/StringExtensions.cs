﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveLineBreaks(this string lines)
        {
            return lines.Replace("\r", "").Replace("\n", "");
        }

        public static string ReplaceLineBreaks(this string lines, string replacement)
        {
            return lines.Replace("\r\n", replacement)
                        .Replace("\r", replacement)
                        .Replace("\t", replacement)
                        .Replace("\n", replacement).Trim();
        }

        // string comparison in Entity Framework is limited hence that method
        public static bool EqualsCaseInsensitive(this string value, string other)
        {
            return value.Equals(other.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }

        public static string ValueOr(this string value, string substitute)
        {
            return string.IsNullOrWhiteSpace(value) ? substitute : value;
        }
    }
}
