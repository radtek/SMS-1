using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.Presentation.Web.Areas.Account.Models;
using Bec.TargetFramework.Presentation.Web.Models;
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
        private readonly CaptchaService _captchaService;
        public AuthenticationService AuthSvc { get; set; }
        public IUserLogicClient UserLogicClient { get; set; }
        public ITFSettingsLogicClient SettingsClient { get; set; }
        public INotificationLogicClient NotificationLogicClient { get; set; }
        public IOrganisationLogicClient orgClient { get; set; }

        public LoginController()
        {
            _captchaService = new CaptchaService();
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
            var model = new LoginModel
            {
                LoginDTO = new LoginDTO { ReturnUrl = returnUrl }
            };
            return View(model);
        }

        private string EncodePassword(string password)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);

            return System.Convert.ToBase64String(plainTextBytes);
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginModel model)
        {
            TempData["version"] = Settings.OctoVersion;

            if (ModelState.IsValid)
            {
                var loginValidationResult = await UserLogicClient.AuthenticateUserAsync(model.LoginDTO.Email.Trim(), EncodePassword(model.LoginDTO.Password.Trim()));
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
                        msg = "Invalid E-mail or Password";
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
            var userObject = WebUserHelper.CreateWebUserObjectInSession(controller.HttpContext, ua, orgID, uaoID, orgName, needsTc, false);
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


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(LoginModel model)
        {
            TempData["version"] = Settings.OctoVersion;
            model.IsRegistration = true;
            var response = await _captchaService.ValidateCaptcha(Request);
            if (!response.success)
            {
                ModelState.AddModelError("hiddenRecaptcha", "Captcha was not validated.");
                return View("Index", model);
            }

            //check for any subsequent locking of this account
            var tempua = await UserLogicClient.GetUserAccountByUsernameAsync(model.CreatePermanentLoginModel.RegistrationEmail);
            if (!CanContinueRegistration(tempua))
            {
                ModelState.AddModelError("CreatePermanentLoginModel.RegistrationEmail", "This e-mail cannot be registered at the moment.");
                return View("Index", model);
            }

            if (model.CreatePermanentLoginModel.NewPassword != model.CreatePermanentLoginModel.ConfirmNewPassword)
            {
                ModelState.AddModelError("CreatePermanentLoginModel.ConfirmNewPassword", "Passwords do not match");
                return View("Index", model);
            }

            var userAccountOrg = (await UserLogicClient.GetUserAccountOrganisationAsync(tempua.ID)).Single();
            //ViewBag.PINRequired = !string.IsNullOrEmpty(userAccountOrg.PinCode);
            if (model.CreatePermanentLoginModel.Pin != userAccountOrg.PinCode)
            {
                //increment invalid pin count.
                //if pincount >=3, expire organisation
                if (await UserLogicClient.IncrementInvalidPINAsync(userAccountOrg.UserAccountOrganisationID))
                {
                    var commonSettings = (await SettingsClient.GetSettingsAsync()).AsSettings<CommonSettings>();
                    ModelState.AddModelError("CreatePermanentLoginModel.Pin", "Your PIN has now expired due to three invalid attempts. Please contact support on " + commonSettings.SupportTelephoneNumber);
                    //ViewBag.PinExpired = true;
                    ViewBag.PublicWebsiteUrl = commonSettings.PublicWebsiteUrl;
                }
                else
                    ModelState.AddModelError("CreatePermanentLoginModel.Pin", "Invalid PIN");

                return View("Index", model);
            }

            await UserLogicClient.RegisterUserAsync(userAccountOrg.UserAccountOrganisationID, model.CreatePermanentLoginModel.NewPassword);

            LoginController.logout(this, AuthSvc);
            var ua = await UserLogicClient.GetBAUserAccountByUsernameAsync(model.CreatePermanentLoginModel.RegistrationEmail);
            await LoginController.login(this, ua, AuthSvc, UserLogicClient, NotificationLogicClient, orgClient);

            TempData["JustRegistered"] = true;
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EmailCanBeRegistered(string email)
        {
            var canRegister = false;
            if (!string.IsNullOrWhiteSpace(email))
            {
                var uaDTO = await UserLogicClient.GetUserAccountByUsernameAsync(email);
                canRegister = CanContinueRegistration(uaDTO);
            }

            if (!canRegister)
            {
                return Json("This e-mail cannot be registered at the moment.", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("true", JsonRequestBehavior.AllowGet);
            }
        }

        private bool CanContinueRegistration(UserAccountDTO uaDTO)
        {
            return
                uaDTO != null &&
                uaDTO.IsLoginAllowed &&
                uaDTO.IsTemporaryAccount &&
                !Request.IsAuthenticated;
        }


        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
                Logout();
        }
    }
}