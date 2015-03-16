
using System.Collections.Generic;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Security;
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
using Ext.Net;
using Ext.Net.MVC;
using System.Linq;
using Fabrik.Common;
using Bec.TargetFramework.Workflow.Interfaces;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Hangfire;
using NHibernate.Mapping;
using Bec.TargetFramework.UI;
using Bec.TargetFramework.Entities.Validators;
using System.Web.UI.WebControls;
using System.Security.Claims;
using Bec.TargetFramework.UI.Web.Helpers;
using System.Threading.Tasks;


namespace Bec.TargetFramework.UI.Web.Areas.STSLogin.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {

        private IWorkflowProcessService m_WorkflowProcessLogic;
        UserAccountService userAccountService;
        AuthenticationService authSvc;
        private ILogger logger;
        private IDataLogic m_DataLogic;
        private IUserLogic m_UserLogic;
        public LoginController(ILogger logger, IWorkflowProcessService logic, AuthenticationService authSvc, IDataLogic dataLogic, IUserLogic userLogic )
        {
            this.logger = logger;
            this.userAccountService = authSvc.UserAccountService;
            this.authSvc = authSvc;
            m_WorkflowProcessLogic = logic;
            m_DataLogic = dataLogic;
            m_UserLogic = userLogic;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Bec.TargetFramework.Entities.LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                LoginDTOValidator validator = new LoginDTOValidator();

                UserLoginValidation result = m_UserLogic.AuthenticateUser(model.Username, model.Password);

                BrockAllen.MembershipReboot.UserAccount account = result.UserAccount;

                if (!result.valid)
                {
                    if (result.validationMessage != null)
                        return this.PopulateFormErrors("LoginFormErrors", new List<string>() { result.validationMessage });
                    else
                        return this.PopulateFormErrors("LoginFormErrors", new List<string>() { validator.GetInterfacePanelValidationMessage("Login", "IncorrectUsernameorPassword") });
                }
                else
                {
                    List<VUserAccountOrganisationUserTypeOrganisationTypeDTO> orgs = m_UserLogic.GetUserAccountOrganisationWithUserTypeAndOrgType(account.ID);
                    List<Claim> additionalClaims = new List<Claim>();
                    if (orgs.Count > 0)
                    {
                        foreach (var org in orgs)
                        {
                            List<Claim> claims = ClaimsHelper.GenerateUserClaims(account.ID, org.OrganisationID.Value);
                            foreach (var claim in claims)
                                additionalClaims.Add(claim);
                        }
                    }
                    //  additional claims are added during signin but not persisted
                    authSvc.SignIn(account, false, additionalClaims);

                    //  create web user object in session
                    WebUserHelper.CreateWebUserObjectInSession(this.HttpContext, account.ID);

                    // make login record
                    UserAccountLogicHelper.CreateUserAccountLoginLogEntry(this.HttpContext, account.ID);

                    var wfi = new VUserWorkflowInstanceStatusDTO();
                    var uao = new VUserAccountOrganisationUserTypeOrganisationTypeDTO();
                    if (account.IsTemporaryAccount)
                        wfi = m_WorkflowProcessLogic.GetWorkflowInstanceFromParentID(account.ID);  //Only temporary account uses userid as parent id for wf other use uao id
                    else
                    {
                        int orgType = (int) OrganisationTypeEnum.Personal;

                        //uao id of personal org if is employee is false else pass uao of professional org
                        if (!account.IsEmployee)
                            uao = orgs.Single(s => s.OrganisationTypeID.HasValue && s.OrganisationTypeID.Value.Equals(orgType));
                        else
                            uao = orgs.Single(s => s.OrganisationTypeID.HasValue && !s.OrganisationTypeID.Value.Equals(orgType));
                        wfi = m_WorkflowProcessLogic.GetWorkflowInstanceFromParentID(uao.UserAccountOrganisationID);
                    }
                    Ensure.NotNull(wfi);

                    if (wfi != null)
                    {
                        if (wfi.Instancestatus.Equals("New"))
                        {
                            var state = m_WorkflowProcessLogic.StartWorkflowInstance(wfi.WorkflowInstanceID, wfi.ParentID);
                            state.WorkflowState.InstanceID = state.InstanceDTO.WorkflowInstanceID;
                            WorkflowSessionHelper.AddOrReplaceWorkflowStateToSession(state.WorkflowState);
                        }
                        else
                        {
                            var state = m_WorkflowProcessLogic.RestartWorkflowInstance(wfi.WorkflowInstanceID, wfi.ParentID);
                            state.WorkflowState.InstanceID = state.InstanceDTO.WorkflowInstanceID;
                            WorkflowSessionHelper.AddOrReplaceWorkflowStateToSession(state.WorkflowState);
                        }
                        return RedirectToAction("GetCurrentWorkflowInstance", "Login",
                            new { workflowInstanceID = wfi.WorkflowInstanceID });
                    }
                    else
                        return RedirectToAction("Dashboard", "Dashboard", new { area = "SafeTransactionSearch" });
                }
            }
            else
                return this.ReturnFormPanelWithErrorsForInvalidModelState();
        }

        public ActionResult GetCurrentWorkflowInstance(string workflowInstanceID)
        {
            Ensure.Argument.NotNull(workflowInstanceID);


            var dto =
                m_WorkflowProcessLogic.GetCurrentWorkflowInstanceManualActionNotCompleted(
                    Guid.Parse(workflowInstanceID));

            // need to hide parameters so use TempData
            Session["WorkflowDTO"] = dto;
            return RedirectToAction(dto.CurrentActionDTO.ActionName, dto.CurrentActionDTO.ControllerName, new { area = dto.CurrentActionDTO.AreaName });


        }
    }
     
}
