using System.Web.Mvc;

namespace Bec.TargetFramework.UI.Web.Areas.STSLogin
{
    public class STSLoginAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "STSLogin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "STSLogin_default",
                "STSLogin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Bec.TargetFramework.UI.Web.Areas.STSLogin.Controllers"}
            );
        }
    }
}