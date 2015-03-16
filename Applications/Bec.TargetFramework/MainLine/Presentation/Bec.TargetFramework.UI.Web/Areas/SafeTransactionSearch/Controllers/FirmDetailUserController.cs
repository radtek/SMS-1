using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.UI.Web.Areas.SafeTransactionSearch.Helpers;
using Bec.TargetFramework.UI.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Workflow.Interfaces;
namespace Bec.TargetFramework.UI.Web.Areas.SafeTransactionSearch.Controllers
{
    public class FirmDetailUserController : Controller
    {
        private IWorkflowProcessService m_WorkflowProcessLogic;

        public FirmDetailUserController(IWorkflowProcessService logic)
        {
            m_WorkflowProcessLogic = logic;
        }

        // GET: SafeTransactionSearch/FirmDetailUser
        public ActionResult Index()
        {
            var dto = new FirmDetailsUserDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult Next(FirmDetailsUserDTO dto)
        {

            if (ModelState.IsValid)
            {
                WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<FirmDetailsUserDTO>(WorkflowDataEnum.FirmDetailUserData.GetStringValue(), dto);
                // need to restart workflow
                var state = WorkflowSessionHelper.GetWorkflowStateFromSession();

                object oValue1 = new object();
                var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "true");
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("FDUClicked", (key) => "true");

                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(state.InstanceID.Value, state);
                WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<WorkflowStateBaseDTO>("WorkflowState", currentState.WorkflowState);

                return RedirectToAction(
                    currentState.CurrentActionDTO.ActionName,
                    currentState.CurrentActionDTO.ControllerName,
                new
                {
                    area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName
                });
            }

            return View(dto);

        }

        [HttpPost]
        public ActionResult Previous(FirmDetailsUserDTO dto)
        {
            WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<FirmDetailsUserDTO>(WorkflowDataEnum.FirmDetailUserData.GetStringValue(), dto);
            var state = WorkflowSessionHelper.GetWorkflowStateFromSession();

            object oValue1 = new object();
            var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "false");
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("FDUClicked", (key) => "true");

            var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(state.InstanceID.Value, state);
            WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<WorkflowStateBaseDTO>("WorkflowState", currentState.WorkflowState);

            if (currentState != null)
                return RedirectToAction(
                    currentState.CurrentActionDTO.ActionName,
                    currentState.CurrentActionDTO.ControllerName,
                new
                {
                    area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName
                });

            return View();
        }
    }
}