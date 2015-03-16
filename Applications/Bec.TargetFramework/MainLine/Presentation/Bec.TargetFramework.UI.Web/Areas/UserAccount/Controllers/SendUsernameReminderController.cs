using Bec.TargetFramework.UI.Web.Areas.UserAccount.Models;
using BrockAllen.MembershipReboot;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Infrastructure.Log;
using Ext.Net.MVC;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Controllers
{
    [AllowAnonymous]
    public class SendUsernameReminderController : Controller
    {
        UserAccountService userAccountService;

        public SendUsernameReminderController(UserAccountService userAccountService)
        {
            this.userAccountService = userAccountService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SendUsernameReminderInputModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.userAccountService.SendUsernameReminder(model.Email);
                    ViewData["Email"] = model.Email;
                    return RedirectToAction("Success");
                }
                catch (ValidationException ex)
                {
                    return new AjaxResult { ErrorMessage = ex.Message };
                }
            }
            return View();
        }
    }
}
