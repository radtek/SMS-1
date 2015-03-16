using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bec.TargetFramework.Entities;
using Ext.Net;
using Ext.Net.MVC;
using Fabrik.Common;
using Bec.TargetFramework.UI.Web.Helpers;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities.Validators;
using Bec.TargetFramework.Entities.Helpers;
using Bec.TargetFramework.Workflow.Interfaces;
using Bec.TargetFramework.Infrastructure.Log;



namespace Bec.TargetFramework.UI.Web.Areas.SafeTransactionSearch.Controllers
{
    [DirectController(AreaName = "SafeTransactionSearch")]
    public class FirmBranchesUsersController : Controller
    {


        private IWorkflowProcessService m_WorkflowProcessLogic;
        private ILogger logger;
        private IValidationLogic m_ValidationLogic;
        private IOrganisationLogic m_OrganisationLogic;


        public FirmBranchesUsersController(ILogger logger, IWorkflowProcessService logic, IValidationLogic validationLogic, IDataLogic dLogic)
        {
            this.logger = logger;
            this.m_WorkflowProcessLogic = logic;
            this.m_ValidationLogic = validationLogic;
        }
        public ActionResult Index()
        {
            //return View();
            WorkflowSessionHelper.CreateMockWorkflowState();
            var branches = new List<FirmBranchDTO>();
            branches.Add(new FirmBranchDTO() { ID = Guid.NewGuid(), Name = "Sidcup", IsBranchHeadOffice = true, BranchAdminName = "Tara", RegulatorNumber="wshu12", Notification = "test"});
            branches.Add(new FirmBranchDTO() { ID = Guid.NewGuid(), Name = "York", IsBranchHeadOffice = false, BranchAdminName = "matt", RegulatorNumber = "wshu15" });
            branches.Add(new FirmBranchDTO() { ID = Guid.NewGuid(), Name = "horsham", IsBranchHeadOffice = false, BranchAdminName = "Tina", RegulatorNumber = "wshu18" });
            WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey("Branches", branches);
            WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey("Users", new List<FirmUserDTO>());

            return View();
        }

        public ActionResult GetFirmBranches()//to start with no parameter but lateron public ActionResult GetFirmBranch(Guid organisationId)
        {
            var branches = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<FirmBranchDTO>>("Branches");
            //var branches = new List<FirmBranchDTO>();
            return this.Store(branches, branches.Count);

        }

        public ActionResult GetFirmUsers()//to start with no parameter but lateron public ActionResult GetFirmBranch(Guid organisationId)
        {
            var list = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<FirmUserDTO>>("Users");

            return this.Store(list, list.Count);

        }


        public ActionResult ShowAddBranchWindow()
        {
            Window window = new Window.Builder()
               .ID("AddEditBranchWindow")
               .Title("Add Branch")
               .Icon(Icon.Application)
               .AutoRender(false)
               .Width(750)
               .Height(720)
               .CloseAction(CloseAction.Destroy)
               .BodyPadding(5)
               .Modal(true)
               .Loader(Html.X()
                   .ComponentLoader()
                   .Url(Url.Action("AddEditBranch", "FirmBranchesUsers", new { area = "SafeTransactionSearch" }))
                   .Mode(LoadMode.Frame));

            window.Render(RenderMode.AddTo, "BranchUserManagementForm");

            window.Show();

            return this.Direct();
        }

        public ActionResult ShowEditBranchWindow(string id)
        {
            Window window = new Window.Builder()
                .ID("AddEditBranchWindow")
                .Title("Edit Branch")
                .Icon(Icon.Application)
                .AutoRender(false)
                .Width(750)
                .Height(500)
                .CloseAction(CloseAction.Destroy)
                .BodyPadding(5)
                .Modal(true)
                .Loader(Html.X()
                    .ComponentLoader()
                    .Url(Url.Action("AddEditBranch", "FirmBranchesUsers", new { area = "SafeTransactionSearch", id = id }))
                    .Mode(LoadMode.Frame));

            window.Render(RenderMode.AddTo, "BranchUserManagementForm");

            window.Show();

            return this.Direct();
        }


        public ActionResult ShowAddUserWindow()
        {
            Window window = new Window.Builder()
               .ID("AddEditUserWindow")
               .Title("Add User")
               .Icon(Icon.Application)
               .AutoRender(false)
               .Width(800)
               .Height(510)
               .CloseAction(CloseAction.Destroy)
               .BodyPadding(5)
               .Modal(true)
               .Loader(Html.X()
                   .ComponentLoader()
                   .Url(Url.Action("AddEditUser", "FirmBranchesUsers", new { area = "SafeTransactionSearch" }))
                   .Mode(LoadMode.Frame));

            window.Render(RenderMode.AddTo, "BranchUserManagementForm");

            window.Show();

            return this.Direct();
        }

        public ActionResult AddEditBranch(string id)
        {
            List<FirmBranchDTO> branches = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<FirmBranchDTO>>("Branches");

            FirmBranchDTO dto = null;

            if (!string.IsNullOrEmpty(id))
                if (branches.Any(bs => bs.ID.ToString().Equals(id)))
                    dto = branches.Single(bs => bs.ID.ToString().Equals(id));

            dto = dto ?? new FirmBranchDTO();
            return View("AddEditBranch", dto);
        }


        public ActionResult AddEditUser(string id)
        {
            List<FirmUserDTO> users = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<FirmUserDTO>>("Users");

            FirmUserDTO dto = null;
            dto = dto ?? new FirmUserDTO();
            return View("AddEditUser", dto);
        }

        [HttpPost]
        public ActionResult SaveBranch(FirmBranchDTO model, AddressDTO branchaddress)
        {
            if (ModelState.IsValid)
            {
                 model.Address = branchaddress ?? new AddressDTO();
                 model.ID = model.ID == Guid.Empty ? Guid.NewGuid() : model.ID;

                var branches = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<FirmBranchDTO>>("Branches");
                if (branches.Any(bs => bs.ID.ToString().Equals(model.ID.ToString())))
                    branches.Remove(branches.Single(bs => bs.ID.ToString().Equals(model.ID.ToString())));
                branches.Add(model);
                WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey("Branches", branches);

                Ext.Net.MessageBus.Default.Publish("AddEditBranch");
            }
                       
            return View("AddEditBranch", model);
        }

        [HttpPost]
        [DirectMethod]
        public ActionResult SaveUser(FirmUserDTO model)
        {
            if (ModelState.IsValid)
            {
                //List<AddressDTO> addresses =
                //WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<AddressDTO>>("OtherAddresses");

                //model.ID = Guid.NewGuid().ToString();

                //addresses.Add(model);

                //WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey("OtherAddresses", addresses);

                //Ext.Net.MessageBus.Default.Publish("AddOtherAddress");
            }

            return View(model);
        }

       

        // GET: SafeTransactionSearch/FirmBranchesUsers/Create
        public ActionResult Create()
        {
            return View("AddEditUser", new FirmUserDTO());
        }

       



        public ValidationWrapper FirmBranchModelValidation(FirmBranchDTO model)
        {
            FirmBranchDTOValidator validator = new FirmBranchDTOValidator();
            var existingHeadOfficeDto = new vBranchDTO();
            if (model.Regulator.ToUpper() == "SRA")
            {
                validator.AddValidationActionToIPValidationList("AddBranch", "InvalidBranchSRA", () =>
                {
                    return m_ValidationLogic.IsInvalidBranch(model.RegulatorNumber, model.Name, model.Address.PostalCode);
                });
            }

            if(model.IsBranchHeadOffice)
            {
                validator.AddValidationActionToIPValidationList("AddBranch", "STS_ExistingHeadOffice", () =>
                {
                    List<vBranchDTO> branches = m_OrganisationLogic.GetOrganisationBranches((Guid)model.FirmID);
                    existingHeadOfficeDto = branches.Single(s => s.IsHeadOffice == true);
                    return (branches.Any(b => b.IsHeadOffice == true));
                });
            }


            var wrapper = validator.ValidateUsingIPValidationList("AddBranch");
            if(wrapper.HasErrors)
            {

                wrapper.ErrorMessages.Where(s => s.Contains("<<Existing Head Office Branch Name>>"))
                    .ForEach(s => { s.Replace("<<Existing Head Office Branch Name>>", existingHeadOfficeDto.BranchName); });

                wrapper.ErrorMessages.Where(s => s.Contains("<<New Head Office Branch Name>>"))
                    .ForEach(s => { s.Replace("<<New Head Office Branch Name>>", existingHeadOfficeDto.BranchName); });
                
            }
            return wrapper;
        }



        public ValidationWrapper FirmUserModelValidation(FirmUserDTO model)
        {
            FirmUserDTOValidator validator = new FirmUserDTOValidator();
           
            if (model.Regulator.ToUpper() == "SRA")
            {
                validator.AddValidationActionToIPValidationList("AddUser", "ApprovingSRAFailedUser", () =>
                {
                    return model.IsRegulatorNumberValid;
                });
            }


            var wrapper = validator.ValidateUsingIPValidationList("AddUser");
            return wrapper;
        }

        public ActionResult CheckIfuserExistsOnRejection(string value)
        {
            bool valid = true;
            var list = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<List<FirmUserDTO>>("Users");
            if (list.Count > 0)
                return this.Direct(new { valid = false, msg = "There are " + list.Count + "users associated with this branch. You will need to reallocate these users from the ‘Users table’ before rejecting this branch." });
            else
                return this.Direct(new { valid = true });
        }


        [DirectMethod]
        public ActionResult IsRegulatorNumberValid(string LastName, string RegulatorNumber)
       {
            bool valid = false;

            if (!string.IsNullOrEmpty(RegulatorNumber))
            {
                if (!m_ValidationLogic.IsInvalidEmployee(RegulatorNumber, LastName, "Renier Gillies Limited", false)) //firm name to be changed, hard coded for testing
                    valid = true;
            }
            var hiddenField = this.GetCmp<Hidden>("RegulatorNumberValid");
            hiddenField.Value = valid;
            hiddenField.Update();
           if(valid == false)
               return this.Direct(new { valid = false, msg = "We are unable to validate the details provided against the SRA database" });
           else
               return this.Direct(new { valid = true });
        }


        //[HttpPost]
        public ActionResult Next()
        {
            // need to restart workflow
            var state = WorkflowSessionHelper.GetWorkflowStateDataItemFromSessionUsingKey<WorkflowStateBaseDTO>("WorkflowState");

            object oValue1 = new object();
            var result1 = state.WorkflowDictionaryDto.WorkflowDictionary.TryRemove("NextClicked", out oValue1);
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("NextClicked", (key) => "true");
            state.WorkflowDictionaryDto.WorkflowDictionary.GetOrAdd("BUClicked", (key) => "true");

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
