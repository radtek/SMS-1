using System.Web.Mvc;

namespace Bec.TargetFramework.UI.Web.Areas.SafeTransactionSearch
{
    public class SafeTransactionSearchAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SafeTransactionSearch";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SafeTransactionSearch_default",
                "SafeTransactionSearch/{controller}/{action}/{id}",
                new {  controller = "SignUp", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Bec.TargetFramework.UI.Web.Areas.SafeTransactionSearch.Controllers" }
            );
        }
    }
}