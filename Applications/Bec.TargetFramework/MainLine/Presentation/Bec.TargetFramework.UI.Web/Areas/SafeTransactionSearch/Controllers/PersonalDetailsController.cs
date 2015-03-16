using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.UI.Web.Areas.SafeTransactionSearch.Helpers;
using Bec.TargetFramework.UI.Web.Helpers;
using EnsureThat;
using Ext.Net;
using Ext.Net.MVC;
using Microsoft.Owin.Security.Provider;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Entities.Validators;
using Bec.TargetFramework.Workflow.Interfaces;
namespace Bec.TargetFramework.UI.Web.Areas.SafeTransactionSearch.Controllers
{
    [DirectController(AreaName = "SafeTransactionSearch")]
    public class PersonalDetailsController : Controller
    {
        private IWorkflowProcessService m_WorkflowProcessLogic;
        // GET: SafeTransactionSearch/PersonalDetails

        public PersonalDetailsController(IWorkflowProcessService logic)
        {
            m_WorkflowProcessLogic = logic;
        }
        public ActionResult Index()
        {
            var state = WorkflowSessionHelper.GetWorkflowStateFromSession();

            PersonalDetailDTO dto = new PersonalDetailDTO();
            if(state.WorkflowDictionaryDto.WorkflowDictionary.ContainsKey(WorkflowDataEnum.PersonalDetailData.GetStringValue()))
                dto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue());
            WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey(WorkflowDataEnum.PersonalDetailData.GetStringValue(), dto);
            Ext.Net.MessageBus.Default.Publish("TreeStructureReload");
            return View(dto);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Next(PersonalDetailDTO dto, AddressDTO address)
        {
            //if (ModelState.IsValid)
            //{
                   // var results = PersonalDetailsModelValidation(dto);
                        PersonalDetailDTO personaldetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue());
                        dto.OtherAddress = personaldetailsdto.OtherAddress;
                        dto.OtherNames = personaldetailsdto.OtherNames;
                        dto.Telephones = personaldetailsdto.Telephones;
                        dto.HomeAddress = address;
                        WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue(), dto);
                        // need to restart workflow
                        var state = WorkflowSessionHelper.GetWorkflowStateFromSession();

                        object oValue1 = new object();
                        //   var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
                        state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "true");
                        state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("PDClicked", (key) => "true");


                        var currentState = m_WorkflowProcessLogic.RestartWorkflowInstanceViaWebUI(state.InstanceID.Value, state);

                        currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("PDClicked", out oValue1);
                        currentState.WorkflowState.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
                        WorkflowSessionHelper.AddOrReplaceWorkflowStateToSession(currentState.WorkflowState);
                        var result2 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("PDClicked", out oValue1);
                        return RedirectToAction(
                            currentState.CurrentActionDTO.ActionName,
                            currentState.CurrentActionDTO.ControllerName,
                        new
                        {
                            area = string.IsNullOrEmpty(currentState.CurrentActionDTO.AreaName) ? "" : currentState.CurrentActionDTO.AreaName
                        });
                    //}
                    //else
                    //{
                    //    return this.PopulateFormErrors("FormErrors", results.ErrorMessages);
                    //}
                    
                        
            //        }
            //else
            //{
            //    var errors = ModelState.Values.SelectMany(v => v.Errors);
            //}
            return View(dto);
        
        }      
                
        public ActionResult EditOtherAddress(string id)
        {
            PersonalDetailDTO personalDetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue());
            List<AddressDTO> addresses = personalDetailsdto.Addressess;

            AddressDTO dto = null;

            if(!string.IsNullOrEmpty(id))
                if(addresses.Any(ad => ad.ID.Equals(id)))
                    dto = addresses.Single(ad => ad.ID.Equals(id));

            if(dto == null)
                dto = new AddressDTO();


            return View(dto);
        }

        //[DirectMethod]
        public ActionResult ShowEditOtherAddressWindow(string id)
        {
            Ext.Net.Window window = new Window.Builder()
                .ID("OtherAddressEditWindow")
                .Title("Edit Address")
                .Icon(Icon.Application)
                .AutoRender(false)
                .Width(500)
                .Height(500)
                .CloseAction(CloseAction.Destroy)
                .BodyPadding(5)
                .Modal(true)
                .Loader(Html.X()
                    .ComponentLoader()
                    .Url(Url.Action("EditOtherAddress", "PersonalDetails", new { area = "SafeTransactionSearch", id = id }))
                    .Mode(LoadMode.Frame));

            window.Render(RenderMode.AddTo, "PersonalDetailForm");

            window.Show();

            return this.Direct();
        }

        //[HttpPost]
        //[DirectMethod]
        public ActionResult ShowAddOtherAddressWindow()
        {
            Ext.Net.Window window = new Window.Builder()
                .ID("OtherAddressAddWindow")
                .Title("Add Address")
                .Icon(Icon.Application)
                .AutoRender(false)
                .Width(500)
                .Height(500)
                .CloseAction(CloseAction.Destroy)
                .BodyPadding(5)
                .Modal(true)
                .Loader(Html.X()
                    .ComponentLoader()
                    .Url(Url.Action("OtherAddress", "PersonalDetails", new { area = "SafeTransactionSearch" }))
                    .Mode(LoadMode.Frame));

            window.Render(RenderMode.AddTo, "PersonalDetailForm");

            window.Show();

            return this.Direct();
        }

        //[HttpPost]
        public ActionResult OtherAddress(AddressDTO model)
        {
            if(ModelState.IsValid)
            {
                PersonalDetailDTO personalDetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue());
                List<AddressDTO> addresses = personalDetailsdto.Addressess;

               model.ID = Guid.NewGuid().ToString();

                addresses.Add(model);
                personalDetailsdto.Addressess = addresses;
                WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue(), personalDetailsdto);

                Ext.Net.MessageBus.Default.Publish("AddOtherAddress");
            }

            return View(model);
        }

        public ActionResult CloseOtherAddress()
        {
            Ext.Net.MessageBus.Default.Publish("AddOtherAddress");

            return this.Direct();
        }

        public StoreResult GetOtherAddresses()
        {
            PersonalDetailDTO dto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue());
            List<AddressDTO> addresses = dto.Addressess;
            return this.Store(addresses);
        }
        

        [DirectMethod]
        public ActionResult ChangeAddressOther(string value)
        {
            Ensure.That(value).IsNotNullOrEmpty();

            var result = new Ext.Net.MVC.PartialViewResult
            {
                RenderMode = RenderMode.AddTo,
                Model = new AddressDTO(),
                ClearContainer = true,
                ContainerId = "OutsideOtherAddressContainer",
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            }; 

            if (value.Equals("1"))
                result.ViewName = "_AddressInternational";
            else
                result.ViewName = "_AddressPartial";

            return result;
        }

        [DirectMethod]
        public ActionResult ChangeAddress(string value)
        {
            Ensure.That(value).IsNotNullOrEmpty();

            var result = new Ext.Net.MVC.PartialViewResult
            {
                RenderMode = RenderMode.AddTo,
                Model = new AddressDTO(),
                ClearContainer = true,
                ContainerId = "AddressContainer",
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            }; 

            if (value.Equals("1"))
                result.ViewName = "_AddressInternational";
            else
                result.ViewName = "_AddressPartial";

            return result;
        }

        #region Data Management


        public StoreResult GetOtherNames()
        {
            PersonalDetailDTO dto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue());
            List<OtherNameDTO> telephoneAccounts = dto.OtherNames;

            return this.Store(telephoneAccounts);
        }

        [DirectMethod]
        public ActionResult SaveOtherName(string values)
        {
            var dto = DTOHelper.GetDtoFromJsonObject<OtherNameDTO>(ServiceStack.Text.JsonObject.Parse(values));

            if (string.IsNullOrEmpty(dto.ID))
                dto.ID = Guid.NewGuid().ToString();

            PersonalDetailDTO personalDetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue());
            List<OtherNameDTO> names = personalDetailsdto.OtherNames;

            if (names.Any(s => s.ID.Equals(dto.ID)))
            {
                var ca = names.Single(s => s.ID.Equals(dto.ID));

                ca.FirstName = dto.FirstName;
                ca.LastName = dto.LastName;
                ca.MiddleName = dto.MiddleName;
                ca.TitleTypeID = dto.TitleTypeID;
            }
            else
                names.Add(dto);
            personalDetailsdto.OtherNames = names;
            WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue(), personalDetailsdto);

            Ext.Net.MessageBus.Default.Publish("AddOtherNameGridLoad");

            return this.Direct(new { valid = true });

           // return this.Direct(personalDetailsdto);
        }

        [DirectMethod]
        public ActionResult DeleteOtherName(string values)
        {
            var dto = DTOHelper.GetDtoFromJsonObject<OtherNameDTO>(ServiceStack.Text.JsonObject.Parse(values));

            PersonalDetailDTO personalDetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue());
            List<OtherNameDTO> names = personalDetailsdto.OtherNames;

            if (names.Any(s => s.ID.Equals(dto.ID)))
            {
                var dtoToRemove = names.Single(s => s.ID.Equals(dto.ID));

                names.Remove(dtoToRemove);

                personalDetailsdto.OtherNames = names;
                WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue(), personalDetailsdto);

            }

            Ext.Net.MessageBus.Default.Publish("AddOtherNameGridLoad");

            return this.Direct(new { valid = true });
            //return this.Direct(personalDetailsdto);
        }

        public StoreResult GetTelephoneNumbers()
        {
            PersonalDetailDTO dto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue());
            List<TelephoneDTO> telephoneAccounts = dto.Telephones;

            return this.Store(telephoneAccounts);
        }

        [DirectMethod]
        public ActionResult SaveTelephone(string values)
        {
            var dto = DTOHelper.GetDtoFromJsonObject<TelephoneDTO>(ServiceStack.Text.JsonObject.Parse(values));

           if (string.IsNullOrEmpty(dto.ID))
                dto.ID = Guid.NewGuid().ToString();

           PersonalDetailDTO personalDetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue());
           List<TelephoneDTO> telephones = personalDetailsdto.Telephones;

            if (telephones.Any(s => s.ID.Equals(dto.ID)))
            {
                var ca = telephones.Single(s => s.ID.Equals(dto.ID));

                ca.TelephoneNumber = dto.TelephoneNumber;
                ca.TelephoneNumberTypeID = dto.TelephoneNumberTypeID;
            }
            else
                telephones.Add(dto);
            personalDetailsdto.Telephones = telephones;
            WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue(), personalDetailsdto);

            Ext.Net.MessageBus.Default.Publish("AddTelephoneGridLoad");

            return this.Direct(new { valid = true });
           // return this.Direct(personalDetailsdto);
        }

        [DirectMethod]
        public ActionResult DeleteTelephone(string values)
        {
            var dto = DTOHelper.GetDtoFromJsonObject<TelephoneDTO>(ServiceStack.Text.JsonObject.Parse(values));

            PersonalDetailDTO personalDetailsdto = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue());
            List<TelephoneDTO> telephones = personalDetailsdto.Telephones;

            if (telephones.Any(s => s.ID.Equals(dto.ID)))
            {
                var dtoToRemove = telephones.Single(s => s.ID.Equals(dto.ID));

                telephones.Remove(dtoToRemove);
                personalDetailsdto.Telephones = telephones;
                WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey<PersonalDetailDTO>(WorkflowDataEnum.PersonalDetailData.GetStringValue(), personalDetailsdto);
            }

            Ext.Net.MessageBus.Default.Publish("AddTelephoneGridLoad");

            return this.Direct(new { valid = true });
           // return this.Direct(personalDetailsdto);
        }

        public virtual JsonResult ValidateTelephone()
        {
            List<TelephoneDTO> telephones = new List<TelephoneDTO>();
           //WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<TelephoneDTO>>("Telephones");

            bool valid = true;
            var accountName = Request.Form["value"];
            var id = Request.Form["id"];
            if (telephones.Any(s => s.TelephoneNumber.ToLower().Equals(accountName.ToLower()) && !s.ID.Equals(id)))
                valid = false;

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }


        private ValidationWrapper AddressYearsValidation(PersonalDetailDTO model)
        {
            PersonalDetailsDTOValidator validator = new PersonalDetailsDTOValidator();
            validator.AddValidationActionToIPValidationList("PersonalDetailsPanel", "AddressYears", () =>
            {
                return IsAddressYearsValid(model);
            });


            var wrapper = validator.ValidateUsingIPValidationList("PersonalDetailsPanel");
            return wrapper;

        }
        
        private bool IsAddressYearsValid(PersonalDetailDTO model)
        {
            int YearsCount = Convert.ToInt32(model.YearsLivingFor);
            int MonthCount = Convert.ToInt32(model.MonthsLivingFor);
            bool IsAddressYearsValid = false;
            int TotalMonths = 0;
            List<AddressDTO> addresses = new List<AddressDTO>();  // WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<AddressDTO>>("OtherAddresses");

            if (addresses != null)
            {
                foreach (AddressDTO address in addresses)
                {
                    YearsCount = YearsCount + address.AddressYear;
                    MonthCount = MonthCount + address.AddressMonths;
                }
            }

            TotalMonths = YearsCount * 12 + MonthCount;
            if(TotalMonths >= 36)
            {
                IsAddressYearsValid = true;
            }

            return IsAddressYearsValid;
        }

        private ValidationWrapper PersonalDetailsModelValidation(PersonalDetailDTO model)
        {
            PersonalDetailsDTOValidator validator = new PersonalDetailsDTOValidator();
            if(!IsAddressYearsValid(model))
            {
                validator.AddValidationActionToIPValidationList("PersonalDetailsPanel", "AddressYearsValid", () =>
                {
                    return true;
                });
            }
            var wrapper = validator.ValidateUsingIPValidationList("PersonalDetailsPanel");
            return wrapper;
        }

        #endregion
    }
}