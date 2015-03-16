using BrockAllen.MembershipReboot;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Controllers
{
    public class TwoFactorAuthController : ApplicationControllerBase
    {
        UserAccountService userAccountService;

        public TwoFactorAuthController(UserAccountService userAccountService, ILogger logger)
            : base(logger)
        {
            this.userAccountService = userAccountService;
        }

        public ActionResult Index()
        {
            var acct = userAccountService.GetByID(this.User.GetUserID());
            return View(acct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TwoFactorAuthMode mode)
        {
            try
            {
                this.userAccountService.ConfigureTwoFactorAuthentication(this.User.GetUserID(), mode);
                
                ViewData["Message"] = "Update Success";
                
                var acct = userAccountService.GetByID(this.User.GetUserID());
                return View("Index", acct);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            
            return View("Index", userAccountService.GetByID(this.User.GetUserID()));
        }
    }
}
