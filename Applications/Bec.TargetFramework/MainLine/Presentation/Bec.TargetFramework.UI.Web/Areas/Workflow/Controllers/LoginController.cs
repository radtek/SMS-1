﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.UI.Web.Areas.Workflow.Controllers
{
    using System.Web.Routing;

    using Bec.TargetFramework.Entities;
    using Bec.TargetFramework.Entities.Workflow;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.UI.Process.Base;
    using Bec.TargetFramework.Workflow.Interfaces;

    using Fabrik.Common;

    using NHibernate.Engine;

    public class LoginController : ApplicationControllerBase
    {
        private IWorkflowProcessService m_WorkflowProcessLogic;

        public LoginController(ILogger logger, IWorkflowProcessService logic)
            : base(logger)
        {
            m_WorkflowProcessLogic = logic;
        }

        // GET: Workflow/Workflow

        public ActionResult Login()
        {
            var dto = TempData["WorkflowDTO"] as WorkflowInstanceCurrentStateDTO;

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
        public ActionResult Login(WorkflowActionDTO WorkflowActionDTO)
        {
            if (ModelState.IsValid)
            {
                // need to restart workflow
                var instanceID = Session["WorkflowInstanceID"] as Guid?;
                var state = Session["WorkflowState"] as WorkflowStateBaseDTO;

                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(instanceID.Value, state);

                //TempData.Remove("WorkflowDTO");

                TempData.Add("WorkflowDTO", currentState);
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

        public ActionResult CreatePermanentLogin()
        {
            var dto = TempData["WorkflowDTO"] as WorkflowInstanceCurrentStateDTO;

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
        public ActionResult CreatePermanentLogin(WorkflowActionDTO WorkflowActionDTO)
        {
            if (ModelState.IsValid)
            {
                // need to restart workflow
                var instanceID = Session["WorkflowInstanceID"] as Guid?;
                var state = Session["WorkflowState"] as WorkflowStateBaseDTO;

                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(instanceID.Value, state);

                TempData.Add("WorkflowDTO", currentState);

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

        public ActionResult IsUserAccountValidWorkflowDecision()
        {
            // var dto = TempData["WorkflowDTO"] as WorkflowInstanceCurrentStateDTO;
            var dto = Session["WorkflowDTO"] as WorkflowInstanceCurrentStateDTO;
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
        public ActionResult IsUserAccountValidWorkflowDecision(WorkflowActionDTO WorkflowActionDTO)
        {
            if (ModelState.IsValid)
            {
                // need to restart workflow
                var instanceID = Session["WorkflowInstanceID"] as Guid?;
                var state = Session["WorkflowState"] as WorkflowStateBaseDTO;

                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(instanceID.Value, state);

                //TempData.Add("WorkflowDTO", currentState);
                Session["WorkflowDTO"] = currentState;
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



        public ActionResult IsRegistrationWorkflowDecision()
        {
            // var dto = TempData["WorkflowDTO"] as WorkflowInstanceCurrentStateDTO;
            var dto = Session["WorkflowDTO"] as WorkflowInstanceCurrentStateDTO;
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
        public ActionResult IsRegistrationWorkflowDecision(WorkflowActionDTO WorkflowActionDTO)
        {
            if (ModelState.IsValid)
            {
                // need to restart workflow
                var instanceID = Session["WorkflowInstanceID"] as Guid?;
                var state = Session["WorkflowState"] as WorkflowStateBaseDTO;

                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(instanceID.Value, state);

                //TempData.Add("WorkflowDTO", currentState);
                Session["WorkflowDTO"] = currentState;
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



