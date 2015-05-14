using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Security;
using Bec.TargetFramework.UI.Process.Filters;
using BrockAllen.MembershipReboot;
using Hangfire;
using Bec.TargetFramework.Infrastructure.Extensions;
using System.Net.Http.Formatting;
using Omu.ValueInjecter;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using Bec.TargetFramework.Presentation.Web.Filters;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        AuthenticationService authSvc;
        IUserLogicClient m_UserLogicClient;
        private ILogger logger;
        private CommonSettings m_CommonSettings;
        IOrganisationLogicClient m_OrgLogicClient;

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            var res = new ViewResult() { ViewName = "Error" };
            res.ViewBag.Message = filterContext.Exception.Message;
            filterContext.Result = res;
        }

        public LoginController(ILogger logger, AuthenticationService authSvc, IUserLogicClient userClient, CommonSettings cSettings, IOrganisationLogicClient orgClient)
        {
            this.logger = logger;

            this.authSvc = authSvc;

            m_UserLogicClient = userClient;
            m_CommonSettings = cSettings;
            m_OrgLogicClient = orgClient;
        }

        [AllowAnonymous]
        public ActionResult LoggedOutByAnother(string returnUrl)
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();
            return View(new LoginDTO { ReturnUrl = returnUrl });
        }

        [AllowAnonymous]
        public ActionResult SessionExpired(string returnUrl)
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();
            return View(new LoginDTO { ReturnUrl = returnUrl });
        }

        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            TempData["version"] = Settings.OctoVersion;
            // We do not want to use any existing identity information
            EnsureLoggedOut();
            return View(new LoginDTO { ReturnUrl = returnUrl });
        }

        private string EncodePassword(string password)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);

            return System.Convert.ToBase64String(plainTextBytes);
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginDTO model)
        {
            var a = Request.ContentType;

            if (ModelState.IsValid)
            {
                var loginValidationResult = await m_UserLogicClient.AuthenticateUserAsync(model.Username, EncodePassword(model.Password));

                if (!loginValidationResult.valid)
                {
                    TempData["version"] = Settings.OctoVersion;
                    ModelState.AddModelError("", string.Format("{0}. Please contact support on {1}", loginValidationResult.validationMessage, m_CommonSettings.SupportTelephoneNumber));
                }
                else
                {
                    var ua = new BrockAllen.MembershipReboot.UserAccount();
                    ua.InjectFrom<NullableInjection>(loginValidationResult.UserAccount);
                    await login(ua);

                    if (ua.IsTemporaryAccount)
                        return RedirectToAction("Register", "Login", new { area = "Account" });
                    else
                        return RedirectToAction("Index", "Home", new { area = "" });
                }
            }

            return View(model);
        }

        private async Task login(UserAccount ua)
        {
            authSvc.SignIn(ua, false, null);
            var userObject = WebUserHelper.CreateWebUserObjectInSession(this.HttpContext, ua.ID);
            await m_UserLogicClient.SaveUserAccountLoginSessionAsync(userObject.UserID, userObject.SessionIdentifier, Request.UserHostAddress, "", "");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(CreatePermanentLoginDTO model)
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

            var uaDTO = m_UserLogicClient.GetUserAccountByUsername(HttpContext.User.Identity.Name);
            var userAccountOrg = m_UserLogicClient.GetUserAccountOrganisation(uaDTO.ID).Single();
            if(model.Pin != userAccountOrg.Organisation.CompanyPinCode)
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

            Logout();
            var ua = m_UserLogicClient.GetBAUserAccountByUsername(model.NewUsername);
            await login(ua);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Logout()
        {
            FormsAuthentication.SignOut();

            authSvc.SignOut();

            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

            Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddYears(-1);

        }

        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
                Logout();
        }
    }
}