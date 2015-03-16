using System.Web;
using System.Web.Mvc;
using Bec.TargetFramework.Security;
using Bec.TargetFramework.UI.Process.Filters;

namespace Bec.TargetFramework.UI.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
           
            filters.Add(new ClaimsAuthorizeAttribute());
            filters.Add(new PreventMultipleSubmitsActionFilter());
        }
    }
}
