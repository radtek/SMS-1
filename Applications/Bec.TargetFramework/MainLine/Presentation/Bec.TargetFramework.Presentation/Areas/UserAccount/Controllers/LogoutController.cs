using BrockAllen.MembershipReboot;
using System.Web.Mvc;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.Presentation.Areas.UserAccount.Controllers
{
    using Bec.TargetFramework.Security;

    [AllowAnonymous]
    public class LogoutController : Controller
    {
        AuthenticationService authSvc;
        public LogoutController(AuthenticationService authSvc)
        {
            this.authSvc = authSvc;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                authSvc.SignOut();
                SessionHelper.ClearSession();

                return RedirectToAction("Landing", "Logout", new { area = "UserAccount" });
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult Landing()
        {
            return View();
        }
    }
}
