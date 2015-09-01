using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.Security;
using BrockAllen.MembershipReboot;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        public AuthenticationService AuthSvc { get; set; }
        public IUserLogicClient UserLogicClient { get; set; }
        public ITFSettingsLogicClient SettingsClient { get; set; }
        public INotificationLogicClient NotificationLogicClient { get; set; }
        public IOrganisationLogicClient orgClient { get; set; }

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
            var commonSettings = SettingsClient.GetSettings().AsSettings<CommonSettings>();
            TempData["version"] = Settings.OctoVersion;

            if (ModelState.IsValid)
            {
                var loginValidationResult = await UserLogicClient.AuthenticateUserAsync(model.Username.Trim(), EncodePassword(model.Password.Trim()));
                var msg = loginValidationResult.validationMessage;

                if (loginValidationResult.valid)
                {
                    var ua = new BrockAllen.MembershipReboot.UserAccount();
                    ua.InjectFrom<NullableInjection>(loginValidationResult.UserAccount);
                    if (await login(this, ua, AuthSvc, UserLogicClient, NotificationLogicClient, orgClient))
                    {
                        if (ua.IsTemporaryAccount)
                        {
                            return RedirectToAction("Index", "Register", new { area = "Account" });
                        }
                        else
                        {
                            // the final landing page is decided inside the Home controller
                            return RedirectToAction("Index", "Home", new { area = "" });
                        }
                    }
                    else
                        msg = "Invalid Username or Password";
                }

                ModelState.AddModelError("", msg);
            }

            return View(model);
        }

        internal static async Task<bool> login(Controller controller, UserAccount ua, AuthenticationService asvc, IUserLogicClient ulc, INotificationLogicClient nlc, IOrganisationLogicClient olc)
        {
            Guid orgID;
            Guid uaoID;
            List<Claim> additionalClaims = new List<Claim>();
            List<VUserAccountOrganisationUserTypeOrganisationTypeDTO> orgs = await ulc.GetUserAccountOrganisationWithUserTypeAndOrgTypeAsync(ua.ID);

            //take the first org for now, in time we may allow user to switch between associated orgs.
            var org = orgs.First();

            orgID = org.OrganisationID;
            uaoID = org.UserAccountOrganisationID;

            var o = await olc.GetOrganisationDTOAsync(orgID);
            if (!o.IsActive) return false;

            foreach (var item in await ulc.GetUserClaimsAsync(ua.ID, orgID))
                additionalClaims.Add(new Claim(item.Type, item.Value));

            if (orgID == null) throw new Exception("User not associated with any organisation");
            string orgName = olc.GetOrganisationDTO(orgID).Name;

            asvc.SignIn(ua, false, additionalClaims);
            bool needsTc = (await nlc.GetUnreadNotificationsAsync(ua.ID, new[] { NotificationConstructEnum.TcPublic, NotificationConstructEnum.TcFirmConveyancing })).Count > 0;
            var userObject = WebUserHelper.CreateWebUserObjectInSession(controller.HttpContext, ua, orgID, uaoID, orgName, needsTc);
            await ulc.SaveUserAccountLoginSessionAsync(userObject.UserID, userObject.SessionIdentifier, controller.Request.UserHostAddress, "", "");

            return true;
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