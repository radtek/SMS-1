using Bec.TargetFramework.Presentation.Web.Filters;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new ContentSecurityPolicyFilterAttribute());
        }
    }
}
