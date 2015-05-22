using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
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
        AuthenticationService authSvc;
        IUserLogicClient m_UserLogicClient;
        private CommonSettings m_CommonSettings;
        IOrganisationLogicClient m_OrgLogicClient;
        INotificationLogicClient m_NotificationLogicClient;
        public RegisterController(AuthenticationService authSvc, IUserLogicClient userClient, CommonSettings cSettings, IOrganisationLogicClient orgClient, INotificationLogicClient nClient)
        {
            this.authSvc = authSvc;

            m_UserLogicClient = userClient;
            m_CommonSettings = cSettings;
            m_OrgLogicClient = orgClient;
            m_NotificationLogicClient = nClient;
        }

        public ActionResult Index()
        {
            var uaDTO = m_UserLogicClient.GetUserAccountByUsername(HttpContext.User.Identity.Name);
            if (!uaDTO.IsTemporaryAccount)
            {
                LoginController.logout(this, authSvc);
                return RedirectToAction("Index", "Login", new { area = "Account" });
            }
            else
                return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(CreatePermanentLoginDTO model)
        {
            if (string.IsNullOrWhiteSpace(model.NewUsername) || await m_UserLogicClient.IsUserExistAsync(model.NewUsername))
            {
                ModelState.AddModelError("", "This username is unavailable, please chose another");
                return View(model);
            }

            if (model.NewPassword != model.ConfirmNewPassword)
            {
                ModelState.AddModelError("", "Passwords do not match");
                return View(model);
            }

            var userObject = Session[WebUserHelper.m_WEBUSEROBJECTSESSIONKEY] as WebUserObject;
            var userAccountOrg = m_UserLogicClient.GetUserAccountOrganisation(userObject.UserID).Single();
            if (model.Pin != userAccountOrg.Organisation.CompanyPinCode)
            {
                //increment invalid pin count.
                //if pincount >=3, expire organisation
                if (m_OrgLogicClient.IncrementInvalidPIN(userAccountOrg.OrganisationID))
                {
                    ModelState.AddModelError("", "Your PIN has now expired due to three invalid attempts. Please contact support on " + m_CommonSettings.SupportTelephoneNumber);
                    ViewBag.PinExpired = true;
                    ViewBag.PublicWebsiteUrl = m_CommonSettings.PublicWebsiteUrl;
                }
                else
                    ModelState.AddModelError("", "Invalid PIN");

                return View(model);
            }

            var contact = m_UserLogicClient.GetUserAccountOrganisationPrimaryContact(userAccountOrg.UserAccountOrganisationID);
            m_OrgLogicClient.AddNewUserToOrganisation(userAccountOrg.OrganisationID, UserTypeEnum.OrganisationAdministrator, model.NewUsername, model.NewPassword, false, contact);
            m_OrgLogicClient.ActivateOrganisation(userAccountOrg.OrganisationID);
            //delete original temp user account
            var tempua = m_UserLogicClient.GetBAUserAccountByUsername(HttpContext.User.Identity.Name);
            m_UserLogicClient.LockUserTemporaryAccount(tempua.ID);

            LoginController.logout(this, authSvc);
            var ua = m_UserLogicClient.GetBAUserAccountByUsername(model.NewUsername);
            await LoginController.login(this, ua, authSvc, m_UserLogicClient, m_NotificationLogicClient);
            return RedirectToAction("Index", "Home", new { area = "" });
        }


        //used by client validation
        public async Task<ActionResult> UsernameAvailable(string username)
        {
            if (string.IsNullOrWhiteSpace(username) || await m_UserLogicClient.IsUserExistAsync(username))
                return Json("This username is unavailable, please chose another", JsonRequestBehavior.AllowGet);
            else
                return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}