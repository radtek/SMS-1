﻿using BrockAllen.MembershipReboot;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Controllers
{
    [Authorize]
    public class CloseAccountController : ApplicationControllerBase
    {
        UserAccountService userAccountService;
        public CloseAccountController(UserAccountService userAccountService, ILogger logger)
            : base(logger)
        {
            this.userAccountService = userAccountService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string button)
        {
            if (button == "yes")
            {
                try
                {
                    this.userAccountService.DeleteAccount(User.GetUserID());
                    return RedirectToAction("Index", "Logout");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View();
        }

    }
}
