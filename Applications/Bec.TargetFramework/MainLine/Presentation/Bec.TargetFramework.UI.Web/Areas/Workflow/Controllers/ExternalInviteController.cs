using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Collections.Specialized;
using System.Threading;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Collections;
using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Workflow.Engine;
using Bec.TargetFramework.Workflow.Interfaces;
using Bec.TargetFramework.Workflow.Providers;
using Bec.TargetFramework.Workflow.Scheduler;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Bec.TargetFramework.Entities;
namespace Bec.TargetFramework.UI.Web.Areas.Workflow.Controllers
{

    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.UI.Process.Base;
    using Bec.TargetFramework.Workflow.Interfaces;

    using Fabrik.Common;

    using NHibernate.Engine;
    using BEC.TargetFramework.UI.Web.IOC;
    using Bec.TargetFramework.Entities.Workflow;

    public class ExternalInviteController : ApplicationControllerBase
    {
         private IWorkflowProcessService m_WorkflowProcessLogic;

         public ExternalInviteController(ILogger logger, IWorkflowProcessService logic)
            : base(logger)
        {
            m_WorkflowProcessLogic = logic;
        }

        // GET: Workflow/NextSteps

        public ActionResult ExternalInvite()
        {
            var dto = TempData["WorkflowDTO"] as WorkflowInstanceCurrentStateDTO;
           // var dto = Session["WorkflowDTO"] as WorkflowInstanceCurrentStateDTO;
            // get json for current step
            var data =
                m_WorkflowProcessLogic.GetDataForWorkflowInstanceStatusEvent(
                    dto.CurrentActionDTO.WorkflowInstanceExecutionStatusEventID);

            // do the rest
            dto.InstanceExecutionDataItemDTO = new WorkflowInstanceExecutionDataItemDTO();
            dto.WorkflowState = data;

            // because I am lazy in this test version, dumping state in session, do not copy for real actions
            Session.Add("WorkflowState", dto.WorkflowState);
            Session.Add("WorkflowInstanceID", dto.InstanceDTO.WorkflowInstanceID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult ExternalInvite(WorkflowActionDTO WorkflowActionDTO)
        {
            if (ModelState.IsValid)
            {
                // need to restart workflow
                var instanceID = Session["WorkflowInstanceID"] as Guid?;
                var state = Session["WorkflowState"] as WorkflowStateBaseDTO;

                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(instanceID.Value, state);

                TempData.Add("WorkflowDTO", currentState);
               // Session["WorkflowDTO"] = currentState;
                return RedirectToAction(
                    currentState.CurrentActionDTO.ActionName,
                    currentState.CurrentActionDTO.ControllerName,
                new
                {
                    area = currentState.CurrentActionDTO.AreaName
                });
            }


            return View();
        }

        public ActionResult TnCExternalInviteToCOWorkflowAction()
        {
            var dto = TempData["WorkflowDTO"] as WorkflowInstanceCurrentStateDTO;
            //var dto = Session["WorkflowDTO"] as WorkflowInstanceCurrentStateDTO;
            // get json for current step
            WorkflowStateBaseDTO data =
                m_WorkflowProcessLogic.GetDataForWorkflowInstanceStatusEvent(
                    dto.CurrentActionDTO.WorkflowInstanceExecutionStatusEventID);

            // do the rest
            dto.WorkflowState = data;

            // because I am lazy in this test version, dumping state in session, do not copy for real actions
            Session.Add("WorkflowState", dto.WorkflowState);
            Session.Add("WorkflowInstanceID", dto.InstanceDTO.WorkflowInstanceID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult TnCExternalInviteToCOWorkflowAction(WorkflowActionDTO WorkflowActionDTO)
        {
            if (ModelState.IsValid)
            {
                // need to restart workflow
                var instanceID = Session["WorkflowInstanceID"] as Guid?;
                var state = Session["WorkflowState"] as WorkflowStateBaseDTO;

                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(instanceID.Value, state);

                TempData.Add("WorkflowDTO", currentState);
                //Session["WorkflowDTO"] = currentState;
                return RedirectToAction(
                    currentState.CurrentActionDTO.ActionName,
                    currentState.CurrentActionDTO.ControllerName,
                new
                {
                    area = currentState.CurrentActionDTO.AreaName
                });
            }


            return View();
        }


        public ActionResult IsUserCOWorkflowDecision()
        {
            var dto = TempData["WorkflowDTO"] as WorkflowInstanceCurrentStateDTO;
            //var dto = Session["WorkflowDTO"] as WorkflowInstanceCurrentStateDTO;
            // get json for current step
            var data =
                m_WorkflowProcessLogic.GetDataForWorkflowInstanceStatusEvent(
                    dto.CurrentActionDTO.WorkflowInstanceExecutionStatusEventID);

            // do the rest
            dto.InstanceExecutionDataItemDTO = new WorkflowInstanceExecutionDataItemDTO();
            dto.WorkflowState = data;

            // because I am lazy in this test version, dumping state in session, do not copy for real actions
            Session.Add("WorkflowState", dto.WorkflowState);
            Session.Add("WorkflowInstanceID", dto.InstanceDTO.WorkflowInstanceID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult IsUserCOWorkflowDecision(WorkflowActionDTO WorkflowActionDTO)
        {
            if (ModelState.IsValid)
            {
                // need to restart workflow
                var instanceID = Session["WorkflowInstanceID"] as Guid?;
                var state = Session["WorkflowState"] as WorkflowStateBaseDTO;

                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(instanceID.Value, state);

                TempData.Add("WorkflowDTO", currentState);
                //Session["WorkflowDTO"] = currentState;
                return RedirectToAction(
                    currentState.CurrentActionDTO.ActionName,
                    currentState.CurrentActionDTO.ControllerName,
                new
                {
                    area = currentState.CurrentActionDTO.AreaName
                });
            }


            return View();
        }
    }
}