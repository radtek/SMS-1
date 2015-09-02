using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.Presentation.Web.Models;
using BrockAllen.MembershipReboot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
{
    public class ForgotController : Controller
    {
        public AuthenticationService AuthSvc { get; set; }
        public IUserLogicClient UserLogicClient { get; set; }
        public INotificationLogicClient NotificationLogicClient { get; set; }
        public ITFSettingsLogicClient SettingsClient { get; set; }
        public IOrganisationLogicClient orgClient { get; set; }

        HttpClient httpClient;
        public ForgotController()
        {
            httpClient = new HttpClient { BaseAddress = new Uri("https://www.google.com/recaptcha/api/") };
        }
        // GET: Account/Forgot
        public ActionResult Username()
        {
            return View();
        }

        public ActionResult Password()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Username(string email)
        {
            var response = await ValidateCaptcha();
            //send email if the email address is found
            if (response.success)
            {
                await UserLogicClient.SendUsernameReminderAsync(email);

                ViewBag.Message = "Thank you. The registered Username has been sent to the specified email address.";
                ViewBag.Link = true;
                return View("ForgotDone");
            }
            else
            {
                ViewBag.Message = string.Join(Environment.NewLine, response.error_codes ?? new List<string> { "Error" });
                return View("ForgotDone");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Password(string username)
        {
            var response = await ValidateCaptcha();
            if (response.success)
            {
                //send email if the username is found
                await UserLogicClient.SendPasswordResetNotificationAsync(username, Request.Url.OriginalString.Replace("/Password", "/Reset") + "?resetId={0}&expire={1}");

                ViewBag.Message = "Thank you. Instructions to reset your password have been sent to your registered email address.";
                return View("ForgotDone");
            }
            else
            {
                ViewBag.Message = string.Join(Environment.NewLine, response.error_codes ?? new List<string> { "Error" });
                return View("ForgotDone");
            }
        }

        public async Task<ActionResult> Reset(Guid resetID, bool expire)
        {
            if (expire)
            {
                await UserLogicClient.ExpirePasswordResetRequestAsync(resetID);
                ViewBag.Message = "The request to reset your password has been revoked.";
                ViewBag.Link = true;
                return View("ForgotDone");
            }
            else
            {
                //TODO: check whether the reset request is still valid
                if (await UserLogicClient.IsPasswordResetRequestValidAsync(resetID))
                {
                    ViewBag.RequestID = resetID;
                    return View();
                }
                else
                {
                    //invalid guid
                    ViewBag.Message = string.Format("An error has occured. Please contact support on {0}", SettingsClient.GetSettings().AsSettings<CommonSettings>().SupportTelephoneNumber);
                    return View("ForgotDone");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Reset(ResetPasswordModel model)
        {
            
            //expire the reset request
            var requestUserID = await UserLogicClient.ExpirePasswordResetRequestAsync(model.RequestID);

            //check username matches the reset request
            var ua = await UserLogicClient.GetBAUserAccountByUsernameAsync(model.Username);
            if (ua != null && ua.ID == requestUserID)
            {
                //change password
                await UserLogicClient.ResetUserPasswordAsync(requestUserID, model.NewPassword);
                await LoginController.login(this, ua, AuthSvc, UserLogicClient, NotificationLogicClient, orgClient);

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                ViewBag.Message = string.Format("An error has occured. Please contact support on {0}", SettingsClient.GetSettings().AsSettings<CommonSettings>().SupportTelephoneNumber);
                return View("ForgotDone");
            }
        }

        private async Task<CaptchaResponse> ValidateCaptcha()
        {
            string g_recaptcha_response = Request["g-recaptcha-response"];
            var remote_ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.UserHostAddress;
            var gr = await httpClient.PostAsync("siteverify?secret=6LfblQcTAAAAAFCb0kLLPOhJnU8YgwrjIjw-XVNI&response=" + g_recaptcha_response + "&remoteip=" + remote_ip, null);
            gr.EnsureSuccessStatusCode();
            var response = await gr.Content.ReadAsAsync<CaptchaResponse>();
            return response;
        }
    }
}