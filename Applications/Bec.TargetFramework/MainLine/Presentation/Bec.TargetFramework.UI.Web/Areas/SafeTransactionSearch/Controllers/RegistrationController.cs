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
using BrockAllen.MembershipReboot;
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
using Bec.TargetFramework.UI.Web.Helpers;
using Bec.TargetFramework.Security;




namespace Bec.TargetFramework.UI.Web.Areas.SafeTransactionSearch.Controllers
{
    [AllowAnonymous]
    public class RegistrationController : Controller
    {
        AuthenticationService authSvc;
        private IWorkflowProcessService m_WorkflowProcessLogic;
        private ILogger logger;
        private IValidationLogic m_ValidationLogic;
        private IDataLogic m_DataLogic;
        private IUserLogic m_UserLogic;

        public RegistrationController(ILogger logger, IWorkflowProcessService logic, IValidationLogic validationLogic,IDataLogic dLogic, IUserLogic userLogic)
        {
            this.logger = logger;
            this.m_WorkflowProcessLogic = logic;
            this.m_ValidationLogic = validationLogic;
            this.m_UserLogic = userLogic; 
            m_DataLogic = dLogic;

        }

       
        // : Controller    {GET: Register
        [OverrideActionFilters]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var RegistrationDTO = new RegistrationDTO();
            ViewData["PublicKey"] = ConfigurationManager.AppSettings["ReCaptchaPublicKey"];
            ViewData["Response"] = "";
            ViewData["Challenge"] = "";

            return View(RegistrationDTO);
        }


        private ValidationWrapper RegistrationModelValidation(RegistrationDTO model)
        {
            RegistrationDTOValidator validator = new RegistrationDTOValidator();

            RegistrationValidationErrorDTO duplicateCOValidationError = m_ValidationLogic.DuplicateComplianceOfficer(model.CORegulator, model.CORegulatorNumber, model.FirmRegisteredName, model.FirmTradingName, model.COLastName, model.COEmail);
            RegistrationValidationErrorDTO alreadyExistingCOValidationError = m_ValidationLogic.DuplicateCompany(model.FirmRegulator, model.COOfficeBranchRegulatorNumber, model.FirmRegisteredName, model.FirmTradingName, model.COLastName, model.COEmail);
            RegistrationValidationErrorDTO anotherFirmCOValidationError = m_ValidationLogic.COwithAnotherFirm(model.CORegulator, model.CORegulatorNumber, model.FirmRegisteredName, model.FirmTradingName, model.COLastName, model.COEmail);

            validator.AddValidationActionToIPValidationList("Register", "STS_DuplicateCO", () =>
            {
                return duplicateCOValidationError.HasError;
            });

            validator.AddValidationActionToIPValidationList("Register", "STS_AlreadyExistingCO", () =>
            {
                return alreadyExistingCOValidationError.HasError;
            });

            validator.AddValidationActionToIPValidationList("Register", "STS_AnotherFirmCO", () =>
            {
                return anotherFirmCOValidationError.HasError;
            });

            if (model.CORegulator.ToUpper() == "SRA")
            {
                validator.AddValidationActionToIPValidationList("Register", "STS_COSRA", () =>
                {
                    return m_ValidationLogic.IsInvalidEmployee(model.CORegulatorNumber, model.COLastName, model.FirmRegisteredName, true);
                });
            }

            if (model.FirmRegulator.ToUpper() == "SRA")
            {
                validator.AddValidationActionToIPValidationList("Register", "STS_BranchSRA", () =>
                {
                    return m_ValidationLogic.IsInvalidBranch(model.COOfficeBranchRegulatorNumber, model.FirmRegisteredName, model.COOfficeAddress.PostalCode);
                });
            }

            var wrapper = validator.ValidateUsingIPValidationList("Register");

            if (wrapper.HasErrors)
            {
                wrapper.ErrorMessages.Where(s => s.Contains("<<Registered CO Firm Name>>"))
                    .ForEach(s => { s.Replace("<<Registered CO Firm Name>>", anotherFirmCOValidationError.ExistingFirmRegisteredName); });
            }

            return wrapper;
        }

        [OverrideActionFilters]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Registration(RegistrationDTO model, AddressDTO address, string CaptchaChallenge, string CaptchaResponse)
        {
            var registrationModel = model;
            registrationModel.COOfficeAddress = address;
            if (model.AmIComplianceOfficer)
            {
                registrationModel.Title = model.COTitle;
                registrationModel.FirstName = model.COFirstName;
                registrationModel.LastName = model.COLastName;
                registrationModel.Email = model.COEmail;
            }

            if (ValidateCaptcha(CaptchaChallenge, CaptchaResponse))
            {
                this.PopulateFormErrors("CaptchaError", null);
                if (ModelState.IsValid)
                {
                    var results = RegistrationModelValidation(model);

                    if (!results.HasErrors)
                    {
                        StartWorkflow(model);

                        Session.Add("RegistrationState", registrationModel);
                        return RedirectToAction("ThankYou");
                    }
                    else
                        return this.PopulateFormErrors("FormErrors", results.ErrorMessages);
                }
                else
                    return this.ReturnFormPanelWithErrorsForInvalidModelState();
            }
            else
            {
                
                RegistrationDTOValidator validator = new RegistrationDTOValidator();
                validator.AddValidationActionToIPValidationList("Register", "CaptchaMismatch", () => { return true; });
                var validationResults = validator.ValidateUsingIPValidationList("Register");
                return this.PopulateFormErrors("CaptchaError", validationResults.ErrorMessages);
            }
        }


        [OverrideActionFilters]
        [AllowAnonymous]
        public ActionResult ThankYou()
        {
            var model = Session["RegistrationState"] as RegistrationDTO;
            return View(model);
        }

        /// <summary>
        /// Create Login Workflow 
        /// Run on other thread to bypass errors as needed
        /// </summary>
        /// <param name="model"></param>
        private void StartWorkflow(RegistrationDTO model)
        {
            var registrationWorkflow = m_WorkflowProcessLogic.GetWorkflowFromName(WorkflowEnum.RegistrationWorkflow.GetStringValue());

            var genericData = new ConcurrentDictionary<string, object>();
            Guid tempUserId = Guid.NewGuid();
            genericData[WorkflowDataEnum.TemporaryAccountData.GetStringValue()] = new TemporaryAccountDTO()
            {
                EmailAddress = model.COEmail,
                TemporaryUserId = tempUserId,
                WorkflowID = registrationWorkflow.WorkflowID,
                WorkflowVersionNumber = registrationWorkflow.WorkflowVersionNumber,
                IsRegistration = true,
                IsSearchInvite = false,
                IsColp = true,
                IsPaymentSuccessful = false,
                OrganisationTypeEnumValue = OrganisationTypeEnum.Conveyancing,
                UserTypeEnumValue = UserTypeEnum.ComplianceOfficer
            };
            genericData[WorkflowDataEnum.RegistrationData.GetStringValue()] = model;

            if (
                !EventPublisher.PublishEvent(m_DataLogic, TFEventEnum.RegistrationCompletedEvent.GetStringValue(), "RegistrationController", model.COEmail,
                    new object[] { genericData[WorkflowDataEnum.TemporaryAccountData.GetStringValue()], genericData[WorkflowDataEnum.RegistrationData.GetStringValue()] }))
            {
                //TBD
            }
        }

      
        private bool ValidateCaptcha(string Challenge, string Response)
        {
            var cientIP = Request.ServerVariables["REMOTE_ADDR"];
            var privateKey = ConfigurationManager.AppSettings["ReCaptchaPrivateKey"];

            string varchallenge = String.Empty;
            string varresponse = String.Empty;

            string data = string.Format("privatekey={0}&remoteip={1}&challenge={2}&response={3}", privateKey, cientIP, Challenge, Response);
            byte[] byteArray = new ASCIIEncoding().GetBytes(data);

            WebRequest request = WebRequest.Create("http://www.google.com/recaptcha/api/verify");
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            var status = (((HttpWebResponse)response).StatusCode);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

            var responseLines = responseFromServer.Split(new string[] { "\n" }, StringSplitOptions.None);
            var success = responseLines[0].Equals("true");
            return success;
        }

        #region RemoteValidation

        public virtual JsonResult DoesEmailExist(string value)
        {
            bool valid = true;
            if (!string.IsNullOrEmpty(value))
                valid = !(m_UserLogic.IsEmailExist(value));

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }

        #endregion


    }
}