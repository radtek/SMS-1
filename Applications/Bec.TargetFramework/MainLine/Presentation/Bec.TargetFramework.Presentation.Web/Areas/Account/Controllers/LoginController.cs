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
using Bec.TargetFramework.Web.Framework.Helpers;
using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot;
using Bec.TargetFramework.Web.Framework.Helpers;
using Hangfire;
using Bec.TargetFramework.Infrastructure.Extensions;
using Microsoft.Ajax.Utilities;
using Bec.TargetFramework.Presentation.Web.Api.Client.Clients;
using System.Net.Http.Formatting;
using Omu.ValueInjecter;
using Bec.TargetFramework.Entities;
using UserLoginValidation = Bec.TargetFramework.Presentation.Web.Api.Client.Models.UserLoginValidation;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
{
   
    public class LoginController : Controller
    {
        AuthenticationService authSvc;
        private ILogger logger;
        public LoginController(ILogger logger, AuthenticationService authSvc)
        {
            this.logger = logger;

            this.authSvc = authSvc;
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
                using(var client = new UserLogicClient())
                {
                    client.HttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BusinessServiceBaseURL"]);

                    var taskResult = await client.AuthenticateUserAsync(model.Username, EncodePassword(model.Password));

                    var loginValidationResult = taskResult.Content.ReadAsAsync<UserLoginValidation>();

                    if (!loginValidationResult.Result.valid)
                    {
                        TempData["version"] = Settings.OctoVersion;
                        ModelState.AddModelError("", loginValidationResult.Result.validationMessage);
                    }
                    else
                    {
                        var ua = new BrockAllen.MembershipReboot.UserAccount();

                        ua.InjectFrom<NullableInjection>(loginValidationResult.Result.UserAccount);

                        authSvc.SignIn(ua, false, null);

                        //  create web user object in session
                        var userObject = WebUserHelper.CreateWebUserObjectInSession(this.HttpContext, ua.ID);

                        var result = await client.SaveUserAccountLoginSessionAsync(userObject.UserID, userObject.SessionIdentifier, Request.UserHostAddress, "", "");

                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
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