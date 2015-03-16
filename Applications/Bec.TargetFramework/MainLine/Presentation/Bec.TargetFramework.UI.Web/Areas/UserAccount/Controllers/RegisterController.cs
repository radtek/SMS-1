using Bec.TargetFramework.UI.Web.Areas.UserAccount.Models;
using BrockAllen.MembershipReboot;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Infrastructure.Log;
using System.Net;
using System.IO;
using System;
using System.Text;
using Ext.Net;
using System.Configuration;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        UserAccountService userAccountService;
        AuthenticationService authSvc;
        private IUserLogic m_UserLogic;
        public RegisterController(AuthenticationService authSvc, IUserLogic logic)
        {
            this.authSvc = authSvc;
            this.userAccountService = authSvc.UserAccountService;
            m_UserLogic = logic;
        }

        public ActionResult Index()
        {
            return View(new RegisterInputModel());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(RegisterInputModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var acc = userAccountService.GetByEmail(model.Email);
                    //if (acc != null)
                       // m_UserLogic.DeleteAccount(acc.ID);
                    //creating account with auto generated username and password
                    //var account = m_UserLogic.CreateTemporaryAccount(model.Email, true,Guid.NewGuid());
                    //ViewData["RequireAccountVerification"] = this.userAccountService.Configuration.RequireAccountVerification;
                    return View("Success", model);

                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }

        public ActionResult Verify()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Verify(string foo)
        {
            try
            {
                this.userAccountService.RequestAccountVerification(User.GetUserID());
                return View("Success");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }

        public ActionResult Cancel(string id)
        {
            try
            {
                bool closed;
                this.userAccountService.CancelNewAccount(id, out closed);
                if (closed)
                {
                    return View("Closed");
                }
                else
                {
                    return View("Cancel");
                }
            }
            catch(ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View("Error");
        }

        [OverrideActionFilters]
        [AllowAnonymous]
        public ActionResult CreateCaptcha(string containerId)
        {
            var captchaRequest = new CaptchaRequest() { PublicKey = ConfigurationManager.AppSettings["ReCaptchaPublicKey"] };
            //var result = new Ext.Net.MVC.PartialViewResult
            //{
            //    ViewName = "Captcha",
            //    RenderMode = RenderMode.AddTo,
            //    Model = captchaRequest,
            //    ClearContainer = true,
            //    ContainerId = containerId,
            //    WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            //};

            //return result;
            return View("Captcha", captchaRequest);

        }

        public ActionResult Register(string containerId)
        {
            var result = new Ext.Net.MVC.PartialViewResult
            {  
                ViewName = "Register",
                RenderMode = RenderMode.AddTo,
                ContainerId = containerId,
                ClearContainer = true,
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            };

            return result;
        }

     public ActionResult Thanks(string containerId)
        {
            var result = new Ext.Net.MVC.PartialViewResult
            {  
                ViewName = "Thanks",
                RenderMode = RenderMode.AddTo,
                ContainerId = containerId,
                ClearContainer = true,
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            };

            return result;
        }


     [OverrideActionFilters]
     [AllowAnonymous]
        public ActionResult ValidateCaptcha(CaptchaRequest captcha)
        {
            var cientIP = Request.ServerVariables["REMOTE_ADDR"];
            var privateKey = ConfigurationManager.AppSettings["ReCaptchaPrivateKey"];

            string varchallenge = String.Empty;
            string varresponse = String.Empty;

            string data = string.Format("privatekey={0}&remoteip={1}&challenge={2}&response={3}", privateKey, cientIP,captcha.Challenge,captcha.Response);
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
            return Json(new { Success = success });
        }

       

    }
}
