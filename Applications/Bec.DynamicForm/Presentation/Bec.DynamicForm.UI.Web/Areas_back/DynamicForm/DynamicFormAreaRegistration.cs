using System.Web.Mvc;

namespace Bec.TargetFramework.UI.Web.Areas.Admin
{
    public class DynamicFormAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DynamicForm";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DynamicForm_default",
                "DynamicForm/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "Bec.TargetFramework.UI.Web.Areas.Admin.Controllers"});
        }
    }
}