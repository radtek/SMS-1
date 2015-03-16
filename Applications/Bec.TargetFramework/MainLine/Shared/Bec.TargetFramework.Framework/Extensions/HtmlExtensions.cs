using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Framework.Extensions
{
    public static class HtmlExtensions
    {
        public static IHtmlString LabelWithMark(this HtmlHelper helper, string content)
        {
            string htmlString = String.Format("<label><mark>{0}</mark></label>", content);
            return new HtmlString(htmlString);
        }
    }
}
