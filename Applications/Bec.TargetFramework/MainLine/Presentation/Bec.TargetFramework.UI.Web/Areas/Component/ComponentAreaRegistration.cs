using System.Web.Mvc;

namespace Bec.TargetFramework.UI.Web.Areas.Component
{
    public class ComponentAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Component";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Component_default",
                "Component/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "Bec.TargetFramework.UI.Web.Areas.Component.Controllers"});
        }
    }
}