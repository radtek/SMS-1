using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Areas.UserAccount
{
    public class UserAccountAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UserAccount";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "UserAccount_default",
                "UserAccount/{controller}/{action}/{id}",
                new {controller= "Login",  action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Bec.TargetFramework.Presentation.Areas.UserAccount.Controllers" }
            );
        }
    }
}