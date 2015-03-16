using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Workflow;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Entities.Validators;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Helpers;
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
    public class ForgottenPasswordController : Controller
    {
        // GET: ForgottenPassword
        UserAccountService userAccountService;
        private IDataLogic dataLogic;

        public ForgottenPasswordController(UserAccountService userAccountService,IDataLogic dLogic)
        {
            this.userAccountService = userAccountService;
            this.dataLogic = dLogic;
        }

        public ActionResult Index()
        {
            ViewData["PublicKey"] = ConfigurationManager.AppSettings["ReCaptchaPublicKey"];
            ViewData["Response"] = "";
            ViewData["Challenge"] = "";
            return View();
        }

        private FormPanelResult ResetPasswordEmailSent(ForgotPasswordWithSecretDTO model, ForgotPasswordWithSecretDTOValidator validator)
        {
            var temporaryAccountDto = new TemporaryAccountDTO {UserName = model.Username,IsForgotUsername = false};

            if (!EventPublisher.PublishEvent(dataLogic, TFEventEnum.ForgottenUsernamePasswordEvent.GetStringValue(), "ForgottonPasswordController", model.Username,
                new object[] { temporaryAccountDto }))
            {
                //TBD
            }
            var hiddenField = this.GetCmp<Hidden>("questionID");
            hiddenField.Value = null;
            hiddenField.Update();

            return this.PopulateFormMessages("ForgotPasswordFormMessages", new List<string>() { validator.GetInterfacePanelValidationMessage("ForgotPassword", "PasswordResetLinkEmailSent") });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ForgotPasswordWithSecretDTO model, string CaptchaChallenge, string CaptchaResponse)
        {
            var hiddenResult = this.GetCmp<Hidden>("Result");
            if (hiddenResult.Value.ToString() == "False" || hiddenResult.Value.ToString().IsNullOrEmpty())
                model.CaptchaResult = false;
            else
                model.CaptchaResult = true;
            if (!model.CaptchaResult)
                model.CaptchaResult = ValidateCaptcha(CaptchaChallenge, CaptchaResponse);

            if (model.CaptchaResult)
            {
                BrockAllen.MembershipReboot.UserAccount account = userAccountService.GetByUsername(model.Username);

                ForgotPasswordWithSecretDTOValidator validator = new ForgotPasswordWithSecretDTOValidator();

                var result = validator.ValidateUsingOneValidation("ForgotPassword", "InvalidUsername", () => { return (account == null); });

                // invalid email
                if (result.HasErrors)
                    return this.PopulateFormErrors("ForgotPasswordFormErrors", result.ErrorMessages);

                //check locked status for forgotpassword request
                if (userAccountService.HasTooManyRecentForgotPasswordRequestFailures(account))
                    return this.PopulateFormErrors("ForgotPasswordFormErrors", new List<string>() { validator.GetInterfacePanelValidationMessage("ForgotPassword", "ForgotPasswordRequestLockout") });


                // temp account then just send reminder
                if (account.IsTemporaryAccount)
                {
                    Ensure.Argument.Is(account.PasswordResetSecrets.Count == 0, "Temporary Account should not have secrets");

                    if (model.CaptchaResult)
                    {
                        HideCaptcha();

                        hiddenResult.Value = "True";
                        hiddenResult.Update();
                    }

                    return ResetPasswordEmailSent(model, validator);
                }
                else if (model.QuestionExists())
                {
                    if (model.QuestionExistsWithAnswer())
                    {
                        PasswordResetQuestionAnswer answer = new PasswordResetQuestionAnswer();
                        answer = new PasswordResetQuestionAnswer
                        {
                            QuestionID = model.QuestionID.Value,
                            Answer = model.Answer
                        };
                        bool failed = this.userAccountService.VerifySecretQuestionAndAnswer(account.ID, answer, "ForgottenPassword");

                        var security = validator.ValidateUsingOneValidation("ForgotPassword", "AnswerDoesnotMatch", () => { return (failed == true); });

                        //Failed security
                        if (security.HasErrors)
                            return this.PopulateFormErrors("ForgotPasswordFormErrors", security.ErrorMessages);
                        else
                            return ResetPasswordEmailSent(model, validator);
                    }
                    else
                        return this.Direct(model);
                }
                else
                {
                    Ensure.Argument.Is(account.PasswordResetSecrets.Count > 0, "Security questions not set");

                    var randomQuestion = account.RandomSecurityQuestion();
                    model.QuestionID = randomQuestion.PasswordResetSecretID;
                    model.Question = randomQuestion.Question;

                    var control = this.GetCmp<Label>("question");
                    control.Text = model.Question;
                    control.Style.Add("padding-left", "5px");
                    control.Update();

                    var hiddenField = this.GetCmp<Hidden>("questionID");
                    hiddenField.Value = model.QuestionID;
                    hiddenField.Update();

                    if (model.CaptchaResult)
                    {
                        HideCaptcha();

                        hiddenResult.Value = "True";
                        hiddenResult.Update();
                    }
                    return this.Direct(model);
                }
            }
            else
            {
                ForgotPasswordWithSecretDTOValidator validator = new ForgotPasswordWithSecretDTOValidator();
                validator.AddValidationActionToIPValidationList("Register", "CaptchaMismatch", () => { return true; });
                var validationResults = validator.ValidateUsingIPValidationList("Register");
                return this.PopulateFormErrors("CaptchaError", validationResults.ErrorMessages);
            }
        }
        private void HideCaptcha()
        {
            var captcha = this.GetCmp<Hidden>("divcaptcha2");
            captcha.Hidden = true;
            captcha.Update();

            var captchaErr = this.GetCmp<Hidden>("CaptchaError");
            captchaErr.Hidden = true;
            captchaErr.Update();
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