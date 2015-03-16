using System.IdentityModel.Services;
using System.Security.Permissions;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Security;
using Bec.TargetFramework.UI.Process.Base;
using BrockAllen.MembershipReboot;
using System;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Security;


namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Controllers
{
    public class HomeController : ApplicationControllerBase
    {
        UserAccountService userAccountService;
        AuthenticationService authSvc;

        public HomeController(
            UserAccountService userAccountService, AuthenticationService authSvc,ILogger logger) : base(logger)
        {
            this.userAccountService = userAccountService;
            this.authSvc = authSvc;
        }

        [Authorize()]
        public ActionResult Index()
        {
       
            return View();
        }

       
        [HttpPost]
        public ActionResult Index(string gender)
        {
            if (String.IsNullOrWhiteSpace(gender))
            {
                userAccountService.RemoveClaim(User.GetUserID(), ClaimTypes.Gender);
            }
            else
            {
                // if you only want one of these claim types, uncomment the next line
                //account.RemoveClaim(ClaimTypes.Gender);
                userAccountService.AddClaim(User.GetUserID(), ClaimTypes.Gender, gender);
            }

            // since we've changed the claims, we need to re-issue the cookie that
            // contains the claims.
            authSvc.SignIn(User.GetUserID());

            return RedirectToAction("Index","Portal");
        }

    }
}
