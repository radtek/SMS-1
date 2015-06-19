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
using Bec.TargetFramework.Presentation.Web.Base;
using BrockAllen.MembershipReboot;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
{
    [Authorize]
    public class LogoutController : Controller
    {
        public AuthenticationService AuthSvc { get; set; }
        public LogoutController()
        {
        }

        // GET: Account/Logout
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                AuthSvc.SignOut();
                SessionHelper.ClearSession();

                return RedirectToAction("Index", "Login", new { area = "Account" });
            }

            return View();
        }
    }
}