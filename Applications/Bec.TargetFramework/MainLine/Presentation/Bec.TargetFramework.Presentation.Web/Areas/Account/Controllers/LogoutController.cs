using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Security;
using Bec.TargetFramework.UI.Process.Base;
using BrockAllen.MembershipReboot;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
{
    public class LogoutController : ApplicationControllerBase
    {
        AuthenticationService authSvc;
        public LogoutController(ILogger logger, AuthenticationService authSvc)
            : base(logger)
        {
            this.authSvc = authSvc;
        }

        // GET: Account/Logout
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                authSvc.SignOut();
                SessionHelper.ClearSession();

                return RedirectToAction("Index", "Login", new { area = "Account" });
            }

            return View();
        }
    }
}