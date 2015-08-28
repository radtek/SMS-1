using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.BankAccount
{
    public class BankAccountAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BankAccount";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BankAccount_default",
                "BankAccount/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}