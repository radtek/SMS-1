using System;
using System.Globalization;
using System.Web;

namespace Bec.TargetFramework.Infrastructure.Serilog
{
    internal class Utilities
    {
        public static string ExtractRightMostComponents(string value, int rightMostComponents, char separator)
        {
            if (rightMostComponents < 1)
            {
                throw new ArgumentOutOfRangeException("rightMostComponents", rightMostComponents, "rightMostComponents must be atleast 1");
            }

            if (String.IsNullOrEmpty(value))
            {
                return value;
            }

            string[] parts = value.Split(separator);
            rightMostComponents = Math.Min(rightMostComponents, parts.Length);
            string rightMost = String.Join(separator.ToString(CultureInfo.InvariantCulture),
                parts, parts.Length - rightMostComponents, rightMostComponents);
            return rightMost;
        }

        internal static HttpContextBase GetCurrentHttpContext()
        {
            HttpContext httpContext = HttpContext.Current;
            return (httpContext != null) ? new HttpContextWrapper(httpContext) : null;
        }

    }
}