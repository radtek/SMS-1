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
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Security;
using Bec.TargetFramework.UI.Process.Filters;
using BrockAllen.MembershipReboot;
using Bec.TargetFramework.Infrastructure.Extensions;
using System.Net.Http.Formatting;
using Omu.ValueInjecter;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using Bec.TargetFramework.Presentation.Web.Filters;
using System.Security.Claims;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        public AuthenticationService AuthSvc { get; set; }
        public IUserLogicClient UserLogicClient { get; set; }
        public ITFSettingsLogicClient SettingsClient { get; set; }
        public INotificationLogicClient NotificationLogicClient { get; set; }

        public LoginController()
        {
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
                var loginValidationResult = await UserLogicClient.AuthenticateUserAsync(model.Username, EncodePassword(model.Password));

                if (!loginValidationResult.valid)
                {
                    var commonSettings = SettingsClient.GetSettings().AsSettings<CommonSettings>();
                    TempData["version"] = Settings.OctoVersion;
                    ModelState.AddModelError("", string.Format("{0}. Please contact support on {1}", loginValidationResult.validationMessage, commonSettings.SupportTelephoneNumber));
                }
                else
                {
                    var ua = new BrockAllen.MembershipReboot.UserAccount();
                    ua.InjectFrom<NullableInjection>(loginValidationResult.UserAccount);
                    await login(this, ua, AuthSvc, UserLogicClient, NotificationLogicClient);

                    if (ua.IsTemporaryAccount)
                        return RedirectToAction("Index", "Register", new { area = "Account" });
                    else
                        return RedirectToAction("Index", "Home", new { area = "" });
                }
            }

            return View(model);
        }

        internal static async Task login(Controller controller, UserAccount ua, AuthenticationService asvc, IUserLogicClient ulc, INotificationLogicClient nlc)
        {
            Guid? orgID = null;
            List<Claim> additionalClaims = new List<Claim>();
            List<VUserAccountOrganisationUserTypeOrganisationTypeDTO> orgs = await ulc.GetUserAccountOrganisationWithUserTypeAndOrgTypeAsync(ua.ID);
            foreach (var org in orgs)
            {
                //take the first org for now, in time we may allow user to switch between asoociated orgs.
                orgID = orgID ?? org.OrganisationID;
                foreach (var item in await ulc.GetUserClaimsAsync(ua.ID, org.OrganisationID.Value))
                    additionalClaims.Add(new Claim(item.Type, item.Value));
            }
            if (orgID == null) throw new Exception("User not associated with any organisation");
            asvc.SignIn(ua, false, additionalClaims);
            bool needsTc = (await nlc.GetUnreadNotificationsAsync(ua.ID, "TcPublic")).Count > 0;
            var userObject = WebUserHelper.CreateWebUserObjectInSession(controller.HttpContext, ua, orgID.Value, needsTc);
            await ulc.SaveUserAccountLoginSessionAsync(userObject.UserID, userObject.SessionIdentifier, controller.Request.UserHostAddress, "", "");
        }

        private static async Task<List<Claim>> GenerateUserClaims(Guid userId, IUserLogicClient ulc)
        {
            List<Claim> claims = new List<Claim>();
            List<VUserAccountOrganisationUserTypeOrganisationTypeDTO> orgs = await ulc.GetUserAccountOrganisationWithUserTypeAndOrgTypeAsync(userId);
            foreach (var org in orgs)
            {
                foreach (var item in await ulc.GetUserClaimsAsync(userId, org.OrganisationID.Value))
                    claims.Add(new Claim(item.Type, item.Value));
            }
            return claims;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Logout()
        {
            logout(this, AuthSvc);
        }

        internal static void logout(Controller controller, AuthenticationService asvc)
        {
            FormsAuthentication.SignOut();
            asvc.SignOut();
            controller.HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            controller.Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddYears(-1);
        }

        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
                Logout();
        }
    }
}