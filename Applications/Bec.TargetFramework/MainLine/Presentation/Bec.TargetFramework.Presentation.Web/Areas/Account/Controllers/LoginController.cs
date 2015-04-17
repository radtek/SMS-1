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
using Microsoft.Ajax.Utilities;
using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot;
using Hangfire;
using Bec.TargetFramework.Infrastructure.Extensions;
using Microsoft.Ajax.Utilities;
using System.Net.Http.Formatting;
using Omu.ValueInjecter;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Business.Client.Interfaces;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
{
   
    public class LoginController : Controller
    {
        AuthenticationService authSvc;
        IUserLogicClient m_UserLogicClient;
        private ILogger logger;
        public LoginController(ILogger logger, AuthenticationService authSvc,IUserLogicClient userClient)
        {
            this.logger = logger;

            this.authSvc = authSvc;

            m_UserLogicClient = userClient;
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
                    ModelState.AddModelError("", loginValidationResult.validationMessage);
                }
                else
                {
                    var ua = new BrockAllen.MembershipReboot.UserAccount();

                    ua.InjectFrom<NullableInjection>(loginValidationResult.UserAccount);

                    authSvc.SignIn(ua, false, null);

                    //  create web user object in session
                    var userObject = WebUserHelper.CreateWebUserObjectInSession(this.HttpContext, ua.ID);

                    await m_UserLogicClient.SaveUserAccountLoginSessionAsync(userObject.UserID, userObject.SessionIdentifier, Request.UserHostAddress, "", "");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }

            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl = "")
        {
            // If the return url starts with a slash "/" we assume it belongs to our site
            // so we will redirect to this "action"
            if (!returnUrl.IsNullOrWhiteSpace() && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            // If we cannot verify if the url is local to our host we redirect to a default location
            return RedirectToAction("Index", "Home");
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