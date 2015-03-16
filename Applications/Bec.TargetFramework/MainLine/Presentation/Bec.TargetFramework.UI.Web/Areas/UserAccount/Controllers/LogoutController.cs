using BrockAllen.MembershipReboot;
using System.Web.Mvc;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Controllers
{
    using Bec.TargetFramework.Security;

    public class LogoutController : Controller
    {
        AuthenticationService authSvc;
        public LogoutController(AuthenticationService authSvc)
        {
            this.authSvc = authSvc;
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                authSvc.SignOut();
                SessionHelper.ClearSession();

                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }

    }
}
