﻿using Bec.TargetFramework.Business.Client.Interfaces;
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

        private readonly CaptchaService _captchaService;
        public ForgotController()
        {
            _captchaService = new CaptchaService();
        }

        public ActionResult Password()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Password(ResetPasswordModel model)
        {
            var response = await _captchaService.ValidateCaptcha(Request);
            if (response.success)
            {
                //check username matches the reset request
                var ua = await UserLogicClient.GetBAUserAccountByUsernameAsync(model.Username);
                try
                {
                    //change password
                    await UserLogicClient.ResetUserPasswordAsync(ua.ID, model.NewPassword, false, model.PIN);
                    await LoginController.login(this, ua, AuthSvc, UserLogicClient, NotificationLogicClient, orgClient);
                    return RedirectToAction("Index", "App", new { area = "" });
                }
                catch
                {
                    ViewBag.Message = string.Format("An error has occured. Please contact support at ");
                    ViewBag.Email = SettingsClient.GetSettings().AsSettings<CommonSettings>().SupportEmailAddress;
                    return View("ForgotDone");
                }
            }
            else
            {
                ViewBag.Message = string.Join(Environment.NewLine, response.error_codes ?? new List<string> { "Error" });
                return View("ForgotDone");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GenerateRequest(string username)
        {
            if (string.IsNullOrEmpty(username)) return Json(new { message = "Please enter your email address" }, JsonRequestBehavior.AllowGet);

            try
            {
                await UserLogicClient.CreatePasswordResetRequestAsync(username);
                return Json(new { message = "The verification code has been sent" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}