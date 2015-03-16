using Bec.TargetFramework.Security;
using Bec.TargetFramework.UI.Process.Filters;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ClaimsAuthorizeAttribute());
            //filters.Add(new PreventMultipleSubmitsActionFilter());
        }
    }
}
