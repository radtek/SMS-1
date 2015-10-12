using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmsWebsite
{
    public static class Helper
    {
        public static string Conditional(this HtmlHelper htmlHelper, string output, string key, params string[] rh)
        {
            if (rh.Contains(htmlHelper.ViewContext.RouteData.Values[key].ToString()))
                return output;
            else
                return "";
        }
    }
}