
using Bec.TargetFramework.Security;
using Bec.TargetFramework.UI.Web.Areas.UserAccount.Models;
using BrockAllen.MembershipReboot;
using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using Bec.TargetFramework.Web.Framework.Helpers;
using Bec.TargetFramework.UI.Process.Filters;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Infrastructure.Log;
using Ext.Net.MVC;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        UserAccountService userAccountService;
        AuthenticationService authSvc;

        public LoginController(AuthenticationService authSvc)
        {
            this.userAccountService = authSvc.UserAccountService;
            this.authSvc = authSvc;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(new LoginInputModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginInputModel model)
        {

            if (ModelState.IsValid)
            {
                BrockAllen.MembershipReboot.UserAccount account;
                if (userAccountService.AuthenticateWithUsernameOrEmail(model.Username, model.Password, out account))
                {
                    // additional claims are added during signin but not persisted
                    Guid organisationID = Guid.Empty; //Temporary fix to build project
                    authSvc.SignIn(account, model.RememberMe, ClaimsHelper.GenerateUserClaims(account.ID, organisationID));

                    // create web user object in session
                    WebUserHelper.CreateWebUserObjectInSession(this.HttpContext, account.ID);

                    // create login record
                    UserAccountLogicHelper.CreateUserAccountLoginLogEntry(this.HttpContext, account.ID);

                    if (account.RequiresTwoFactorAuthCodeToSignIn())
                    {
                        return RedirectToAction("TwoFactorAuthCodeLogin");
                    }
                    if (account.RequiresTwoFactorCertificateToSignIn())
                    {
                        return RedirectToAction("CertificateLogin");
                    }

                    if (userAccountService.IsPasswordExpired(account))
                    {
                        return RedirectToAction("Index", "ChangePassword");
                    }

                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Portal",new {area = ""});
                }
                else
                {
                    return new AjaxResult { ErrorMessage = "Incorrect Username or Password" };
                }
            }

            return View(model);
        }

        public ActionResult TwoFactorAuthCodeLogin()
        {
            if (!User.HasUserID())
            {
                // if the temp cookie is expired, then make the login again
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TwoFactorAuthCodeLogin(string button, TwoFactorAuthInputModel model)
        {
            if (!User.HasUserID())
            {
                // if the temp cookie is expired, then make the login again
                return RedirectToAction("Index");
            }

            if (button == "signin")
            {
                if (ModelState.IsValid)
                {
                    BrockAllen.MembershipReboot.UserAccount account;
                    if (userAccountService.AuthenticateWithCode(this.User.GetUserID(), model.Code, out account))
                    {


                        authSvc.SignIn(account);

                        if (userAccountService.IsPasswordExpired(account))
                        {
                            return RedirectToAction("Index", "ChangePassword");
                        }

                        if (Url.IsLocalUrl(model.ReturnUrl))
                        {
                            return Redirect(model.ReturnUrl);
                        }

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Code");
                    }
                }
            }

            if (button == "resend")
            {
                ModelState.Clear();
                this.userAccountService.SendTwoFactorAuthenticationCode(this.User.GetUserID());
            }

            return View("TwoFactorAuthCodeLogin", model);
        }

        public ActionResult CertificateLogin()
        {
            if (Request.ClientCertificate != null &&
                Request.ClientCertificate.IsPresent &&
                Request.ClientCertificate.IsValid)
            {
                try
                {
                    var cert = new X509Certificate2(Request.ClientCertificate.Certificate);
                    BrockAllen.MembershipReboot.UserAccount account;

                    var result = false;
                    // we're allowing the use of certs for login and for two factor auth. normally you'd 
                    // do only one or the other, but for the sake of the sample we're allowing both.
                    if (User.Identity.IsAuthenticated)
                    {
                        // this is when we're doing cert logins for two factor auth
                        result = this.authSvc.UserAccountService.AuthenticateWithCertificate(User.GetUserID(), cert, out account);
                    }
                    else
                    {
                        // this is when we're just doing certs to login (so no two factor auth)
                        result = this.authSvc.UserAccountService.AuthenticateWithCertificate(cert, out account);
                    }

                    if (result)
                    {
                        this.authSvc.SignIn(account, AuthenticationMethods.X509);

                        if (userAccountService.IsPasswordExpired(account))
                        {
                            return RedirectToAction("Index", "ChangePassword");
                        }

                        return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError("", "Invalid login");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View();
        }
    }
}
