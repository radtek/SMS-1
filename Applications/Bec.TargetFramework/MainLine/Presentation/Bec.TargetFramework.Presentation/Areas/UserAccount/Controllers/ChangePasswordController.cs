using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Workflow;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Entities.Validators;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Infrastructure.EventSource;
using BrockAllen.MembershipReboot;
using Ext.Net;
using Ext.Net.MVC;
using Fabrik.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.UI.Web.Areas.STSLogin.Controllers
{
    //[Authorize]

    public class ChangePasswordController : Controller
    {
        UserAccountService userAccountService;
        public ChangePasswordController(UserAccountService userAccountService, ILogger logger)
          
        {
            this.userAccountService = userAccountService;
        }
        public ActionResult Success()
        {
            return View("Success");
        }
        public ActionResult Index(string id)
        {
            if(id == null)
            {
                return new HttpUnauthorizedResult();
            }
            ViewData["PublicKey"] = ConfigurationManager.AppSettings["ReCaptchaPublicKey"];
            ViewData["Response"] = "";
            ViewData["Challenge"] = "";
            ViewData["id"] = id;

            var model = new ChangePasswordWithSecretDTO();
            BrockAllen.MembershipReboot.UserAccount account = userAccountService.GetByVerificationKey(id);
            if(account != null && account.IsTemporaryAccount == false)
                if (account.PasswordResetSecrets.Count > 0)
                {
                    var randomQuestion = account.RandomSecurityQuestion();
                    model.QuestionID = randomQuestion.PasswordResetSecretID;
                    model.Question = randomQuestion.Question;

                    var control = this.GetCmp<Label>("question");
                    control.Text = model.Question;
                    control.Update();

                    var hiddenField = this.GetCmp<Hidden>("questionID");
                    hiddenField.Value = model.QuestionID;
                    hiddenField.Update();
                }
            Session.Add("UserAccount", account);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ChangePasswordWithSecretDTO model, string CaptchaChallenge, string CaptchaResponse)
        {
            var hiddenResult = this.GetCmp<Hidden>("Result");

            if (!model.CaptchaResult)
                model.CaptchaResult = ValidateCaptcha(CaptchaChallenge, CaptchaResponse);

            if (model.CaptchaResult)
            {
                BrockAllen.MembershipReboot.UserAccount account = Session["UserAccount"] as BrockAllen.MembershipReboot.UserAccount;
                UpdateCaptchaResult("True");
                ChangePasswordWithSecretDTOValidator validator = new ChangePasswordWithSecretDTOValidator();

                var control = this.GetCmp<MultiSelect>("CaptchaError");
                control.Hidden = true;
                control.Update();

                if (account != null)
                {
                    if (model.QuestionExists())
                    {
                        if (model.QuestionExistsWithAnswer())
                        {
                            PasswordResetQuestionAnswer answer = new PasswordResetQuestionAnswer();
                            answer = new PasswordResetQuestionAnswer
                            {
                                QuestionID = model.QuestionID.Value,
                                Answer = model.Answer
                            };
                            bool failed = this.userAccountService.VerifySecretQuestionAndAnswer(account.ID, answer, "ChangePassword");

                            var security = validator.ValidateUsingOneValidation("ForgotPassword", "AnswerDoesnotMatch", () => { return (failed == true); });

                            //Failed security
                            if (security.HasErrors)
                                return this.PopulateFormErrors("ChangePasswordFormErrors", security.ErrorMessages);
                            else
                            {
                                userAccountService.SetPassword(account.ID, model.Password);
                                var errors = this.GetCmp<MultiSelect>("ChangePasswordFormErrors");
                                errors.Hidden = true;
                                errors.Update();
                                return RedirectToAction("Index", "Login", new { area = "STSLogin" });
                                //return RedirectToAction("Success");
                            }
                        }
                        else
                            return this.Direct(model);
                    }
                    else
                    {
                        userAccountService.SetPassword(account.ID, model.Password);
                        return RedirectToAction("Index", "Login", new { area = "STSLogin" });
                    }
                }
               
                return View();
            }
            else
            {
                UpdateCaptchaResult("False");
                ChangePasswordWithSecretDTOValidator validator = new ChangePasswordWithSecretDTOValidator();
                validator.AddValidationActionToIPValidationList("Register", "CaptchaMismatch", () => { return true; });
                var validationResults = validator.ValidateUsingIPValidationList("Register");
                return this.PopulateFormErrors("CaptchaError", validationResults.ErrorMessages);
            }
        }

        private void UpdateCaptchaResult(string result)
        {
            var hiddenResult = this.GetCmp<Hidden>("Result");
            hiddenResult.Value = result;
            hiddenResult.Update();
        }
        private bool ValidateCaptcha(string Challenge, string Response)
        {
            var cientIP = Request.ServerVariables["REMOTE_ADDR"];
            var privateKey = ConfigurationManager.AppSettings["ReCaptchaPrivateKey"];

            string varchallenge = String.Empty;
            string varresponse = String.Empty;

            string data = string.Format("privatekey={0}&remoteip={1}&challenge={2}&response={3}", privateKey, cientIP, Challenge, Response);
            byte[] byteArray = new ASCIIEncoding().GetBytes(data);

            WebRequest request = WebRequest.Create("http://www.google.com/recaptcha/api/verify");
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            var status = (((HttpWebResponse)response).StatusCode);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

            var responseLines = responseFromServer.Split(new string[] { "\n" }, StringSplitOptions.None);
            var success = responseLines[0].Equals("true");
            return success;
        }
    }
}
