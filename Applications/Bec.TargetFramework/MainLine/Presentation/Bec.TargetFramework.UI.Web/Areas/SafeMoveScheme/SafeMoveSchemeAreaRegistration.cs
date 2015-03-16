using System.Web.Mvc;

namespace Bec.TargetFramework.UI.Web.Areas.SafeMoveScheme
{
    public class SafeMoveSchemeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SafeMoveScheme";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SafeMoveScheme_default",
                "SafeMoveScheme/{controller}/{action}/{id}",
                new { controller = "Default", action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "Bec.TargetFramework.UI.Web.Areas.SafeMoveScheme.Controllers"}
            );
        }
    }
}