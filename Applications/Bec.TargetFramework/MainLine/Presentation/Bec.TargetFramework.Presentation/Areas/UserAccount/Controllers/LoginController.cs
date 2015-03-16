
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


namespace Bec.TargetFramework.Presentation.Areas.UserAccount.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {

        private IWorkflowProcessService m_WorkflowProcessLogic;

        AuthenticationService authSvc;
        private ILogger logger;
        private IDataLogic m_DataLogic;
        private IUserLogic m_UserLogic;
        public LoginController(ILogger logger, IWorkflowProcessService logic, AuthenticationService authSvc, IDataLogic dataLogic, IUserLogic userLogic)
        {
            this.logger = logger;
            this.authSvc = authSvc;
            m_WorkflowProcessLogic = logic;
            m_DataLogic = dataLogic;
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


                string s = Url.Action("Order", "Home", new { area = string.Empty }, String.Empty);

                string s2 = Url.Action("Order", "Home");

                if (!result.valid)
                {
                    if (Request.IsAjaxRequest())
                    {
                        return Json(result);
                    }
                }
                else
                {
                    //  additional claims are added during signin but not persisted
                    authSvc.SignIn(account, false, null);

                    //  create web user object in session
                    WebUserHelper.CreateWebUserObjectInSession(this.HttpContext, account.ID);

                    // make login record
                    UserAccountLogicHelper.CreateUserAccountLoginLogEntry(this.HttpContext, account.ID);

                    return Json(new { returnUrl = model.ReturnUrl });
                }
            }

            return null;
        }


    }

}
