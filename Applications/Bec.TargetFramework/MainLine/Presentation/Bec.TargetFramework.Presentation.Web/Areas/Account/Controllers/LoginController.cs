using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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

                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(model.Password);

                    var taskResult = client.AuthenticateUser(model.Username, System.Convert.ToBase64String(plainTextBytes));

                    if (!taskResult.valid)
                    {
                        TempData["version"] = Settings.OctoVersion;
                        ModelState.AddModelError("", taskResult.validationMessage);
                    }
                    else
                    {
                        //  additional claims are added during signin but not persisted
                        InitialiseUserSession(taskResult.UserAccount);

                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                }
            }

            return View(model);
        }

        private void InitialiseUserSession(Api.Client.Models.UserAccount account)
        {
            //  additional claims are added during signin but not persisted
            BrockAllen.MembershipReboot.UserAccount ua = new BrockAllen.MembershipReboot.UserAccount();

            ua.InjectFrom<NullableInjection>(account);

            authSvc.SignIn(ua, false, null);

            //  create web user object in session
            var userObject = WebUserHelper.CreateWebUserObjectInSession(this.HttpContext, account.ID);

            using (var client = new UserLogicClient())
            {
                client.HttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BusinessServiceBaseURL"]);

                client.SaveUserAccountLoginSession(userObject.UserID, userObject.SessionIdentifier, Request.UserHostAddress, "", "");

            }

            // save login session - needed for authenticated pages extending ApplicationControllerBase
           
            // get all request parameters
            var requestParameters = UserAccountLogicHelper.CreateRequestDictionary(this.Request);

            //BackgroundJob.Enqueue(() => UserAccountLogicHelper.SaveLoginSessionData(userObject.UserID, userObject.SessionIdentifier, requestParameters));
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