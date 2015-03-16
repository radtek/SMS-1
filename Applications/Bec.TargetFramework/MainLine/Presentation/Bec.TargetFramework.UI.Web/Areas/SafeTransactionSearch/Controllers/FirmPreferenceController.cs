using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.UI.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Workflow.Interfaces;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
namespace Bec.TargetFramework.UI.Web.Areas.SafeTransactionSearch.Controllers
{
    public class FirmPreferenceController : Controller
    {
        private IWorkflowProcessService m_WorkflowProcessLogic;
        private IDataLogic m_DataLogic;
        public FirmPreferenceController(IWorkflowProcessService logic, IDataLogic dLogic)
        {
            m_WorkflowProcessLogic = logic;
            m_DataLogic = dLogic;
        }

        // GET: SafeTransactionSearch/FirmPreference
        public ActionResult Index()
        {
            Ext.Net.MessageBus.Default.Publish("TreeStructureReload");
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Next(FirmPreferenceDTO dto)
        {
            if (ModelState.IsValid)
            {
                WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<FirmPreferenceDTO>(WorkflowDataEnum.FirmPreferenceData.GetStringValue(), dto);
                // need to restart workflow
                var state = WorkflowSessionHelper.GetWorkflowStateFromSession();

                object oValue1 = new object();
                var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "true");
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("FPClicked", (key) => "true");
                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(state.InstanceID.Value, state);
                currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("FPClicked", out oValue1);
                currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
                WorkflowSessionHelper.AddOrReplaceWorkflowStateToSession(currentState.WorkflowState);

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
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Previous(FirmPreferenceDTO dto)
        {
                WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<FirmPreferenceDTO>(WorkflowDataEnum.FirmPreferenceData.GetStringValue(), dto);
                var state = WorkflowSessionHelper.GetWorkflowStateFromSession();

                object oValue1 = new object();
                var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "false");
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("FPClicked", (key) => "true");
                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(state.InstanceID.Value, state);
                currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("FPClicked", out oValue1);
                currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
                WorkflowSessionHelper.AddOrReplaceWorkflowStateToSession(currentState.WorkflowState);

            if(currentState != null)
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