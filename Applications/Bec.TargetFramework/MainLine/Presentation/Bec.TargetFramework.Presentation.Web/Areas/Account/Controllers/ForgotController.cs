using Bec.TargetFramework.Business.Client.Interfaces;
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
        AuthenticationService authSvc;
        IUserLogicClient m_UserLogicClient;
        IOrganisationLogicClient m_OrgLogicClient;
        INotificationLogicClient m_NotificationLogicClient;
        CommonSettings m_CommonSettings;
        HttpClient httpClient;
        public ForgotController(AuthenticationService aSvc, IUserLogicClient uClient, IOrganisationLogicClient oClient, INotificationLogicClient nClient, CommonSettings cSettings)
        {
            authSvc = aSvc;
            m_UserLogicClient = uClient;
            m_OrgLogicClient = oClient;
            m_NotificationLogicClient = nClient;
            m_CommonSettings = cSettings;
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
        public async Task<ActionResult> Username(string email)
        {
            var response = await ValidateCaptcha();
            //send email if the email address is found
            if (response.success)
            {
                m_UserLogicClient.SendUsernameReminder(email);

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
        public async Task<ActionResult> Password(string username)
        {
            var response = await ValidateCaptcha();
            if (response.success)
            {
                //send email if the username is found
                m_UserLogicClient.SendPasswordResetNotification(username, Request.Url.OriginalString.Replace("/Password", "/Reset") + "?resetId={0}&expire={1}");

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
                await m_UserLogicClient.ExpirePasswordResetRequestAsync(resetID);
                ViewBag.Message = "The request to reset your password has been revoked.";
                ViewBag.Link = true;
                return View("ForgotDone");
            }
            else
            {
                //TODO: check whether the reset request is still valid
                if (await m_UserLogicClient.IsPasswordResetRequestValidAsync(resetID))
                {
                    ViewBag.RequestID = resetID;
                    return View();
                }
                else
                {
                    //invalid guid
                    ViewBag.Message = string.Format("An error has occured. Please contact support on {0}", m_CommonSettings.SupportTelephoneNumber);
                    return View("ForgotDone");
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> Reset(ResetPasswordModel model)
        {
            
            //expire the reset request
            var requestUserID = await m_UserLogicClient.ExpirePasswordResetRequestAsync(model.RequestID);

            //check username matches the reset request
            var ua = m_UserLogicClient.GetBAUserAccountByUsername(model.Username);
            if (ua != null && ua.ID == requestUserID)
            {
                //change password
                m_UserLogicClient.ResetUserPassword(requestUserID, model.NewPassword);
                await LoginController.login(this, ua, authSvc, m_UserLogicClient, m_NotificationLogicClient);

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                ViewBag.Message = string.Format("An error has occured. Please contact support on {0}", m_CommonSettings.SupportTelephoneNumber);
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