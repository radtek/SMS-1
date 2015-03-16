using Autofac;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Workflow;
using Bec.TargetFramework.Framework;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bec.TargetFramework.SB.Infrastructure.EventSource;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Workflow.Interfaces;
using Bec.TargetFramework.Infrastructure.Log;
using System.Configuration;
using Bec.TargetFramework.Entities.Validators;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Infrastructure.Extensions;
using System.Net;
using System.IO;
using System.Text;
using Fabrik.Common;
using Ext.Net;
using Ext.Net.MVC;
using System.ComponentModel.DataAnnotations;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Framework.Threading;
using BrockAllen.MembershipReboot;
using Bec.TargetFramework.UI.Web.Helpers;
using Bec.TargetFramework.Infrastructure.Helpers;
namespace Bec.TargetFramework.UI.Web.Areas.STSLogin.Controllers
{
    public class CreateLoginController : ApplicationControllerBase
    {
        private IWorkflowProcessService m_WorkflowProcessLogic;
        private IUserLogic m_UserLogic;
        UserAccountService userAccountService;
        private IDataLogic m_DataLogic;
        // GET: CreateLogin

        public CreateLoginController(ILogger logger, IWorkflowProcessService logic, IUserLogic userLogic, UserAccountService userAccountService, IDataLogic dLogic)
            : base(logger)
        {
            m_WorkflowProcessLogic = logic;
            m_UserLogic = userLogic;
            m_DataLogic = dLogic;
            this.userAccountService = userAccountService;
        }
        public ActionResult Index()
        {
            PermanentAccountDTO dto = new PermanentAccountDTO();
            var state = Session["WorkflowState"] as WorkflowStateBaseDTO;
            if(state != null)
            {
                object tempAcc;
                state.WorkflowDictionaryDto.WorkflowDictionary.TryGetValue(WorkflowDataEnum.TemporaryAccountData.GetStringValue(), out tempAcc);
                if(tempAcc != null)
                {
                    TemporaryAccountDTO tempdto = (TemporaryAccountDTO)tempAcc;
                    dto.EmailAddress = tempdto.EmailAddress;
                }
            }
            return View(dto);
        }

        [HttpPost]
        public ActionResult Index(PermanentAccountDTO model)
        {
            List<UserAccountDTO> accounts = m_UserLogic.GetUserAccountByEmail(model.EmailAddress, true);

            if (accounts.Count == 0)
            {
                if (model.UserID == Guid.Empty)
                    model.UserID = Guid.NewGuid();
                else
                    model.UserID = accounts[0].ID; //There should be only one account as we get only permanent accounts

                WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<PermanentAccountDTO>(WorkflowDataEnum.PermanentAccountData.GetStringValue(), model);
                var state = WorkflowSessionHelper.GetWorkflowStateFromSession();
                 var dictionary = JsonHelper.SerializeData<object>(state);

                if (!EventPublisher.PublishEvent(m_DataLogic, TFEventEnum.CreateLoginCompletedEvent.GetStringValue(), "CreateLoginController", model.EmailAddress,
                    new object[] { dictionary }))
                {
                    //TBD
                }
                return RedirectToAction("Index", "Logout", new { area = "STSLogin" });
            }
            else
                return this.PopulateFormErrors("CreateLoginFormErrors", new List<string>() { "Cannot create new account as it already exists"} ); //At some point need to add an error page
            
        }

        public ActionResult CreateLogin()
        {
            return View();
        }

        [OverrideActionFilters]
        [AllowAnonymous]
        //Tested temporary account creation. Using to test the wf side
        [HttpPost]
        public ActionResult CreateTemporaryLogin(TemporaryAccountDTO model)
        {
            BrockAllen.MembershipReboot.UserAccount account = userAccountService.GetByEmail(model.EmailAddress);

            // invalid email
            if (account != null)
                return this.PopulateFormErrors("TempAccountFormErrors", new List<string>() { "Account already exists on the system." });

            //Create Login workflow 
            Guid tempUserId = Guid.NewGuid();
            var registrationWorkflow = m_WorkflowProcessLogic.GetWorkflowFromName("Registration");
            var genericData = new ConcurrentDictionary<string, object>();
            genericData[WorkflowDataEnum.TemporaryAccountData.GetStringValue()] = new TemporaryAccountDTO()
            {
                EmailAddress = model.EmailAddress,
                TemporaryUserId = tempUserId,
                WorkflowID = registrationWorkflow.WorkflowID,
                WorkflowVersionNumber = registrationWorkflow.WorkflowVersionNumber,
                IsRegistration = true,
                IsSearchInvite = false
            };
            genericData[WorkflowDataEnum.RegistrationData.GetStringValue()] = model;

            var jsonString = ServiceStack.Text.JsonSerializer.SerializeToString(genericData);

            List<UserAccountOrganisationDTO> users = new List<UserAccountOrganisationDTO>();
            var workflow = m_WorkflowProcessLogic.GetWorkflowFromName("Login");
            var dto = m_WorkflowProcessLogic.CreateAndStartWorkflowInstance(workflow.WorkflowID, workflow.WorkflowVersionNumber, new WorkflowDictionaryDTO { WorkflowDictionary = genericData }, tempUserId, users);

            Session.Add("RegistrationState", genericData);
            return RedirectToAction("Index", "Logout", new { area = "STSLogin" });
        }
        public virtual JsonResult IsUserExist(string value)
        {
            bool valid = true;
            if (!string.IsNullOrEmpty(value))
                valid = !(m_UserLogic.IsUserExist(value));

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }
    }
}