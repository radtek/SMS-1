using Bec.TargetFramework.UI.Web.Areas.UserAccount.Models;
using BrockAllen.MembershipReboot;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Controllers
{
    //[Authorize]
    public class ChangePasswordController : ApplicationControllerBase
    {
        UserAccountService userAccountService;
        public ChangePasswordController(UserAccountService userAccountService, ILogger logger)
            : base(logger)
        {
            this.userAccountService = userAccountService;
        }
        
        public ActionResult Index()
        {
            if (!User.HasUserID())
            {
                return new HttpUnauthorizedResult();
            }
            return View(new ChangePasswordInputModel());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ChangePasswordInputModel model)
        {
            if (!User.HasUserID())
            {
                return new HttpUnauthorizedResult();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.userAccountService.ChangePassword(User.GetUserID(), model.OldPassword, model.NewPassword);
                    return View("Success");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }
    }
}
