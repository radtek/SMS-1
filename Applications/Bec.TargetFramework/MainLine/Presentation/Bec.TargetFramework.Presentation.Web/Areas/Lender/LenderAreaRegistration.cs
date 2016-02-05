using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Lender
{
    public class LenderAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Lender";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Lender_default",
                "Lender/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}