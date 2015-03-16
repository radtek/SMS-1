using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.UI.Web.Areas.SafeTransactionSearch.Helpers;
using Bec.TargetFramework.UI.Web.Helpers;
using Bec.TargetFramework.Web.Framework.Helpers;
using Bec.TargetFramework.Workflow.Interfaces;
using Ext.Net;
using Ext.Net.MVC;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
namespace Bec.TargetFramework.UI.Web.Areas.SafeTransactionSearch.Controllers
{
    [DirectController(AreaName="SafeTransactionSearch")]
    public class FirmDetailController : Controller
    {
        private IWorkflowProcessService m_WorkflowProcessLogic;
        private IOrganisationLogic m_OrganisationLogic;
        private IDataLogic m_DataLogic;

        public FirmDetailController(IWorkflowProcessService logic,IOrganisationLogic oLogic,IDataLogic dLogic)

        {
            m_WorkflowProcessLogic = logic;
            m_OrganisationLogic = oLogic;
            m_DataLogic = dLogic;
        }

        public ActionResult Index()
        {

            var state = WorkflowSessionHelper.GetWorkflowStateFromSession();
            FirmDetailsDTO firmDetailDto = new FirmDetailsDTO();
            if (state.WorkflowDictionaryDto.WorkflowDictionary.ContainsKey(WorkflowDataEnum.FirmDetailData.GetStringValue()))
                firmDetailDto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue());
            WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey("ClientAccounts", new List<ClientAccountDTO>());
            WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey("TradingNames", new List<TradingNameDTO>());
            Ext.Net.MessageBus.Default.Publish("TreeStructureReload");
            return View(firmDetailDto);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Next(FirmDetailsDTO dto)
        {

           // if (ModelState.IsValid)
           // {
                WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue(), dto);
                var state = WorkflowSessionHelper.GetWorkflowStateFromSession();
                object oValue1 = new object();
                var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "true");
                state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("FDClicked", (key) => "true");

                var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(state.InstanceID.Value, state);
                currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("FDClicked", out oValue1);
                currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
                WorkflowSessionHelper.AddOrReplaceWorkflowStateToSession(currentState.WorkflowState);

                return RedirectToAction(
                    currentState.CurrentActionDTO.ActionName,
                    currentState.CurrentActionDTO.ControllerName,
                new
                {
                    area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName
                });
       //     }

            return View(dto);

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Previous(FirmDetailsDTO dto)
        {

            WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue(), dto);
            var state = WorkflowSessionHelper.GetWorkflowStateFromSession();

            object oValue1 = new object();
            var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "false");
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("FDClicked", (key) => "true");

            var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(state.InstanceID.Value, state);

            currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("FDClicked", out oValue1);
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
       

        #region Data Management

        public StoreResult GetClientAccounts()
        {
             List<ClientAccountDTO> clientAccounts =
                WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<ClientAccountDTO>>("ClientAccounts");
           // FirmDetailsDTO dto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue());
            //List<ClientAccountDTO> clientAccounts = new List<ClientAccountDTO>(); // dto.ClientAccounts;

            return this.Store(clientAccounts);
        }

        private ClientAccountDTO GetClientAccountDtoFromJsonObject(ServiceStack.Text.JsonObject jsonObject)
        {
            // get values as required
            ClientAccountDTO dto = new ClientAccountDTO();

            // get values as required
            if (jsonObject.ContainsKey("AccountName"))
                dto.AccountName = jsonObject["AccountName"].ToString();

            if (jsonObject.ContainsKey("SortCode"))
                dto.SortCode = jsonObject["SortCode"].ToString();

            if (jsonObject.ContainsKey("AccountNumber"))
                dto.AccountNumber = long.Parse(jsonObject["AccountNumber"].ToString());

            if (jsonObject.ContainsKey("ID"))
                dto.ID = jsonObject["ID"].ToString();

            return dto;
        }

        [DirectMethod]
        public ActionResult SaveClientAccount(string values)
        {
            ServiceStack.Text.JsonObject jsonObject = ServiceStack.Text.JsonObject.Parse(values);

            var dto = GetClientAccountDtoFromJsonObject(jsonObject);

            if (string.IsNullOrEmpty(dto.ID))
                dto.ID = Guid.NewGuid().ToString();

            //FirmDetailsDTO firmDetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue());
            //List<ClientAccountDTO> clientAccounts = new List<ClientAccountDTO>(); // firmDetailsdto.ClientAccounts;
            List<ClientAccountDTO> clientAccounts =
               WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<ClientAccountDTO>>("ClientAccounts");


            if (clientAccounts.Any(s => s.ID.Equals(dto.ID)))
            {
                var ca = clientAccounts.Single(s => s.ID.Equals(dto.ID));

                ca.AccountNumber = dto.AccountNumber;
                ca.AccountName = dto.AccountName;
                ca.SortCode = dto.SortCode;
            }
            else
                clientAccounts.Add(dto);

           // firmDetailsdto.ClientAccounts = clientAccounts;
           // WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue(), firmDetailsdto);
            WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<List<ClientAccountDTO>>("ClientAccounts", clientAccounts);


            Ext.Net.MessageBus.Default.Publish("AddClientAccountGridLoad");

            return this.Direct(new { valid = true });
        }

        [DirectMethod]
        public ActionResult DeleteClientAccount(string values)
        {
            ServiceStack.Text.JsonObject jsonObject = ServiceStack.Text.JsonObject.Parse(values);

            var dto = GetClientAccountDtoFromJsonObject(jsonObject);

            //FirmDetailsDTO firmDetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue());
            //List<ClientAccountDTO> clientAccounts = new List<ClientAccountDTO>(); // firmDetailsdto.ClientAccounts;
            List<ClientAccountDTO> clientAccounts =
              WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<ClientAccountDTO>>("ClientAccounts");



            if (clientAccounts.Any(s => s.ID.Equals(dto.ID)))
            {
                var dtoToRemove = clientAccounts.Single(s => s.ID.Equals(dto.ID));

                clientAccounts.Remove(dtoToRemove);

                //firmDetailsdto.ClientAccounts = clientAccounts;
                //WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue(), firmDetailsdto);
                WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<List<ClientAccountDTO>>("ClientAccounts", clientAccounts);

            }

            Ext.Net.MessageBus.Default.Publish("AddClientAccountGridLoad");

            return this.Direct(new { valid = true });
        }

        

        [DirectMethod]
        public ActionResult ValidateClientAccountOnSave(string values)
        {
            ServiceStack.Text.JsonObject jsonObject = ServiceStack.Text.JsonObject.Parse(values);

            var dto = GetClientAccountDtoFromJsonObject(jsonObject);

            if (!string.IsNullOrEmpty(dto.AccountName))
            {
                //FirmDetailsDTO firmDetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue());
                //List<ClientAccountDTO> clientAccounts = new List<ClientAccountDTO>(); // firmDetailsdto.ClientAccounts;
                List<ClientAccountDTO> clientAccounts =
            WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<ClientAccountDTO>>("ClientAccounts");



                if (clientAccounts.Any(s => s.AccountName.ToLower().Equals(dto.AccountName.ToLower()) && !s.ID.Equals(dto.ID)))
                {
                    return this.Direct(new { valid = false, msg = "Account Name: " + dto.AccountName + " already exists." });
                }
                else
                    return this.Direct(new { valid = true });
            }

            return this.Direct( new { valid = true });
        }

        public virtual JsonResult ValidateClientAccount()
        {
            //FirmDetailsDTO firmDetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue());
            //List<ClientAccountDTO> clientAccounts = new List<ClientAccountDTO>(); // firmDetailsdto.ClientAccounts;
            List<ClientAccountDTO> clientAccounts =
           WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<ClientAccountDTO>>("ClientAccounts");

            bool valid = true;
            var accountName = Request.Form["value"];
            var id = Request.Form["id"];
            if (clientAccounts.Any(s => s.AccountName.ToLower().Equals(accountName.ToLower()) && !s.ID.Equals(id)))
                valid = false;

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region Remote Validation

        public virtual JsonResult DoesFirmNameExist(string value)
        {
            bool valid = true;
            if (!string.IsNullOrEmpty(value))
                valid = !(m_OrganisationLogic.DoesOrganisationNameExist(value));

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Trading Names


        public ActionResult AddTradingName()
        {
            var tradingNames = new TradingNameDTO();

            Session["TradingNames"] = tradingNames;

            return View(tradingNames);
        }
        [HttpPost]
        public ActionResult AddTradingName(TradingNameDTO dto)
        {
            //FirmDetailsDTO firmDetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue());
            //List<TradingNameDTO> tradingNames = new List<TradingNameDTO>();//firmDetailsdto.TradingNames;

            List<TradingNameDTO> tradingNames =
                WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<TradingNameDTO>>("TradingNames");

            if(tradingNames.Count > 0)
                Ext.Net.MessageBus.Default.Publish("AddTradingName",tradingNames.First().TradingName);
            else
                Ext.Net.MessageBus.Default.Publish("AddTradingName");

            return this.FormPanel(this.ModelState);
        }

        public StoreResult GetTradingNames()
        {
            //FirmDetailsDTO firmDetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue());
            //List<TradingNameDTO> tradingNames = new List<TradingNameDTO>();//firmDetailsdto.TradingNames;
            List<TradingNameDTO> tradingNames =
                WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<TradingNameDTO>>("TradingNames");

            return this.Store(tradingNames);
        }

        [DirectMethod]
        public ActionResult SaveTradingName(string values)
        {
            ServiceStack.Text.JsonObject jsonObject = ServiceStack.Text.JsonObject.Parse(values);

            var dto = GetTradingNameDtoFromJsonObject(jsonObject);
            
            if(string.IsNullOrEmpty(dto.ID))
                dto.ID = Guid.NewGuid().ToString();

            //FirmDetailsDTO firmDetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue());
            //List<TradingNameDTO> names = new List<TradingNameDTO>();//firmDetailsdto.TradingNames;

            List<TradingNameDTO> names =
               WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<TradingNameDTO>>("TradingNames");

            // update if alrady exists
            if (names.Any(s => s.ID.Equals(dto.ID)))
            {
                var name = names.Single(s => s.ID.Equals(dto.ID));

                name.TradingName = dto.TradingName;
            }
            else
                names.Add(dto);
           // firmDetailsdto.TradingNames = names;
           // WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue(), firmDetailsdto);
            WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<List<TradingNameDTO>>("TradingNames", names);

            Ext.Net.MessageBus.Default.Publish("AddTradingNameGridLoad");

            return this.Direct(new { valid = true });
        }

        [DirectMethod]
        public ActionResult DeleteTradingName(string values)
        {
            ServiceStack.Text.JsonObject jsonObject = ServiceStack.Text.JsonObject.Parse(values);

            var dto = GetTradingNameDtoFromJsonObject(jsonObject);

            //FirmDetailsDTO firmDetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue());
            //List<TradingNameDTO> names = new List<TradingNameDTO>(); // firmDetailsdto.TradingNames;
            List<TradingNameDTO> names =
               WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<TradingNameDTO>>("TradingNames");

            if(names.Any(s => s.ID.Equals(dto.ID)))
            {
                var dtoToRemove = names.Single(s => s.ID.Equals(dto.ID));

                names.Remove(dtoToRemove);

                //firmDetailsdto.TradingNames = names;
               // WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue(), firmDetailsdto);
                WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<List<TradingNameDTO>>("TradingNames", names);



            }

            Ext.Net.MessageBus.Default.Publish("AddTradingNameGridLoad");
           
            return this.Direct(new { valid = true });
        }

        private TradingNameDTO GetTradingNameDtoFromJsonObject(ServiceStack.Text.JsonObject jsonObject)
        {
            TradingNameDTO dto = new TradingNameDTO();

            // get values as required
            if (jsonObject.ContainsKey("TradingName"))
                dto.TradingName = jsonObject["TradingName"].ToString();

            if (jsonObject.ContainsKey("ID"))
                dto.ID = jsonObject["ID"].ToString();

            return dto;
        }

        [DirectMethod]
        public ActionResult ValidateTradingNameOnSave(string values)
        {
            ServiceStack.Text.JsonObject jsonObject = ServiceStack.Text.JsonObject.Parse(values);

            var dto = GetTradingNameDtoFromJsonObject(jsonObject);

            if (!string.IsNullOrEmpty(dto.TradingName))
            {
                //FirmDetailsDTO firmDetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue());
                //List<TradingNameDTO> names = new List<TradingNameDTO>(); // firmDetailsdto.TradingNames;
                List<TradingNameDTO> names =
           WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<TradingNameDTO>>("TradingNames");



                if (names.Any(s => s.TradingName.ToLower().Equals(dto.TradingName.ToLower()) && !s.ID.Equals(dto.ID)))
                {
                    return this.Direct(new { valid = false, msg = "Trading Name: " + dto.TradingName + " already exists." });
                }
                else
                    return this.Direct(new { valid = true });
            }

            return this.Direct(new { valid = true });
        }

        public virtual JsonResult ValidateTradingName()
        {
            //FirmDetailsDTO firmDetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<FirmDetailsDTO>(WorkflowDataEnum.FirmDetailData.GetStringValue());
            //List<TradingNameDTO> names = new List<TradingNameDTO>(); // firmDetailsdto.TradingNames;
            List<TradingNameDTO> names =
           WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<TradingNameDTO>>("TradingNames");

            bool valid = true;
            var tradingName = Request.Form["value"];
            var id = Request.Form["id"];
            if (names.Any(s => s.TradingName.ToLower().Equals(tradingName.ToLower()) && !s.ID.Equals(id)))
                valid = false;

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }


        #endregion
    }
}