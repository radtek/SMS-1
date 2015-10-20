using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Models;
using BrockAllen.MembershipReboot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
{
    [Authorize]
    [SessionExpireFilter]
    public class RegisterController : Controller
    {
        public AuthenticationService AuthSvc { get; set; }
        public IUserLogicClient UserLogicClient { get; set; }
        public ITFSettingsLogicClient SettingsClient { get; set; }
        public INotificationLogicClient NotificationLogicClient { get; set; }
        public IOrganisationLogicClient orgClient { get; set; }
        public async Task<ActionResult> Index()
        {
            var uaDTO = await UserLogicClient.GetUserAccountByUsernameAsync(HttpContext.User.Identity.Name);
            if (!uaDTO.IsTemporaryAccount)
            {
                LoginController.logout(this, AuthSvc);
                return RedirectToAction("Index", "Login", new { area = "Account" });
            }
            else
            {
                var userAccountOrg = (await UserLogicClient.GetUserAccountOrganisationAsync(uaDTO.ID)).Single();
                ViewBag.PINRequired = !string.IsNullOrEmpty(userAccountOrg.PinCode);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(CreatePermanentLoginModel model)
        {
            //check for any subsequent locking of this account
            var tempua = await UserLogicClient.GetBAUserAccountByUsernameAsync(HttpContext.User.Identity.Name);
            if (!tempua.IsLoginAllowed) return RedirectToAction("Index", "Login", new { area = "Account" });

            if (string.IsNullOrWhiteSpace(model.NewUsername) || await UserLogicClient.IsUserExistAsync(model.NewUsername))
            {
                ModelState.AddModelError("", "This username is unavailable, please chose another");
                return View(model);
            }

            if (model.NewPassword != model.ConfirmNewPassword)
            {
                ModelState.AddModelError("", "Passwords do not match");
                return View(model);
            }

            var userAccountOrg = (await UserLogicClient.GetUserAccountOrganisationAsync(tempua.ID)).Single();
            ViewBag.PINRequired = !string.IsNullOrEmpty(userAccountOrg.PinCode);
            if (model.Pin != userAccountOrg.PinCode)
            {
                //increment invalid pin count.
                //if pincount >=3, expire organisation
                if (await UserLogicClient.IncrementInvalidPINAsync(userAccountOrg.UserAccountOrganisationID))
                {
                    var commonSettings = (await SettingsClient.GetSettingsAsync()).AsSettings<CommonSettings>();
                    ModelState.AddModelError("", "Your PIN has now expired due to three invalid attempts. Please contact support on " + commonSettings.SupportTelephoneNumber);
                    ViewBag.PinExpired = true;
                    ViewBag.PublicWebsiteUrl = commonSettings.PublicWebsiteUrl;
                }
                else
                    ModelState.AddModelError("", "Invalid PIN");

                return View(model);
            }

            await UserLogicClient.RegisterUserAsync(userAccountOrg.OrganisationID, userAccountOrg.UserAccountOrganisationID, model.NewUsername, model.NewPassword);

            LoginController.logout(this, AuthSvc);
            var ua = await UserLogicClient.GetBAUserAccountByUsernameAsync(model.NewUsername);
            await LoginController.login(this, ua, AuthSvc, UserLogicClient, NotificationLogicClient, orgClient);

            TempData["JustRegistered"] = true;
            return RedirectToAction("Index", "Home", new { area = "" });
        }


        //used by client validation
        public async Task<ActionResult> UsernameAvailable(string username)
        {
            if (string.IsNullOrWhiteSpace(username) || await UserLogicClient.IsUserExistAsync(username))
                return Json("This username is unavailable, please chose another", JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}