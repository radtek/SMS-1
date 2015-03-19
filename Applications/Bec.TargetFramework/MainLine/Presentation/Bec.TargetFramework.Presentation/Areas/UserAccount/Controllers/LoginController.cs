
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Validators;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.UI.Process.Filters;
using Bec.TargetFramework.Web.Framework.Helpers;
using Bec.TargetFramework.Workflow.Interfaces;
using BrockAllen.MembershipReboot;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using Bec.TargetFramework.Infrastructure.Helpers;
using System.Net;
using System.Web.Script.Serialization;
using Hangfire;


namespace Bec.TargetFramework.Presentation.Areas.UserAccount.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {

        private IWorkflowProcessService m_WorkflowProcessLogic;

        AuthenticationService authSvc;
        private ILogger logger;
        private IUserLogic m_UserLogic;
        public LoginController(ILogger logger, AuthenticationService authSvc, IUserLogic userLogic)
        {
            this.logger = logger;
            this.authSvc = authSvc;
            m_UserLogic = userLogic;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
           return View(new UserLoginValidation());

        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult AuthenticateUser()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AuthenticateUser(LoginDTO model)
        {
            var a = Request.ContentType;

            if (ModelState.IsValid)
            {
                UserLoginValidation result = m_UserLogic.AuthenticateUser(model.Username, model.Password);

                BrockAllen.MembershipReboot.UserAccount account = result.UserAccount;

                if (!result.valid)
                {
                    if (Request.IsAjaxRequest())
                    {
                        return Json(result);
                    }
                }
                else
                {
                   InitialiseUserSession(account);

                    return Json(new { returnUrl = model.ReturnUrl });
                }
            }

            return null;
        }

        private void InitialiseUserSession(BrockAllen.MembershipReboot.UserAccount account)
        {
            //  additional claims are added during signin but not persisted
            authSvc.SignIn(account, false, null);

            //  create web user object in session
            var userObject = WebUserHelper.CreateWebUserObjectInSession(this.HttpContext, account.ID);

            // save login session - needed for authenticated pages extending ApplicationControllerBase
            m_UserLogic.SaveUserAccountLoginSession(userObject.UserID, userObject.SessionIdentifier, Request.UserHostAddress, "", "");

            // get all request parameters
            var requestParameters = UserAccountLogicHelper.CreateRequestDictionary(this.Request);

            BackgroundJob.Enqueue(() => UserAccountLogicHelper.SaveLoginSessionData(userObject.UserID, userObject.SessionIdentifier, requestParameters));
        }
    }

}
