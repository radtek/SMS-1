using Bec.TargetFramework.UI.Web.Areas.UserAccount.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using BrockAllen.MembershipReboot;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Infrastructure.Log;
using Ext.Net.MVC;
using System;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Controllers
{
    [AllowAnonymous]
    public class PasswordResetController : Controller
    {
        UserAccountService userAccountService;
        AuthenticationService authenticationService;
        public PasswordResetController(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
            this.userAccountService = authenticationService.UserAccountService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PasswordResetInputModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var account = this.userAccountService.GetByEmail(model.Email);
                    if (account != null)
                    {
                        if (account.PasswordResetSecrets.Count == 0)
                        {
                            this.userAccountService.ResetPassword(model.Email);
                            return RedirectToAction("ResetSuccess");
                        }
                        return RedirectToAction("ResetWithQuestions", new { @id = account.ID.ToString(), @email = model.Email });
                    }
                    else
                    {
                        return new AjaxResult{ ErrorMessage = "Invalid Email"};
                    }
                }
                catch (ValidationException ex)
                {
                    return new AjaxResult{ ErrorMessage = ex.Message};
                }
            }
            return View("Index"); 
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetWithQuestions(PasswordResetWithSecretInputModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var answers = 
                        model.Questions.Select(x=>new PasswordResetQuestionAnswer{QuestionID = x.QuestionID, Answer = x.Answer} );
                    this.userAccountService.ResetPasswordFromSecretQuestionAndAnswer(model.UnprotectedAccountID.Value, answers.ToArray());
                    return View("ResetSuccess");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            var id = model.UnprotectedAccountID;
            if (id != null)
            {
                var account = this.userAccountService.GetByID(id.Value);
                if (account != null)
                {
                    var vm = new PasswordResetWithSecretInputModel(account.ID);
                    vm.Questions =
                        account.PasswordResetSecrets.Select(
                            x => new PasswordResetSecretViewModel
                            {
                                QuestionID = x.PasswordResetSecretID,
                                Question = x.Question
                            }).ToArray();
                    return View("ResetWithQuestions", vm);
                }
            }

            return RedirectToAction("ResetWithSecret");
        }

        public ActionResult Confirm(string id)
        {
            var vm = new ChangePasswordFromResetKeyInputModel()
            {
                Key = id
            };
            return View("Confirm", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm(ChangePasswordFromResetKeyInputModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BrockAllen.MembershipReboot.UserAccount account;
                    if (this.userAccountService.ChangePasswordFromResetKey(model.Key, model.Password, out account))
                    {
                        this.authenticationService.SignIn(account);
                        if (account.RequiresTwoFactorAuthCodeToSignIn())
                        {
                            return RedirectToAction("TwoFactorAuthCodeLogin", "Login");
                        }
                        if (account.RequiresTwoFactorCertificateToSignIn())
                        {
                            return RedirectToAction("CertificateLogin", "Login");
                        }

                        return RedirectToAction("Success");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error changing password. The key might be invalid.");
                    }
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult ResetSuccess()
        {
            return View();
        }
        public ActionResult ResetWithQuestions(string id, string email)
        {
            Guid accountID = new Guid(id);
            var account = this.userAccountService.GetByEmail(email);
            var vm = new PasswordResetWithSecretInputModel(accountID);
            if (account != null)
            {
                vm.Questions =
                    account.PasswordResetSecrets.Select(
                        x => new PasswordResetSecretViewModel
                        {
                            QuestionID = x.PasswordResetSecretID,
                            Question = x.Question
                        }).ToArray();
            }
            return View(vm);
        }
    }
}
