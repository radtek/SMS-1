// todo: ZM delete
////using Bec.TargetFramework.Business.Client.Interfaces;
////using Bec.TargetFramework.Entities;
////using Bec.TargetFramework.Infrastructure;
////using Bec.TargetFramework.Infrastructure.Settings;
////using Bec.TargetFramework.Presentation.Web.Models;
////using BrockAllen.MembershipReboot;
////using System.Linq;
////using System.Threading.Tasks;
////using System.Web.Mvc;

////namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
////{
////    [AllowAnonymous]
////    public class RegisterController : Controller
////    {
////        private readonly CaptchaService _captchaService;
////        public AuthenticationService AuthSvc { get; set; }
////        public IUserLogicClient UserLogicClient { get; set; }
////        public ITFSettingsLogicClient SettingsClient { get; set; }
////        public INotificationLogicClient NotificationLogicClient { get; set; }
////        public IOrganisationLogicClient orgClient { get; set; }

////        public RegisterController()
////        {
////            _captchaService = new CaptchaService();
////        }

////        //public async Task<ActionResult> Index(string registrationEmail)
////        //{
////        //    var uaDTO = await UserLogicClient.GetUserAccountByUsernameAsync(registrationEmail);
////        //    if (!CanContinueRegistration(uaDTO))
////        //    {
////        //        LoginController.logout(this, AuthSvc);
////        //        return RedirectToAction("Index", "Login", new { area = "Account" });
////        //    }
////        //    else
////        //    {
////        //        var userAccountOrg = (await UserLogicClient.GetUserAccountOrganisationAsync(uaDTO.ID)).Single();
////        //        ViewBag.PINRequired = !string.IsNullOrEmpty(userAccountOrg.PinCode);
////        //        var model = new CreatePermanentLoginModel
////        //        {
////        //            Email = registrationEmail
////        //        };
////        //        return View(model);
////        //    }
////        //}

////        [HttpPost]
////        [ValidateAntiForgeryToken]
////        public async Task<ActionResult> Index(CreatePermanentLoginModel model)
////        {
////            var response = await _captchaService.ValidateCaptcha(Request);
////            if (!response.success)
////            {
////                ModelState.AddModelError("", "Captcha was not validated.");
////                return View("Login/Index", model);
////            }

////            //check for any subsequent locking of this account
////            var tempua = await UserLogicClient.GetUserAccountByUsernameAsync(model.Email);
////            if (!CanContinueRegistration(tempua)) return RedirectToAction("Index", "Login", new { area = "Account" });

////            if (model.NewPassword != model.ConfirmNewPassword)
////            {
////                ModelState.AddModelError("", "Passwords do not match");
////                return View("Login/Index", model);
////            }

////            var userAccountOrg = (await UserLogicClient.GetUserAccountOrganisationAsync(tempua.ID)).Single();
////            ViewBag.PINRequired = !string.IsNullOrEmpty(userAccountOrg.PinCode);
////            if (model.Pin != userAccountOrg.PinCode)
////            {
////                //increment invalid pin count.
////                //if pincount >=3, expire organisation
////                if (await UserLogicClient.IncrementInvalidPINAsync(userAccountOrg.UserAccountOrganisationID))
////                {
////                    var commonSettings = (await SettingsClient.GetSettingsAsync()).AsSettings<CommonSettings>();
////                    ModelState.AddModelError("", "Your PIN has now expired due to three invalid attempts. Please contact support on " + commonSettings.SupportTelephoneNumber);
////                    ViewBag.PinExpired = true;
////                    ViewBag.PublicWebsiteUrl = commonSettings.PublicWebsiteUrl;
////                }
////                else
////                    ModelState.AddModelError("", "Invalid PIN");

////                return View("Login/Index", model);
////            }

////            await UserLogicClient.RegisterUserAsync(userAccountOrg.UserAccountOrganisationID, model.NewPassword);

////            LoginController.logout(this, AuthSvc);
////            var ua = await UserLogicClient.GetBAUserAccountByUsernameAsync(model.Email);
////            await LoginController.login(this, ua, AuthSvc, UserLogicClient, NotificationLogicClient, orgClient);
////            return RedirectToAction("Index", "Home", new { area = "" });
////        }

//            LoginController.logout(this, AuthSvc);
//            var ua = await UserLogicClient.GetBAUserAccountByUsernameAsync(model.NewUsername);
//            await LoginController.login(this, ua, AuthSvc, UserLogicClient, NotificationLogicClient, orgClient);

//            TempData["JustRegistered"] = true;
//            return RedirectToAction("Index", "Home", new { area = "" });
//        }

////            if (!canRegister)
////            {
////                return Json("This e-mail cannot be registered at the moment.", JsonRequestBehavior.AllowGet);
////            }
////            else
////            {
////                return Json("true", JsonRequestBehavior.AllowGet);
////            }
////        }

////        private bool CanContinueRegistration(UserAccountDTO uaDTO)
////        {
////            return 
////                uaDTO != null && 
////                uaDTO.IsLoginAllowed && 
////                uaDTO.IsTemporaryAccount && 
////                !Request.IsAuthenticated;
////        }
////    }
////}