using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Workflow;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Workflow.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using ServiceStack.Text;
using Fabrik.Common;

namespace Bec.TargetFramework.UI.Web.Areas.SafeTransactionSearch.Controllers
{
    [AllowAnonymous]
    public class SignUpController : Controller
    {
        private IWorkflowProcessService m_WorkflowProcessLogic;


        public SignUpController(IWorkflowProcessService logic)
    
        {
            m_WorkflowProcessLogic = logic;
        }

        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CONextSteps(bool isProcessed = false)
        {
            if (!isProcessed)
            {
                var dto = Session["WorkflowDTO"] as WorkflowInstanceCurrentStateDTO;
                var statedata = m_WorkflowProcessLogic.GetDataForWorkflowInstanceStatusEvent(dto.CurrentActionDTO.WorkflowInstanceExecutionStatusEventID);
                Session.Add("WorkflowState", statedata);
                Session.Add("WorkflowInstanceID", dto.InstanceDTO.WorkflowInstanceID);
            }

            return View("CONextSteps");
        }

        [HttpPost]
        public ActionResult CONextSteps(WorkflowActionDTO WorkflowActionDTO)
        {
            if (ModelState.IsValid)
            {
                var instanceID = Session["WorkflowInstanceID"] as Guid?;
                var state = Session["WorkflowState"] as WorkflowStateBaseDTO;

                object oValue1 = new object();
                var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NSClicked", (key) => "true");
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "true");

                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(instanceID.Value, state);

                Session["WorkflowState"] = currentState.WorkflowState;

                return RedirectToAction(

                    currentState.CurrentActionDTO.ActionName,
                    currentState.CurrentActionDTO.ControllerName,
                new
                {
                    area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName
                });
            }
            return View();
        }

        public ActionResult InternalInviteUserNextSteps()
        {
            return View();
        }

        public ActionResult ExternalInviteUserNextSteps()
        {
            return View();
        }

       
        public ActionResult TermsandConditions()
        {

            var state = Session["WorkflowState"] as WorkflowStateBaseDTO;            
            Session["WorkflowState"] = state;
           // var dto = Session["WorkflowDTO"] as WorkflowInstanceCurrentStateDTO;

            // get json for current step
            //var data = m_WorkflowProcessLogic.GetDataForWorkflowInstanceStatusEvent(
            //        dto.CurrentActionDTO.WorkflowInstanceExecutionStatusEventID);

            //// do the rest
            //dto.InstanceExecutionDataItemDTO = new WorkflowInstanceExecutionDataItemDTO();
            //dto.WorkflowState = data;

            //// because I am lazy in this test version, dumping state in session, do not copy for real actions
            //Session.Add("WorkflowState", dto.WorkflowState);
            //Session.Add("WorkflowInstanceID", dto.InstanceDTO.WorkflowInstanceID);
            //change the requited dto from dto to registration or relevant
            return View("TermsandConditions");
        }

      

        [HttpPost]
        public ActionResult TermsandConditionsPrevious(RegistrationDTO model)
        {
             //if (ModelState.IsValid)
            //{
               var instanceID = Session["WorkflowInstanceID"] as Guid?;
               var state = Session["WorkflowState"] as WorkflowStateBaseDTO;

                object oValue1 = new object();
                var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "false");
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("TNCClicked", (key) => "true");


                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(instanceID.Value, state);

                Session["WorkflowState"] = currentState.WorkflowState;

                return RedirectToAction(
                    currentState.CurrentActionDTO.ActionName,
                    currentState.CurrentActionDTO.ControllerName,
                new
                {
                    area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName,
                    isProcessed = true

                });
            //} 
            //return View();
        }

        [HttpPost]
        public ActionResult TermsandConditionsNext(RegistrationDTO model)
        {
            //if (ModelState.IsValid)
            //{
                // need to restart workflow
                var instanceID = Session["WorkflowInstanceID"] as Guid?;
                var state = Session["WorkflowState"] as WorkflowStateBaseDTO;

                object oValue1 = new object();
                var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "true");
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("TNCClicked", (key) => "true");

                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(instanceID.Value, state);

                Session["WorkflowState"] = currentState.WorkflowState;

                return RedirectToAction(
                    currentState.CurrentActionDTO.ActionName,
                    currentState.CurrentActionDTO.ControllerName,
                new
                {
                    area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName
                });

            //} 
            //return View();
        }

        public ActionResult ConveyancerPersonalDetails()
        {
            var state = Session["WorkflowState"] as WorkflowStateBaseDTO;
            Session["WorkflowState"] = state;
            return View("ConveyancerPersonalDetails");
        }

        [HttpPost]
        public ActionResult ConveyancerPersonalDetails(RegistrationDTO model)
        {
            //if (ModelState.IsValid)
            //{
            // need to restart workflow
            var instanceID = Session["WorkflowInstanceID"] as Guid?;
            var state = Session["WorkflowState"] as WorkflowStateBaseDTO;

            object oValue1 = new object();
            var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "true");
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("PDClicked", (key) => "true");

            var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(instanceID.Value, state);

            Session["WorkflowState"] = currentState.WorkflowState;

            return RedirectToAction(
                currentState.CurrentActionDTO.ActionName,
                currentState.CurrentActionDTO.ControllerName,
            new
            {
                area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName
            });

            //} 
            //return View();
        }

        public ActionResult PublicPersonalDetails()
        {
            return View();
        }

        [OverrideActionFilters]
        [AllowAnonymous]
       
        public ActionResult COFirmDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult COFirmDetailsPrevious(RegistrationDTO model)
        {
            //if (ModelState.IsValid)
            //{
            // need to restart workflow
            var instanceID = Session["WorkflowInstanceID"] as Guid?;
            var state = Session["WorkflowState"] as WorkflowStateBaseDTO;

            object oValue1 = new object();
            var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "false");
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("FDClicked", (key) => "true");

            var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(instanceID.Value, state);

            Session["WorkflowState"] = currentState.WorkflowState;

            return RedirectToAction(
                currentState.CurrentActionDTO.ActionName,
                currentState.CurrentActionDTO.ControllerName,
            new
            {
                area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName
            });

            //} 
            //return View();
        }

        [HttpPost]
        public ActionResult COFirmDetailsNext(RegistrationDTO model)
        {
            //if (ModelState.IsValid)
            //{
            // need to restart workflow
            var instanceID = Session["WorkflowInstanceID"] as Guid?;
            var state = Session["WorkflowState"] as WorkflowStateBaseDTO;

            object oValue1 = new object();
            var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "true");
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("FDClicked", (key) => "true");

            var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(instanceID.Value, state);

            Session["WorkflowState"] = currentState.WorkflowState;

            return RedirectToAction(
                currentState.CurrentActionDTO.ActionName,
                currentState.CurrentActionDTO.ControllerName,
            new
            {
                area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName
            });

            //} 
            //return View();
        }
        public ActionResult UserFirmDetails()
        {
            return View();
        }

        public ActionResult BranchesandUsers()
        {
            return View();
        }

        public ActionResult PreAuthPayment()
        {
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PaymentPrevious(RegistrationDTO model)
        {
            //if (ModelState.IsValid)
            //{
            // need to restart workflow
            var instanceID = Session["WorkflowInstanceID"] as Guid?;
            var state = Session["WorkflowState"] as WorkflowStateBaseDTO;

            object oValue1 = new object();
            var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "false");
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("PayClicked", (key) => "true");

            var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(instanceID.Value, state);

            Session["WorkflowState"] = currentState.WorkflowState;

            return RedirectToAction(
                currentState.CurrentActionDTO.ActionName,
                currentState.CurrentActionDTO.ControllerName,
            new
            {
                area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName
            });

            //} 
            //return View();
        }
        [HttpPost]
        public ActionResult PaymentNext(RegistrationDTO model)
        {
            //if (ModelState.IsValid)
            //{
            // need to restart workflow
            var instanceID = Session["WorkflowInstanceID"] as Guid?;
            var state = Session["WorkflowState"] as WorkflowStateBaseDTO;

            object oValue1 = new object();
            var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "true");
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("PayClicked", (key) => "true");

            var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(instanceID.Value, state);

            Session["WorkflowState"] = currentState.WorkflowState;

            return RedirectToAction(
                currentState.CurrentActionDTO.ActionName,
                currentState.CurrentActionDTO.ControllerName,
            new
            {
                area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName
            });

            //} 
            //return View();
        }


        [OverrideActionFilters]
        [AllowAnonymous]
        public virtual ActionResult AddTradingNameWindow()
        {
            Ext.Net.Window window = new Window.Builder()
                .ID("TradingNameAddWindow")
                .Title("Additional Trading Names")
                .Icon(Icon.Application)
                .AutoRender(false)
                .Width(500)
                .Height(300)
                .CloseAction(CloseAction.Destroy)
                .BodyPadding(5)
                .Modal(true)
                .Loader(Html.X()
                    .ComponentLoader()
                    .AjaxOptions(new AjaxOptions { Method = HttpMethod.POST })
                    .Url(Url.Action("AddTradingName", "SignUp", new { area = "SafeTransactionSearch"}))
                    .Mode(LoadMode.Frame));

            window.Render(RenderMode.AddTo, "FirmDetailsForm");

            window.Show();

            return this.Direct();
        }


        [AllowAnonymous]

        public ActionResult AddTradingName()
        {
            var tradingNames = new TradingNameDTO();

            Session["TradingNames"] = tradingNames;

            return View(tradingNames);
        }

        [HttpGet]
        public virtual ActionResult GetTradingNames()
        {
            return null;
            //return Json(new { data = (Session["TradingNames"] as TradingNameDTO).TradingNames }, JsonRequestBehavior.AllowGet);
        }


        [OverrideActionFilters]
        [AllowAnonymous]
        //add a new trading name
        public ActionResult AddTradingNames(TradingNameDTO tradingName)
        {
            ////var hidden = this.GetCmp<Hidden>("TradingNameJson");
            //var dto = (Session["TradingNames"] as TradingNameDTO);

            //dto.TradingNames.Insert(0,new OrganisationTradingNameDTO { Name = "Trading Name", OrganisationTradingNameID = dto.TradingNames.Count });

            //Session["TradingNames"] = dto;

            //Ext.Net.MessageBus.Default.Publish("AddTradingName");

            return this.Direct();
        }



    }
}