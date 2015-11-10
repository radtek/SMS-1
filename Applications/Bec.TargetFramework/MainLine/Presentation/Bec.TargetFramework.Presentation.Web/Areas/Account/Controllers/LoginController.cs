using Bec.TargetFramework.Infrastructure.Extensions;
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
using Bec.TargetFramework.Infrastructure.Helpers;

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

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginModel model)
        {
            TempData["version"] = Settings.OctoVersion;

            if (ModelState.IsValid)
            {
                string errorMessage;
                if (TryLogin(this, AuthSvc, model.LoginDTO.Email, model.LoginDTO.Password, UserLogicClient, NotificationLogicClient, orgClient, out errorMessage))
                {
                    // the final landing page is decided inside the Home controller
                    return RedirectToAction("Index", "App", new { area = "" });
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(errorMessage))
                    {
                        errorMessage = "Invalid E-mail or Password";
                    }

                    ModelState.AddModelError("", errorMessage);
                }
            }

            return View(model);
        }

        internal static bool TryLogin(Controller controller, AuthenticationService asvc, string username, string password, IUserLogicClient ulc,
            INotificationLogicClient nlc, IOrganisationLogicClient olc, out string errorMessage)
        {
            errorMessage = string.Empty;
            var loginValidationResult = ulc.AuthenticateUser(username.Trim(), EncodingHelper.Base64Encode(password.Trim()));
            if (!loginValidationResult.valid)
            {
                errorMessage = loginValidationResult.validationMessage;
                return false;
            }
            var ua = new BrockAllen.MembershipReboot.UserAccount();
            ua.InjectFrom<NullableInjection>(loginValidationResult.UserAccount);

            var orgs = ulc.GetUserAccountOrganisationWithUserTypeAndOrgType(ua.ID);
            //take the first org for now, in time we may allow user to switch between associated orgs.
            var org = orgs.First();

            var orgID = org.OrganisationID;
            var uaoID = org.UserAccountOrganisationID;
            if (orgID == null)
            {
                throw new Exception("User not associated with any organisation");
            }

            var o = olc.GetOrganisationDTO(orgID);
            if (!o.IsActive)
            {
                return false;
            }

            string orgName = olc.GetOrganisationDTO(orgID).Name;

            var additionalClaims = ulc.GetUserClaims(ua.ID, orgID)
                .Select(uc => new Claim(uc.Type, uc.Value))
                .ToList();

            asvc.SignIn(ua, false, additionalClaims);
            bool needsTc = (nlc.GetUnreadNotifications(ua.ID, new[] { NotificationConstructEnum.TcPublic, NotificationConstructEnum.TcFirmConveyancing })).Count > 0;
            bool needsPersonalDetails = org.UserTypeID == UserTypeEnum.OrganisationAdministrator.GetGuidValue(); // require personal details from all admins initially, personal details are checked at the next stage

            var userObject = WebUserHelper.CreateWebUserObjectInSession(controller.HttpContext, ua, orgID, uaoID, orgName, needsTc, needsPersonalDetails);
            ulc.SaveUserAccountLoginSession(userObject.UserID, userObject.SessionIdentifier, controller.Request.UserHostAddress, "", "");

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
            var userAccount = await UserLogicClient.GetUserAccountByUsernameAsync(model.CreatePermanentLoginModel.RegistrationEmail);
            if (!CanContinueRegistration(userAccount))
            {
                ModelState.AddModelError("CreatePermanentLoginModel.RegistrationEmail", "This e-mail cannot be registered at the moment.");
                return View("Index", model);
            }

            if (model.CreatePermanentLoginModel.NewPassword != model.CreatePermanentLoginModel.ConfirmNewPassword)
            {
                ModelState.AddModelError("CreatePermanentLoginModel.ConfirmNewPassword", "Passwords do not match");
                return View("Index", model);
            }

            var uaoDto = (await UserLogicClient.GetUserAccountOrganisationAsync(userAccount.ID)).Single();
            if (!IsPinValid(uaoDto, model.CreatePermanentLoginModel.Pin))
            {
                //increment invalid pin count.
                //if pincount >=3, expire organisation
                if (await UserLogicClient.IncrementInvalidPINAsync(uaoDto.UserAccountOrganisationID))
                {
                    var commonSettings = (await SettingsClient.GetSettingsAsync()).AsSettings<CommonSettings>();
                    ViewBag.Message = string.Format("Your PIN has now expired due to three invalid attempts. Please contact support at ");
                    ViewBag.Email = SettingsClient.GetSettings().AsSettings<CommonSettings>().SupportEmailAddress;
                    return View("PINExpired");
                }
                else
                {
                    ModelState.AddModelError("CreatePermanentLoginModel.Pin", "Invalid PIN");
                }

                return View("Index", model);
            }

            await UserLogicClient.RegisterUserAsync(uaoDto.UserAccountOrganisationID, model.CreatePermanentLoginModel.PhoneNumber, model.CreatePermanentLoginModel.NewPassword);

            LoginController.logout(this, AuthSvc);

            string errorMessage;
            if (!TryLogin(this, AuthSvc, model.CreatePermanentLoginModel.RegistrationEmail, model.CreatePermanentLoginModel.NewPassword,
                UserLogicClient, NotificationLogicClient, orgClient, out errorMessage))
            {
                throw new Exception(string.Format("Authentication failed for the user. {0}", errorMessage));
            }

            TempData["JustRegistered"] = true;
            return RedirectToAction("Index", "App", new { area = "" });
        }

        private bool IsPinValid(UserAccountOrganisationDTO uaoDto, string pin)
        {
            return !string.IsNullOrWhiteSpace(uaoDto.PinCode) && pin == uaoDto.PinCode;
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